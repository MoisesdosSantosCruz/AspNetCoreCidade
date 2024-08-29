using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using ProjetoCity.Models;
using ProjetoCity.Repository;
using System.Diagnostics;
using ProjetoCity.Libraries.Login;
using System.Diagnostics.Eventing.Reader;

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

        // P�gina de Login
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
                //Erro na sess�o
                ViewData["msg"] = "Usu�rio n�o encontrado"; //Mensagem de tratamento de erro
                return View();

                
            }
        }
        public IActionResult PainelCliente() 
        {
            return View();
        }

        public IActionResult CadastrarCliente() { 


            return View();

        }
        //Cria��o da p�gina 

       
        //M�todo este que ficar� sempre acima da IActionResult
        [HttpPost]
        public IActionResult CadastrarCliente(Cliente cliente)
        {
            _clienteRepositorio.Cadastrar(cliente);

            return RedirectToAction(nameof(PainelCliente));
        }
        //P�gina CadastroCliente que envia os dados (Post)







        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
