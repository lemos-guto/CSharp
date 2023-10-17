namespace SP3065791MVCDB.Models;

public class Venda
{
    public int VendaId { get; set; }
    public int PedidoId { get; set; }
    public int ClienteId { get; set; }
    public string DataVenda { get; set; }
    public int DescontoVenda { get; set; }
    public int ValorBrutoVenda { get; set; }

    public Venda() { }

    public Venda(int vendaId, int pedidoId, int clienteId, string dataVenda, int descontoVenda, int valorBrutoVenda)
    {
        VendaId = vendaId;
        PedidoId = pedidoId;
        ClienteId = clienteId;
        DataVenda = dataVenda;
        DescontoVenda = descontoVenda;
        ValorBrutoVenda = valorBrutoVenda;
    }
}
