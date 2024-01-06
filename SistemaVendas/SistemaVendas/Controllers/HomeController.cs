using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Models;
using SistemaVendas.Uteis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendas.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //DAL objDAL = new DAL();
            //objDAL.ExecutarComandoSQL("INSERT INTO VENDEDOR(nome, email, senha) values ('filipe', 'filipe@email.com', '12345')");
            return View();
        }
        [HttpGet]        
        public IActionResult Login(int? id)
        {
            if (id!= null)
            {
                if (id == 0)
                {
                    HttpContext.Session.SetString("IdUsuarioLogado", string.Empty);
                    HttpContext.Session.SetString("NomeUsuarioLogado", string.Empty);
                }
            } 
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel login)
        {
            if (ModelState.IsValid) 
            { 
                Boolean longinOK = login.ValidarLogin(); 
                if (longinOK)
                {
                    HttpContext.Session.SetString("IdUsuarioLogado", login.Id);
                    HttpContext.Session.SetString("NomeUsuarioLogado", login.Nome);
                    return RedirectToAction("Menu", "Home");
                }
                else
                {
                    TempData["ErrorLogin"] = "Email ou senha são inválidos";
                }
            }
                
            return View();
        }

        public IActionResult Menu()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
