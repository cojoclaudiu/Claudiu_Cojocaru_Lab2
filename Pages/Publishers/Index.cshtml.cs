using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Claudiu_Cojocaru_Lab2.Data;
using Claudiu_Cojocaru_Lab2.Models;
using Claudiu_Cojocaru_Lab2.Models.ViewModels;

namespace Claudiu_Cojocaru_Lab2.Pages.Publishers
{
    public class IndexModel : PageModel
    {
        private readonly Claudiu_Cojocaru_Lab2Context _context;

        public IndexModel(Claudiu_Cojocaru_Lab2Context context)
        {
            _context = context;
        }

        public IList<Publisher> Publisher { get; set; } = default!;
        public PublisherIndexData PublisherData { get; set; } = default!;
        public int PublisherID { get; set; }
        public int BookID { get; set; }

        public async Task OnGetAsync(int? id, int? bookID)
        {
            PublisherData = new PublisherIndexData();

            // load publishers with related books + authors
            Publisher = await _context.Publisher
                .Include(i => i.Books)
                    .ThenInclude(c => c.Author)
                .OrderBy(i => i.PublisherName)
                .AsNoTracking()
                .ToListAsync();

            PublisherData.Publishers = Publisher;

            if (id != null)
            {
                PublisherID = id.Value;
                var publisher = PublisherData.Publishers
                    .SingleOrDefault(i => i.ID == id.Value);

                if (publisher != null)
                {
                    PublisherData.Books = publisher.Books;
                }
            }
        }
    }
}
