using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using sample_dotnetcore_console_ef_bulk.DbContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using sample_dotnetcore_console_ef_bulk.Entities;

namespace sample_dotnetcore_console_ef_bulk.Services
{
    public class Bulk : IBulk
    {
        private readonly BooksDbContext _dbContext;

        private readonly ILogger<Bulk> _logger;
        public Bulk(ILoggerFactory loggerFactory, IConfigurationRoot config, BooksDbContext dbContext)
        {
            _logger = loggerFactory.CreateLogger<Bulk>();
            _dbContext = dbContext;
        }

        public void GetData()
        {
            _logger.LogDebug("Test");
            var res = _dbContext.BookDetails.Select(b => b);
        }

        public void InsertBulkData(int count)
        {

            List<BookDetails> _tmpList = new List<BookDetails>();

            for(int r = 0; r < count; r++)
            {
                var newObj = new BookDetails
                {                    
                    Read = false,
                    Title = "Origin",
                    Author = "Barbapapa",
                    Description = "Tolles Buch",
                    Genre = "Thriller",
                    Price = 15
                };

                _tmpList.Add(newObj);

            }

            _dbContext.BookDetails.AddRange(_tmpList);

            _dbContext.SaveChanges();

        }

        public void UpdateBulkData()
        {

            var res = _dbContext.BookDetails.Select(b => b);


            foreach(var item in res)
            {
                item.Price++;
                _dbContext.Attach(item);
                _dbContext.Entry(item).Property("Price").IsModified = true;                
            }

            _dbContext.SaveChanges();

        }

    }
}
