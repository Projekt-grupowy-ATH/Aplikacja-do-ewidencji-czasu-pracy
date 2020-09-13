using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using AttendanceSystem.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using AttendanceSystem.Models;
using AttendanceSystem.Controllers;

namespace AttendanceSystem.Areas.Identity.Pages.Account
{
    [Authorize(Roles = "Admin")]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<AttendanceSystemUser> _signInManager;
        private readonly UserManager<AttendanceSystemUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        //private readonly IEmailSender _emailSender;

        
        public RegisterModel(
            UserManager<AttendanceSystemUser> userManager,
            SignInManager<AttendanceSystemUser> signInManager,
            ILogger<RegisterModel> logger)
            //IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            //_emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Imię")]
            public string FirstName { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Nazwisko")]
            public string LastName { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Stanowisko")]
            public string Stanowisko { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Uprawnienia")]
            public string Uprawnienia { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Telefon")]
            public int PhoneNumber { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Hasło")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Potwierdz hasło")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }
        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
          //  ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new AttendanceSystemUser { UserName = Input.Email, Email = Input.Email };
                //var employe = new Pracownik
                //{
                //    Imie = Input.FirstName,
                //    Nazwisko = Input.LastName,
                //    Stanowisko = Input.Stanowisko,
                //    Uprawnienia = Input.Uprawnienia,
                //    Telefon = Input.PhoneNumber
                //};
                var result = await _userManager.CreateAsync(user, Input.Password);
                DBCreateQuerrys dBCreate = new DBCreateQuerrys();
                dBCreate.AddNewEmployee(Input.FirstName, Input.LastName, Input.Stanowisko, Input.Uprawnienia, Input.Email, Input.PhoneNumber);


//                if (result.Succeeded)
//                {
//                    _userManager.AddToRoleAsync(user, "User").Wait();
//                    _logger.LogInformation("User created a new account with password.");
//
//                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
//                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
//                    var callbackUrl = Url.Page(
//                        "/Account/ConfirmEmail",
//                        pageHandler: null,
//                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
//                        protocol: Request.Scheme);
//
//                    //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
//                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
//
//                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
//                    {
//                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
//                    }
//                    else
//                    {
//                        await _signInManager.SignInAsync(user, isPersistent: false);
//                        return LocalRedirect(returnUrl);
//                    }
//                }
//                foreach (var error in result.Errors)
//                {
//                    ModelState.AddModelError(string.Empty, error.Description);
//                }
            }

            // If we got this far, something failed, redisplay form
            return RedirectToAction("AttendanceSystem", "Home");
        }
    }
}
