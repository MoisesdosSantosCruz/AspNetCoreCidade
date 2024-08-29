namespace ProjetoCity.Models
{
    public class Cliente
    {
        //CRIANDO O ENCAPSULAMENTO DO OBJETO COM GET E SET
        // encapsulamento = realiza a passsagem de dados de forma mais simples 
        public int Codigo { get; set; }
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        // array para listar clientes 
        public List<Cliente>? ListaCliente { get; set; }
    }
}
