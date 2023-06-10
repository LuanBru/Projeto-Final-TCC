using System.Threading.Tasks;
using System.Web.Mvc;
using Firebase.Auth;
using Projeto_Final_TCC.Models;

namespace Projeto_Final_TCC.Controllers
{
    public class LoginController : Controller
    {
        public string WebApiKey = "AIzaSyCcq1uDwTFOIxaxWwronRQg9aa4JQvw_pA";
       
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> RealizarLogin(Usuario model)
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebApiKey));
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(model.Email, model.Senha);

                // Acesso ao email do usuário logado
                string userEmail = auth.User.Email;

                // Armazenar o email do usuário na sessão
                Session["UserEmail"] = userEmail;

                // Login bem-sucedido, redirecionar para a página desejada
                return RedirectToAction("Index", "Home");
            }
            catch (FirebaseAuthException ex)
            {
                ModelState.AddModelError(string.Empty, "Falha no login: " + ex.Reason);
                return View("Login", model);
            }
        }
    }
}