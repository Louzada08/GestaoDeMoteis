using GestaoMotel.API.Controllers.Main;
using GestaoMotel.Application.Services;
using GestaoMotel.Domain.Dtos;
using GestaoMotel.Domain.Entities;
using GestaoMotel.Domain.Entities.Identity;
using GestaoMotel.InterfaceAdapter.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GestaoMotel.API.Controllers;

[Authorize(Roles = "Gestor, Supervisor")]
[Route("api/[controller]")]
[ApiController]
public class AuthController : MainController
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ITokenService _tokenService;
    private readonly AppSettings _appSettings;

    public AuthController(SignInManager<IdentityUser> signInManager, 
                          UserManager<IdentityUser> userManager, ITokenService tokenService, 
                          IOptions<AppSettings> appSettings,
                          IMediator mediator) : base(mediator)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _tokenService = tokenService;
        _appSettings = appSettings.Value;
    }

    [HttpGet("claims")]
    public IActionResult GetClaims()
    {
        var claims = User.Claims.Select(c => new { c.Type, c.Value });
        return Ok(claims);
    }


    [HttpPost("newaccount")]
    [Authorize(Policy = "Gestor")]
    public async Task<IActionResult> Register([FromBody] UserRegistrationViewModel userRegisterViewModel)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        var user = new IdentityUser
        {
            UserName = userRegisterViewModel.Name,
            NormalizedUserName = userRegisterViewModel.Name.ToUpper(),
            Email = userRegisterViewModel.Email,
            EmailConfirmed = true
        };

        var result = await _userManager.CreateAsync(user, userRegisterViewModel.Password);

        if (result.Succeeded)
        {
            return CustomResponse(await _tokenService.ToGenerateJwt(userRegisterViewModel.Email));
        }

        foreach (var error in result.Errors)
        {
            AddError(error.Description);
        }
        return CustomResponse();
    }

    [HttpPost("sigin")]
    [AllowAnonymous]
    public async Task<ActionResult> Login(UserLogin userLogin)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        var result = await _signInManager.PasswordSignInAsync(userLogin.Email, userLogin.Password,
            false, true);

        if (result.Succeeded)
        {
            // return CustomResponse(result);
            return CustomResponse(await _tokenService.ToGenerateJwt(userLogin.Email));
        }

        if (result.IsLockedOut)
        {
            AddError("Usuário temporariamente bloqueado por tentativas inválidas");
            return CustomResponse();
        }

        AddError("Usuário ou Senha incorretos");
        return CustomResponse();
    }

    [HttpPost("newclaims")]
    [Authorize(Policy = "Gestor")]
    public async Task<IActionResult> RegisterClaim([FromBody] AppUserClaimDTO userClaim)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        var user = await _userManager.FindByEmailAsync(userClaim.Email);

        if (user == null)
            return NotFound("Usuário não encontrado.");

        var claim = new Claim(userClaim.Type, userClaim.Value);

        var result = await _userManager.AddClaimAsync(user, claim);
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                AddError(error.Description);
            }
            return CustomResponse();
        }

        return Ok(result);
    }

}