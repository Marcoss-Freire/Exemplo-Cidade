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
                ViewData["msg"] = "Usu�rio inv�lido, verifique suas informa��es";
                return View();

                
            }
        }
        // Retorna o painel Cliente
        public IActionResult PainelCliente()
        {
            //retorna a pagina  a lista de clientes
            return View(_clienteRepositorio.TodosClientes());
        }

        //criando pagina cadastro cliente
        public IActionResult CadastrarCliente()
        {
            return View();
        }

        //paginacadastro cliente que envia os dados(post)
        [HttpPost]
        public IActionResult CadastrarCliente(Cliente cliente)
        {
            //metodo cadastrar
            _clienteRepositorio.Cadastrar(cliente);
            return RedirectToAction(nameof(PainelCliente));
        }











        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
