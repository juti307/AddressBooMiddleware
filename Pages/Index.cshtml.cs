using AddressBookPS02.Model;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Net.Http;
using AddressBookPS02.Utils;

namespace AddressBookPS02.Pages
{
    [CustomFilterAttributes]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private IHttpContextAccessor _accessor;
        [BindProperty] //przypinamy by był to element przesyłany w postcie, z domyślnymi ustawieniami
        public Address Address { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }
        public string CurrIP { get; set; }
        public string ClientIPAddress { get; set; }

        public dynamic viewData { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _accessor = httpContextAccessor;
        }

        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                Name = "User";
            }
        }
        public IActionResult OnPost() //metoda on post
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("SessionAddress",
                JsonConvert.SerializeObject(Address));
                return RedirectToPage("./Address");
            }
            return Page();
            //return RedirectToPage("./Privacy"); // przejdź do strony Privaacy
        }
        

    }
}
