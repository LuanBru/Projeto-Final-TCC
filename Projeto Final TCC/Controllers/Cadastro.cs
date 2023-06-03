using Firebase.Auth;
using Newtonsoft.Json;
using Projeto_Final_TCC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace Projeto_Final_TCC.Controllers
{
    public class Cadastro : Controller
    {
        private static string ApiKey = "AIzaSyBHD0FfT6VBL4kje_dqEX0f2Y3OBzMUybk";
        private static string Bucket = "asp-mvc-with-android.appspot.com";

        public ActionResult Cadastrar()
        {
            return View();
        }

        public async Task<ActionResult> Cadastrar(Usuario model)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebApiKey));

            try
            {

                var auth = await authProvider.SignInWithEmailAndPasswordAsync(Email.Text, senhaentry.Text);
                var content = await auth.GetFreshAuthAsync();
                var serializedcontnet = JsonConvert.SerializeObject(content);
                Preferences.Set("MyFirebaseRefreshToken", serializedcontnet);
                await Navigation.PushAsync(new MainPage());

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View();
        }
    }
}
        

