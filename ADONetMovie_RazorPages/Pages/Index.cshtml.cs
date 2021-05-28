using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADONetMovie_RazorPages.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace EFCoreMovie_RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public string Messenge { get; private set; }

        public void OnGet()
        {

            Messenge =  SessionH.Get<User>(HttpContext.Session, "User")?.UserName ??  null;
            if (Messenge != null) Messenge = "back, " + Messenge;
        }
    }
}
