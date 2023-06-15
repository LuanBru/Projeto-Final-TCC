using Firebase.Auth;
using Projeto_Final_TCC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;



namespace Projeto_Final_TCC.Controllers
{
    public class CadastroController : Controller
    {
        public string WebApiKey = "AIzaSyCcq1uDwTFOIxaxWwronRQg9aa4JQvw_pA";
        

        [HttpGet]
        [Route("Cadastro/Cadastro")]
        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        [Route("Cadastro/RealizarCadastro")]
        public async Task<ActionResult> RealizarCadastro(Usuario model)
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebApiKey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(model.Email, model.Senha, model.Nome, true);
                string token = auth.FirebaseToken;

                // Acesso ao email do usuário logado
                string userEmail = auth.User.Email;

                // Armazenar o email do usuário na sessão
                Session["UserEmail"] = userEmail;

                // Cadastro realizado com sucesso, redirecionar para a página desejada
                return RedirectToAction("Principal", "Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Ocorreu um erro ao cadastrar o usuário: " + ex.Message);
                return View("Cadastro", model);
            }
        }
    }
}





        