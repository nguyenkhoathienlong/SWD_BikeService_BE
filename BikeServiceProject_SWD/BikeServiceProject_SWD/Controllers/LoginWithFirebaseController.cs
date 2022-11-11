using Firebase.Auth;
using FirebaseAdminAuthentication.DependencyInjection.Models;
using FirebaseAdminAuthentication.DependencyInjection.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BikeService.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class LoginWithFirebaseController : ControllerBase
    {
        private const string WebAPI_KEY = "AIzaSyCHuyxTRP9ARPOiTq9iDLjIlSEr_hIt-eg";

        [HttpPost("login")]
        public async Task<ActionResult<string>> LoginWithEmailAndPasswordFirebase()
        {
            FirebaseAuthProvider firebaseAuthProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPI_KEY));
            FirebaseAuthLink firebaseAuthLink = await firebaseAuthProvider.SignInWithEmailAndPasswordAsync("tipha313@gmail.com", "123456");
            return Ok(firebaseAuthLink.FirebaseToken);
        }
    }
}

