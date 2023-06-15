using Google.Cloud.Storage.V1;
using FirebaseAdmin;
using Firebase.Database;
using FirebaseAdmin.Auth;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.Json;

namespace Projeto_Final_TCC.Models
{
    public class FirebaseImageUploader
    {
        private readonly string FirebaseCredentialsPath = "path/to/firebase_credentials.json"; // Caminho para o arquivo de credenciais do Firebase

        public async Task<string> UploadImage(byte[] imageBytes, ImageInfo imageInfo)
        {
            // Inicializa o Firebase SDK
            FirebaseApp app = InitializeFirebaseApp();

            // Upload da imagem para o Firebase Storage
            string imageUrl = await UploadImageToFirebaseStorage(imageBytes);

            // Salva os detalhes da imagem no Firebase Realtime Database
            await SaveImageDetailsToFirebaseDatabase(imageInfo, imageUrl);

            // Encerra a conexão com o Firebase
            app.Delete();

            return imageUrl;
        }

        private FirebaseApp InitializeFirebaseApp()
        {
            FirebaseApp app;
            var credentials = GoogleCredential.FromFile(FirebaseCredentialsPath);

            if (FirebaseApp.DefaultInstance == null)
            {
                app = FirebaseApp.Create(new AppOptions()
                {
                    Credential = credentials
                });
            }
            else
            {
                app = FirebaseApp.DefaultInstance;
            }

            return app;
        }

        private async Task<string> UploadImageToFirebaseStorage(byte[] imageBytes)
        {
            string bucketName = "your-firebase-storage-bucket"; // Nome do bucket do Firebase Storage
            string imageName = Guid.NewGuid().ToString(); // Nome único para a imagem

            var storageClient = await StorageClient.CreateAsync();
            var imageObject = await storageClient.UploadObjectAsync(bucketName, imageName, "image/jpeg", new MemoryStream(imageBytes));

            string imageUrl = imageObject.MediaLink;
            return imageUrl;
        }

        private async Task SaveImageDetailsToFirebaseDatabase(ImageInfo imageInfo, string imageUrl)
        {
            string databaseUrl = "https://lively-wonder-378623-default-rtdb.firebaseio.com/"; // URL do Firebase Realtime Database

            var defaultApp = FirebaseApp.DefaultInstance;
           // var database = FirebaseDatabase.GetInstance(defaultApp);

            //var imagesRef = database.GetReference("images");
           // var imageRef = imagesRef.Push();

            var imageDetails = new
            {
                FotoId = imageInfo.FotoId,
                ID_Usuario = imageInfo.ID_Usuario,
                ID_Animal = imageInfo.ID_Animal,
                Longitude = imageInfo.Longitude,
                Latitude = imageInfo.Latitude,
                ID_Verificado = imageInfo.ID_Verificado,
                ImageUrl = imageUrl,
                OBs = imageInfo.OBs
            };

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            //var json = JsonSerializer.Serialize(imageDetails, options);
            //await imageRef.SetRawJsonValueAsync(json);
        }
    }

    public class ImageInfo
    {
        public int FotoId { get; set; }
        public int ID_Usuario { get; set; }
        public int ID_Animal { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public int ID_Verificado { get; set; }
        public string OBs { get; set; }
    }
}
