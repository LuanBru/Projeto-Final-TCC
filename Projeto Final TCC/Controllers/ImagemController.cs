using Firebase.Storage;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Extensions.Configuration;

namespace Projeto_Final_TCC.Controllers
{
    public class ImagemController : Controller
    {
        private readonly IConfiguration _configuration;

        public ImagemController()
        {
            // Construtor sem parâmetros
        }
        public ImagemController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult> Upload(HttpPostedFileBase file)
        {
            // Verifica se o arquivo foi enviado corretamente
            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    // Obter as configurações do Firebase do arquivo Web.config
                    var FirebaseConfig = _configuration.GetSection("FirebaseConfig").Value;

                    // Cria uma instância do FirebaseStorage com as configurações
                    var task = new FirebaseStorage(FirebaseConfig)
                        .Child("imagens") // Especifica o caminho para o armazenamento das imagens
                        .Child(Guid.NewGuid().ToString()) // Define um nome único para a imagem
                        .PutAsync(file.InputStream);

                    // Aguarda o término do upload
                    var imageUrl = await task;

                    // Retorna a URL da imagem no Firebase Storage
                    return Content(imageUrl);
                }
                catch (Exception ex)
                {
                    // Tratar possíveis erros
                    return Content("Erro ao enviar a imagem: " + ex.Message);
                }
            }

            // Retorna uma mensagem de erro caso não tenha recebido nenhum arquivo
            return Content("Nenhum arquivo enviado.");
        }
    }
}