using GestaoMotel.Domain.Messages.Communication;

namespace GestaoMotel.Domain.Entities;

public class AppUserResponseLogin
{
    public string AccessToken { get; set; } = string.Empty;
    public double ExpiresIn { get; set; }
    public AppUserToken UserToken { get; set; }
    public ResponseResult ResponseResult { get; set; }
}

public class AppUserToken
{
    public string Id { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public IEnumerable<AppUserClaim> Claims { get; set; }
}

public class AppUserClaim
{
    public string Value { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
}
