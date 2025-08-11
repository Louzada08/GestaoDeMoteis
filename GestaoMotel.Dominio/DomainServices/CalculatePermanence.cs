using GestaoMotel.Domain.DesignPatterns.Observers;
using GestaoMotel.Domain.Entities;
using GestaoMotel.Domain.Filters;
using GestaoMotel.Domain.Interfaces.DesignPatterns.Observers;
using GestaoMotel.Domain.Interfaces.Services;
using GestaoMotel.Domain.ValueObjects;

namespace GestaoMotel.Domain.DomainServices
{
    public class CalculatePermanence : ICalculatePermanence
    {
        private readonly IPriceTableService _priceTableService;
        public  Prices _price;
        public Comandas _comandas;
        public IPricePermanceObserver _comandaObserver;

        public CalculatePermanence(IPriceTableService priceTableService)
        {
            _priceTableService = priceTableService;
        }

        public async Task<bool> GetTable(ServiceCommand serviceCommand)
        {
            _price = new Prices(0, 0, 0);
            _comandas = new Comandas();

            var priceTableDTO = await _priceTableService.GetAll(serviceCommand);
            decimal novoValorHoras = 0; // todo = obter o valor da comanda atual

            foreach (PriceTable table in priceTableDTO)
            {
                foreach (PriceTableTime valorHora in table.PriceTableTimes)
                {
                    var valorTable = valorHora.Price;
                    novoValorHoras = valorTable.Price;
                    novoValorHoras = SetPricePermanence(_price.Price, valorTable.Price);
                }
            }
            return await Task.FromResult(true);
        }

        public decimal SetPricePermanence(decimal valorComanda, decimal valorTable)
        {
            if(valorComanda != valorTable)
            {
                valorComanda = valorTable;
            }

            return valorComanda;
        }

        public decimal Update(decimal price)
        {
            throw new NotImplementedException();
        }
    }
}
