using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hcm.Web.Models;

namespace Hcm.Web.Views.Administrator
{
    public class IndexModel : PageModel
    {
        private readonly DatabaseContext _context;

        public IndexModel(DatabaseContext context)
        {
            _context = context;
        }

        public IList<AdministratorViewModel> AdministratorViewModel { get;set; }

        public async Task OnGetAsync()
        {
            AdministratorViewModel = await _context.AdministratorViewModel.ToListAsync();
        }
    }
}
