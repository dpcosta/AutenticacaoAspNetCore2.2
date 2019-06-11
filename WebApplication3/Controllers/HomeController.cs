using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Paginacao;

namespace WebApplication3.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        IEnumerable<Produto> produtos;

        public HomeController()
        {
            produtos = new List<Produto>
            {
                new Produto { Id = 1, Descricao = "Laranja", Categoria = "Hortifruti", PrecoUnitario = 0.99 },
                new Produto { Id = 2, Descricao = "Banana", Categoria = "Hortifruti", PrecoUnitario = 1.99 },
                new Produto { Id = 3, Descricao = "Maçã", Categoria = "Hortifruti", PrecoUnitario = 2.99 },
                new Produto { Id = 4, Descricao = "Abacaxi", Categoria = "Hortifruti", PrecoUnitario = 3.99 },
                new Produto { Id = 5, Descricao = "Morango", Categoria = "Hortifruti", PrecoUnitario = 4.99 },

                new Produto { Id = 6, Descricao = "Detergente", Categoria = "Limpeza", PrecoUnitario = 5.99 },
                new Produto { Id = 7, Descricao = "Água Sanitária", Categoria = "Limpeza", PrecoUnitario = 6.99 },
                new Produto { Id = 8, Descricao = "Detergente", Categoria = "Limpeza", PrecoUnitario = 7.99 },

                new Produto { Id = 9, Descricao = "Presunto", Categoria = "Frios", PrecoUnitario = 8.99 },
                new Produto { Id = 10, Descricao = "Mortadela", Categoria = "Frios", PrecoUnitario = 9.99 },
                new Produto { Id = 11, Descricao = "Muzzarela", Categoria = "Frios", PrecoUnitario = 10.99 },

                new Produto { Id = 12, Descricao = "Picanha", Categoria = "Carnes", PrecoUnitario = 11.99 },
                new Produto { Id = 13, Descricao = "Patinho", Categoria = "Carnes", PrecoUnitario = 12.99 },
                new Produto { Id = 14, Descricao = "Frango", Categoria = "Carnes", PrecoUnitario = 13.99 },
                new Produto { Id = 15, Descricao = "Calabresa", Categoria = "Carnes", PrecoUnitario = 14.99 },
                new Produto { Id = 16, Descricao = "Peixe", Categoria = "Carnes", PrecoUnitario = 15.99 },
            };
        }

        public IActionResult Index(int pagina = 1, int tamanho = 5)
        {
            var usuario = HttpContext.User;
            var empresaId = usuario.Claims
                .Where(c => c.Type == "EmpresaPadrao")
                .Select(c => c.Value)
                .FirstOrDefault();
            
            var model = ListaPaginada<Produto>
                .Create(produtos.AsQueryable(), pagina, tamanho);
            return View(model);
        }

        [Authorize(Roles = "Admin")]
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
