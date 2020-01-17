using Microsoft.EntityFrameworkCore;
using sample_dotnetcore_console_ef_bulk.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace sample_dotnetcore_console_ef_bulk.DbContext
{
    public class BooksDbContext : Microsoft.EntityFrameworkCore.DbContext
    {

        public BooksDbContext()
        {

        }

        public DbSet<BookDetails> BookDetails { get; set; }
        public BooksDbContext(DbContextOptions<BooksDbContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=books;Integrated Security=True;");
        }

    }
}
