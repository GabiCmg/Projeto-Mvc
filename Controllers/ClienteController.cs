using Microsoft.AspNetCore.Mvc;
using Projeto_Mvc.Models;

namespace Projeto_Mvc.Controllers
{
    public class ClienteController : Controller
    {
        //GET => Consultar dados 
        //POST => Eviar dados

        //Propriedade
        private List<ClienteModel> _clientes;

        public ClienteController()
        {
            _clientes = GerarClientesMocados();
        }

        public IActionResult Index()
        {
             Console.WriteLine(_clientes.Count);

            return View(_clientes);
        }

        //Abre a tela do usuario com o formuláio em branco para preenchimento
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //Rebe os dados digitados pelo usuário e faz a operação como se estivesse gravando no baco de dados
        [HttpPost]
        public IActionResult Create(ClienteModel clienteModel)
        {
            return View();
        }

        public static List<ClienteModel> GerarClientesMocados()
        {
            var clientes = new List<ClienteModel>();

            for (int i = 1; i <= 5; i++) 
            {
                var cliente = new ClienteModel
                {
                    ClienteId = i,
                    Nome = $"Cliente {i}",
                    Sobrenome = $"Sobrenome {i}",
                    DataNascimento = DateTime.Now.AddYears(-30),
                    Observacao = $"Observação do Cliente {i}",
                    RepresentanteId = i,
                    Representante = new RepresentanteModel
                    {
                        RepresentanteId = i,
                        NomeRepresentante = $"Representante {i}",
                        Cpf = "01200000045"
                    }
                };

                clientes.Add(cliente);
            }

            return clientes;
        }
    }
}
