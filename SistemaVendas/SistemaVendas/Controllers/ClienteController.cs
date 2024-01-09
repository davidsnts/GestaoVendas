using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Models;
using System;

namespace SistemaVendas.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ListaClientes = new ClienteModel().ListarTodosClientes();
            return View();
        }
        [HttpGet]
        public IActionResult Cadastro()
        {            
            return View();
        }
        [HttpPost]
        public IActionResult Cadastro(ClienteModel cliente)
        {            
            if (ModelState.IsValid) 
            {
                cliente.Inserir();
                return RedirectToAction("Index");
            }
            return View();
        }
       
    }
}
