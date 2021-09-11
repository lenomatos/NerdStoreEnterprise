using Microsoft.AspNetCore.Mvc;
using NSE.Clientes.API.Application.Commands;
using NSE.Core.Mediator;
using NSE.WebAPI.Core.Controllers;
using System;
using System.Threading.Tasks;

namespace NSE.Clientes.API.Controllers
{
    public class ClientesController : MainController
    {
        private readonly IMediatorHandler _meditorHandler;

        public ClientesController(IMediatorHandler meditorHandler)
        {
            _meditorHandler = meditorHandler;
        }

        [HttpGet("clientes")]
        public async Task<IActionResult> Index()
        {
            var resultado = await _meditorHandler.EnviarComando(
                new RegistrarClienteCommand(Guid.NewGuid(), 
                "Leno Matos Cliente", 
                "leno.lisboa21@gmail.com", "84792052025"));

            return CustomReponse(resultado);
        }
    }
}
