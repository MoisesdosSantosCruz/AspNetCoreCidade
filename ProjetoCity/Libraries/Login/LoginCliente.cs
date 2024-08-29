using MySqlX.XDevAPI;
using Newtonsoft.Json;
using ProjetoCity.Models;
namespace ProjetoCity.Libraries.Login;
/*instala o pacote newtosoft.json */
/*contém classes que fornecem serviços e objetos que você precisa para escrever suas aplicações. Além disso, 
 * o Framework Class Library possui uma hierarquia de classes que fornecem funcionalidades para os mais diversos tipos de necessidades do usuário*/
public class LoginCliente
{
    //injeção de dependência
    private string Key = "Login.Cliente";
    private Session.Session _sessao;

    //Construtor
    public LoginCliente(Session.Session sessao)
    {
        _sessao = sessao;
    }
    // método login 
    public void Login(Cliente cliente)
    {
        // Serializar- Com a serialização é possível salvar objetos em arquivos de dados
        string clienteJSONString = JsonConvert.SerializeObject(cliente);
    }

    public Cliente GetCliente()
    {
        /* Deserializar-Já a desserialização permite que os 
        objetos persistidos em arquivos possam ser recuperados e seus valores recriados na memória*/

        if (_sessao.Existe(Key))
        {
            string clienteJSONString = _sessao.Consultar(Key);
            return JsonConvert.DeserializeObject<Cliente>(clienteJSONString);
        }
        else
        {
            return null;
        }
    }
    //Remove a sessão e desloga o Cliente
    public void Logout()
    {
        _sessao.RemoverTodos();
    }
}
