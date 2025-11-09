using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Claudiu_Cojocaru_Lab2.Data;
using Claudiu_Cojocaru_Lab2.Models;

namespace Claudiu_Cojocaru_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Claudiu_Cojocaru_Lab2Context _context;

        public IndexModel(Claudiu_Cojocaru_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get; set; } = new List<Category>();
        public IList<Book> Books { get; set; } = new List<Book>();
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            Category = await _context.Category
                .Include(c => c.BookCategories)
                    .ThenInclude(bc => bc.Book)
                        .ThenInclude(b => b.Author)
                .OrderBy(c => c.CategoryName)
                .AsNoTracking()
                .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;

                var selectedCategory = Category
                    .SingleOrDefault(c => c.ID == id.Value);

                if (selectedCategory != null)
                {
                    Books = selectedCategory.BookCategories
                        .Select(bc => bc.Book)
                        .ToList();
                }
            }
        }
    }
}
