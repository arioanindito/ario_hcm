using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hcm.Web.Models;

namespace Hcm.Web.Views.Administrator
{
    public class testeditModel : PageModel
    {
        private readonly DatabaseContext _context;

        public testeditModel(DatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AdministratorViewModel AdministratorViewModel { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AdministratorViewModel = await _context.AdministratorViewModel.FirstOrDefaultAsync(m => m.Id == id);

            if (AdministratorViewModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AdministratorViewModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministratorViewModelExists(AdministratorViewModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AdministratorViewModelExists(string id)
        {
            return _context.AdministratorViewModel.Any(e => e.Id == id);
        }
    }
}
