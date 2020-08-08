using Microsoft.AspNetCore.Mvc;
using MVCGram.Application.SignUp;
using System;
using System.Threading.Tasks;

namespace MVCGram.Web.SignUp
{
    public class SignUpController : Controller
    {
        private readonly ISignUpService _signUpService;

        public SignUpController(ISignUpService signUpService)
        {
            _signUpService = signUpService ?? throw new ArgumentNullException(nameof(signUpService));
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SignUpModel signUpModel)
        {
            if (ModelState.IsValid)
            {
                var response = await _signUpService.SignUp(new SignUpRequest
                {
                    Username = signUpModel.Username,
                    Password = signUpModel.Password
                });

                if (response.IsSuccess)
                {
                    return RedirectToAction("Index", "Login");
                }
            }

            return View(signUpModel);
        }
    }
}
