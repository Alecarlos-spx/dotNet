using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using AspNetCore_CrudWebApi.Entities;
using AspNetCore_CrudWebApi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AspNetCore_CrudWebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    //[ApiVersion("1.0")]
    //[Route("api/v{version:apiVersion}/clientes")]
    [ApiController]
    //[ApiVersion("1.0")] //microsoft.AspNetCore.Mvc.Versioning
    [ApiExplorerSettings(GroupName = "v1")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository cliente;

        public ClienteController(IClienteRepository cliente)
        {
            this.cliente = cliente;
        }


        // GET api/cliente
        [SwaggerOperation(
            Summary = "Recupera todos os clientes.",
            Tags = new[] { "Clientes" },
            Produces = new[] { "application/json" }
        )]
        [HttpGet]
        public IActionResult  Get()
        {
            var clientes = cliente.GetClientes();
            return Ok(clientes);
        }

        // GET api/cliente/5
        [SwaggerOperation(
           Summary = "Recupera um cliente pelo Id.",
           Tags = new[] { "Clientes" },
           Produces = new[] { "application/json" }
       )]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var clientes = cliente.Get(id);
            return Ok(clientes);
        }

        // POST api/cliente
        [SwaggerOperation(
           Summary = "Adiciona um novo cliente.",
           Tags = new[] { "Clientes" },
           Produces = new[] { "application/json" }
       )]
        [HttpPost]
        public IActionResult Post([FromBody] Clientes clientes)
        {
            var count = cliente.Add(clientes);
            if (count > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

        // PUT api/cliente/5
        [SwaggerOperation(
           Summary = "Altera o cliente pelo Id.",
           Tags = new[] { "Clientes" },
           Produces = new[] { "application/json" }
       )]
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Clientes clientes)
        {
            var count = cliente.Edit(clientes);
            if (count > 0)
            {
                return Ok();
            }
            return Ok();

        }

        // DELETE api/cliente/5
        [SwaggerOperation(
           Summary = "Apaga o cliente pelo Id.",
           Tags = new[] { "Clientes" },
           Produces = new[] { "application/json" }
       )]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var count = cliente.Delete(id);
            if (count > 0)
            {
                return NoContent();
            }
            return NotFound();

        }
    }
}
