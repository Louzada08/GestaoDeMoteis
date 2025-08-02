
using FluentValidation.Results;
using GestaoMotel.Domain.Entities;
using GestaoMotel.Domain.Interfaces.Base;
using GestaoMotel.Domain.Interfaces.Repositories;
using GestaoMotel.Domain.Mediator.Interfaces;
using GestaoMotel.Domain.Messages;
using GestaoMotel.Infra.Extensions;
using GestaoMotel.Infra.Mapping;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Common;

namespace GestaoMotel.Infra.Data
{
    public class AppDbContext : IdentityDbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;

        public AppDbContext(DbContextOptions<AppDbContext> options, IMediatorHandler mediatorHandler) : 
                base(options) 
        {
            _mediatorHandler = mediatorHandler;
        }

        public DbSet<Suite> Suites { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<PriceTable> PricesTable { get; set; }
        public DbSet<PriceTableTime> PricesTableTime { get; set; }
        public DbSet<ServiceCommand> ServicesCommand { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();

            base.OnModelCreating(modelBuilder);

            foreach (var type in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(IBaseEntity).IsAssignableFrom(type.ClrType))
                    modelBuilder.SetSoftDeleteFilter(type.ClrType);
            }

            modelBuilder.ApplyConfiguration(new SuiteMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new PriceTableMap());
            modelBuilder.ApplyConfiguration(new PriceTableTimeMap());
            modelBuilder.ApplyConfiguration(new ServiceCommandMap());
        }

        public async Task<bool> Commit()
        {
            if (await base.SaveChangesAsync() <= 0)
                return false;

            await _mediatorHandler.PublishEvents(this);

            return true;
        }

        public bool DatabaseExists()
        {
            try
            {
                return Database.GetService<IRelationalDatabaseCreator>().Exists();
            }
            catch (DbException)
            {
                return false;
            }
        }
    }
}
