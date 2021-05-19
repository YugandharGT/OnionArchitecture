using WebAPI.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Text;
using Microsoft.AspNetCore.WebUtilities;

namespace BlazorServerApp.Pages
{
    public class RegisterBase : ComponentBase
    {
        private readonly ApplicationUser _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<RegisterBase> _logger;

        #region ViewModels
        [Parameter]
        public string UserName { get; set; }
        [Parameter]
        public string EmailAddress { get; set; }
        [Parameter]
        public string Password { get; set; }

        bool isShow;

        public InputType PasswordInput = InputType.Password;
        public string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;

        public void ButtonTestclick()
        {
            System.Diagnostics.Debug.WriteLine($"enterd password is: {0}", Password);
            if (isShow)
            {
                isShow = false;
                PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
                PasswordInput = InputType.Password;
            }
            else
            {
                isShow = true;
                PasswordInputIcon = Icons.Material.Filled.Visibility;
                PasswordInput = InputType.Text;
            }
        }
        #endregion

        #region Page Actions
        //public ApplicationUser UserManager
        //{
        //    get
        //    {
        //        return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUser>();
        //    }
        //    private set
        //    {
        //        _userManager = value;
        //    }
        //}

        //public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        //{
        //    returnUrl = returnUrl ?? Url.Content("~/");
        //    ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync())
        //                                          .ToList();
        //    //if (ModelState.IsValid)
        //    {
        //        var user = new IdentityUser { UserName = UserName, Email = EmailAddress };
        //        var result = await UserManager.CreateAsync(user, Password);
        //        if (result.Succeeded)
        //        {
        //            _logger.LogInformation("User created a new account with password.");

        //            var code = await UserManager.GenerateEmailConfirmationTokenAsync(user);
        //            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        //            var callbackUrl = Url.Page(
        //                "/Account/ConfirmEmail",
        //                pageHandler: null,
        //                values: new { area = "Identity", userId = user.Id, code = code },
        //                protocol: Request.Scheme);

        //            await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
        //                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

        //            if (_userManager.Options.SignIn.RequireConfirmedAccount)
        //            {
        //                return RedirectToPage("RegisterConfirmation",
        //                                      new { email = Input.Email });
        //            }
        //            else
        //            {
        //                await _signInManager.SignInAsync(user, isPersistent: false);
        //                return LocalRedirect(returnUrl);
        //            }
        //        }
        //        foreach (var error in result.Errors)
        //        {
        //            ModelState.AddModelError(string.Empty, error.Description);
        //        }
        //    }

        //    // If we got this far, something failed, redisplay form
        //    return Page();
        //}
        #endregion
    }
}
