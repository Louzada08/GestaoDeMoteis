using AutoMapper;
using GestaoMotel.Domain.Entities;
using GestaoMotel.Domain.Interfaces.Repositories;
using GestaoMotel.Infra.Data;

namespace GestaoMotel.Infra.Repositories;

public class PriceTableTimeRepository : BaseRepository<PriceTableTime>, IPriceTableTimeRepository
{
    private readonly AppDbContext _context;
    public PriceTableTimeRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
    {
        _context = context;
    }
    IUnitOfWork UnitOfWork => _context;
}
