using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Claudiu_Cojocaru_Lab2.Data;
using Claudiu_Cojocaru_Lab2.Models;

namespace Claudiu_Cojocaru_Lab2.Pages.Borrowings
{
    public class EditModel : PageModel
    {
        private readonly Claudiu_Cojocaru_Lab2Context _context;

        public EditModel(Claudiu_Cojocaru_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Borrowing Borrowing { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Borrowing = await _context.Borrowing
                .Include(b => b.Member)
                .Include(b => b.Book)
                    .ThenInclude(b => b.Author)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Borrowing == null)
            {
                return NotFound();
            }

            var bookList = _context.Book
                .Include(b => b.Author)
                .Select(b => new
                {
                    b.ID,
                    BookFullName = b.Title + " - " + b.Author.LastName + " " + b.Author.FirstName
                })
                .ToList();

            ViewData["BookID"] = new SelectList(bookList, "ID", "BookFullName", Borrowing.BookID);

            ViewData["MemberID"] = new SelectList(
                _context.Member
                    .Select(m => new
                    {
                        m.ID,
                        Text = string.IsNullOrWhiteSpace(m.FirstName + m.LastName)
                            ? m.Email
                            : (m.FirstName + " " + m.LastName)
                    })
                    .ToList(),
                "ID",
                "Text",
                Borrowing.MemberID
            );


            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Borrowing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Borrowing.Any(e => e.ID == Borrowing.ID))
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
    }
}
