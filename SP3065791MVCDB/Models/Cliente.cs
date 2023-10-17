namespace SP3065791MVCDB.Models;
public class Cliente
{
    public int ClienteId { get; set; }
    public string Nome { get; set; }
    public string RG { get; set; }
    public string CPF { get; set; }
    public string Endereco { get; set; }

    public Cliente() { }
    
    public Cliente(int clienteId, string nome, string rg, string cpf, string endereco)
    {
        ClienteId = clienteId;
        Nome = nome;
        RG = rg;
        CPF = cpf;
        Endereco = endereco;
    }
}
