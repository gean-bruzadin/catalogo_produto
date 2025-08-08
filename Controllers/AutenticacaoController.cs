using catalogo_produto.Config;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace catalogo_produto.Controllers
{
    public class AutenticacaoController : Controller
    {
        private readonly DbConfig _dbConfig;
        public AutenticacaoController(DbConfig dbConfig)
        {
            _dbConfig = dbConfig;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string senha) 
        { 
            if(email != null && senha != null) 
            {
                var usuario = _dbConfig.usuarios.FirstOrDefault(
                   u => u.Email_usuario == email && u.Senha_usuario == senha
               );
                if(usuario != null && BCrypt.Net.BCrypt.Verify(senha, usuario.Senha_usuario))
                {
                    var regras = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, usuario.Id_usuario.ToString()),
                        new Claim(ClaimTypes.Name, usuario.Nome_usuario),
                        new Claim(ClaimTypes.Email, usuario.Email_usuario)
                    }
                   

                   return RedirectToAction("Index", "usuario");

                }
                ViewBag.Mensagem = "E-mail e/ou Senha Inválidos";
            }
            ViewBag.Mensagem = "E-mail e/ou Senha devem ser preenchidos";
            return View();

           
        }
    }
}
