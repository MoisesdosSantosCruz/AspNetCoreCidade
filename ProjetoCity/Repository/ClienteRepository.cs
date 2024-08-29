using ProjetoCity.Models;
using System.Data;
using MySql.Data.MySqlClient;
namespace ProjetoCity.Repository;

// Chamar a interface com herança
public class ClienteRepository : IClienteRepository
{
    //declarando a varival de da string de conxão

    private readonly string? _conexaoMySQL;

    //metodo da conexão com banco de dados
    public ClienteRepository(IConfiguration conf) => _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
    
    //Login Cliente(metodo )

    public Cliente Login(string Email, string Senha)
    {
         //usando a variavel conexao 
        using (var conexao = new MySqlConnection(_conexaoMySQL))
        {
            //abre a conexão com o banco de dados
            conexao.Open();

            // variavel cmd que receb o select do banco de dados buscando email e senha
            MySqlCommand cmd = new MySqlCommand("select * from tb_Cliente where email = @Email and senha = @Senha", conexao);

            //os paramentros do email e da senha 
            cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = Email;
            cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = Senha;

            //Le os dados que foi pego do email e senha do banco de dados
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            //guarda os dados que foi pego do email e senha do banco de dados
            MySqlDataReader dr;

            //instanciando a model cliente
            Cliente cliente = new Cliente();
            //executando os comandos do mysql e passsando paa a variavel dr
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            //verifica todos os dados que foram pego do banco e pega o email e senha
            while (dr.Read())
            {

                cliente.Email = Convert.ToString(dr["email"]);
                cliente.Senha = Convert.ToString(dr["senha"]);
            }
            return cliente;

        }

    }
    // Método CadastrarCliente
    public void Cadastrar(Cliente cliente)
    {
        using (var conexao = new MySqlConnection(_conexaoMySQL))

        {
            conexao.Open();

            MySqlCommand cmd = new MySqlCommand("insert into tb_Cliente (nome,telefone,email) values (@nome, @telefone, @email)", conexao); // @: PARAMETRO

            cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = cliente.Nome;
            cmd.Parameters.Add("@telefone", MySqlDbType.VarChar).Value = cliente.Telefone;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = cliente.Email;

            cmd.ExecuteNonQuery();
            conexao.Close();
        }

    }
        
}
