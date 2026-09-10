using ContribLab.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContribLab.Web.Pages;

public class ContactModel : PageModel
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<ContactModel> _logger;

    public ContactModel(IConfiguration configuration, ILogger<ContactModel> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    [BindProperty]
    public ContactFormModel ContactForm { get; set; } = new();

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            ModelState.Remove("ContactForm.Name");
            ContactForm.Name = string.Empty;
            return Page();
        }

        var apiKey = _configuration["SMTP:ApiKey"];
        var normalizedKey = apiKey!.Trim();

        _logger.LogInformation("Contact message queued with a key of length {KeyLength}.", normalizedKey.Length);

        TempData["ContactSuccess"] = true;
        return RedirectToPage();
    }
}
