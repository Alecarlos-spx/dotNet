using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore_CrudAdo.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_CrudAdo.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteDAL _cliente;

        public ClienteController(IClienteDAL cliente)
        {
            _cliente = cliente;
        }

        public IActionResult Index()
        {
            List<Clientes> listaClientes = new List<Clientes>();
            listaClientes = _cliente.GetAllClientes().ToList();

            return View(listaClientes);
        }

        [HttpGet]
        public IActionResult Detail(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Clientes cliente = _cliente.GetCliente(id);

            if(cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind]Clientes cliente)
        {
            if (ModelState.IsValid)
            {
                _cliente.AddClientes(cliente);
                return RedirectToAction("Index");

            }
            return View(cliente);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Clientes cliente = _cliente.GetCliente(id);

            if(cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind]Clientes cliente)
        {
            if(id != cliente.ClienteId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _cliente.UpdateCliente(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            Clientes cliente = _cliente.GetCliente(id);

            if(cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            _cliente.DeleteCliente(id);
            return RedirectToAction("Index");
        }


    }
}
