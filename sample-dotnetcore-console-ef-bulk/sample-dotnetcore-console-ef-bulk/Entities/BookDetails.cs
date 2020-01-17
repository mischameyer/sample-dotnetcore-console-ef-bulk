using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace sample_dotnetcore_console_ef_bulk.Entities
{
    public class BookDetails
    {
        public BookDetails()
        {

        }

        [Key]
        public int Id { get; set; }
        public bool Read { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}
