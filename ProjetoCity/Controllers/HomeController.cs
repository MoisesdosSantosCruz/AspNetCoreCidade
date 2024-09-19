using Microsoft.AspNetCore.Mvc;
using ProjetoCity.Models;
using ProjetoCity.Repository;
using ProjetoCity.Libraries.Login;
using System.Diagnostics;



namespace ProjetoCity.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // Interfaces para cliente e login 
        private IClienteRepository? _clienteRepositorio;
        private LoginCliente _loginCliente;

        public HomeController(ILogger<HomeController> logger, IClienteRepository clienteRepositorio, LoginCliente loginCliente) //-- recurso essencial para detectar ou investigar problemas(loggs); )
        {
            _logger = logger;
            _clienteRepositorio = clienteRepositorio;
            _loginCliente = loginCliente;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Página de Login
        public IActionResult Login()
        {

            return View();
        }
        
        // Carrega a a tela login
        [HttpPost]
        public IActionResult Login(Cliente cliente)
        {
            Cliente loginDB = _clienteRepositorio.Login(cliente.Email, cliente.Senha);

            if (loginDB.Email != null && loginDB.Senha != null)
            {
                _loginCliente.Login(loginDB);
                return new RedirectResult(Url.Action(nameof(PainelCliente)));
            }
            else
            {
                //Erro na sessão
                ViewData["msg"] = "Usuário não encontrado"; //Mensagem de tratamento de erro
                return View();

                
            }
        }
        public IActionResult PainelCliente() 
        {
           //Retorna na página a lista de todos os clientes, sabendo o que ele vai fazer.
            return View(_clienteRepositorio.TodosClientes());
        }

        public IActionResult CadastrarCliente() { 


            return View();

        }
        //Criação da página 

       
        //Método este que ficará sempre acima da IActionResult
        [HttpPost]
        public IActionResult CadastrarCliente(Cliente cliente)
        {
            _clienteRepositorio.Cadastrar(cliente);

            return RedirectToAction(nameof(PainelCliente));
        }
        //Página CadastroCliente que envia os dados (Post)
        //E


        //editar
        [HttpPost]
        public IActionResult EditarCliente(Cliente cliente)
        {

            // Carrega a lista de Cliente
            var listaCliente = _clienteRepositorio.TodosClientes();

            //metodo que atualiza cliente
            _clienteRepositorio.Atualizar(cliente);
            //redireciona para a pagina home

            return RedirectToAction(nameof(PainelCliente));

        }

        public IActionResult EditarCliente(int id)
        {
            // Carrega a liista de Cliente
            var listaCliente = _clienteRepositorio.TodosClientes();
            var ObjCliente = new Cliente
            {
                //metodo que lista cliente
                ListaCliente = (List<Cliente>)listaCliente

            };

            //Retorna o cliente pegando o id
            return View(_clienteRepositorio.ObterCliente(id));
        }

        // Exucluir 

        // Página Exclui cliente
        public IActionResult ExcluirCliente(int id)
        {
            //metodo que exclui cliente
            _clienteRepositorio.Excluir(id);
            //redireciona para a pagina home
            return RedirectToAction(nameof(PainelCliente));
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        




    }
}
