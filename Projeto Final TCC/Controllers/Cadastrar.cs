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
    public class Cadastrar : Controller
    {
        public string WebApiKey = "AIzaSyCJtd6ZalAdrELxM8jsbaTZqtB64zZ3SgI";


        async void cadastrobtn_Clicked(System.Object sender, System.EventArgs e)
        {

                try
                {
                    var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebApiKey));
                    var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(email.Text, senha.Text);
                    string gettoken = auth.FirebaseToken;


                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Ocorreu um erro ao cadastrar o usuário: " + ex.Message);

                }
            }
        }
    }




        