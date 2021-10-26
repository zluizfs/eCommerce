using System.Threading.Tasks;
using eCommerce.Models.Autenticacao;
using eCommerce.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace eCommerce.Controllers
{
  public class AutenticacaoController : Controller
  {
    private readonly UserManager<Usuario> _userManager;

    private readonly SignInManager<Usuario> _signInManager;

    private readonly ILogger _logger;

    public AutenticacaoController(UserManager<Usuario> userManager,
      SignInManager<Usuario> signInManager,
      ILogger<AutenticacaoController> logger)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _logger = logger;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> Acessar(string returnUrl = null)
    {
      await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
      ViewData["ReturnUrl"] = returnUrl;
      return View();
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult RegistrarNovoUsuario(string returnUrl = null)
    {
      ViewData["ReturnUrl"] = returnUrl;
      return View();
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RegistrarNovoUsuario(RegistrarNovoUsuarioViewModel model, string returnUrl = null)
    {
      ViewData["ReturnUrl"] = returnUrl;
      if (ModelState.IsValid)
      {
        var user = new Usuario
        {
          UserName = model.Email,
          Email = model.Email
        };
        var result = await _userManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
          _logger.LogInformation("Usuário criou uma nova conta com senha.");

          var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

          // ToDo: estudar como configurar envio de e-mail.
          await _signInManager.SignInAsync(user, isPersistent: false);
          _logger.LogInformation("Usuário autenticado.");

          return RedirectToLocal(returnUrl);
        }
        AddErrors(result);
      }
      return View(model);
    }

    private void AddErrors(IdentityResult result)
    {
      foreach (var error in result.Errors)
      {
        ModelState.AddModelError(string.Empty, error.Description);
      }
    }
    private IActionResult RedirectToLocal(string returnUrl)
    {
      if (Url.IsLocalUrl(returnUrl))
      {
        return Redirect(returnUrl);
      }
      else
      {
        return RedirectToAction(nameof(HomeController.Index), "Home");

      }
    }



  }
}