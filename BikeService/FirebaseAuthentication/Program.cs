
using Firebase.Auth;
using Refit;

namespace FirebaseAuthentication
{
    class Program
    {
        private const string WebAPI_KEY = "AIzaSyCHuyxTRP9ARPOiTq9iDLjIlSEr_hIt-eg";

        static async Task Main(string[] args)
        {
            FirebaseAuthProvider firebaseAuthProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPI_KEY));

            FirebaseAuthLink firebaseAuthLink = await firebaseAuthProvider.SignInWithEmailAndPasswordAsync("nguyenkhoathienlong313@gmail.com", "Nguyenkhoathienlong0967291546@");

            Console.WriteLine(firebaseAuthLink.FirebaseToken);

            IDataService dataService = RestService.For<IDataService>("https://localhost:64391");
            await dataService.GetData(firebaseAuthLink.FirebaseToken);
        }
    }

    public interface IDataService
    {
        [Get("/")]
        Task GetData([Authorize("Bearer")] string token);
    }
}