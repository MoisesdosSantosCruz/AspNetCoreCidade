using ProjetoCity.Models;

namespace ProjetoCity.Repository
{

    public interface IClienteRepository //Cardápio - Menu
    {
        // CRUD
        //login
        // Em verde model, amarelo = método (dentro dele  está as funçoes do sql(select, insert, etc))
        Cliente Login(string Email, string Senha);

        //CadastrarCliente
        void Cadastrar(Cliente cliente);

        //Buscar Todos os clientes
        IEnumerable<Cliente> TodosClientes(); 
        //IEnumerable signfica que passará um Array

        //Busca todos por id
        Cliente ObterCliente(int id);

        //Atualizar Cliente
        void Atualizar(Cliente cliente);// Haverá atualização futuras

        void Excluir(int id); // Excluir



    }
}