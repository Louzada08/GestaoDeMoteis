namespace GestaoMotel.Infra.DesignPatterns.Observers;

public class Comanda2Observer
{
    public Guid commandId { get; set; }
    public Guid suiteId { get; set; }
    public decimal novoValorHora { get; set; } 

    public Comanda2Observer(Guid commandId, Guid suiteId, decimal novoValorHora)
    {
        this.commandId = commandId;
        this.suiteId = suiteId;
        this.novoValorHora = novoValorHora;
    }
}