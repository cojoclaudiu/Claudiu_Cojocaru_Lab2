using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Claudiu_Cojocaru_Lab2.Models;

namespace Claudiu_Cojocaru_Lab2.Data
{
    public class Claudiu_Cojocaru_Lab2Context : DbContext
    {
        public Claudiu_Cojocaru_Lab2Context(DbContextOptions<Claudiu_Cojocaru_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Claudiu_Cojocaru_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Claudiu_Cojocaru_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Claudiu_Cojocaru_Lab2.Models.Author> Author { get; set; } = default!;
        public DbSet<Claudiu_Cojocaru_Lab2.Models.Category> Category { get; set; } = default!;
    }
}
