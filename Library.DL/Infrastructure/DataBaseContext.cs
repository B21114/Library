using Library.DL.Domain;
using Library.DL.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DL.Infrastructure
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        /// <summary>
        /// Содержимое таблицы автор.
        /// </summary>
        public DbSet<Author> Authors { get; set; }

        /// <summary>
        /// Содержимое таблицы книги.
        /// </summary>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// Содержимое таблицы издатель.
        /// </summary>
        public DbSet<Publisher> Publishers { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            Database.EnsureCreated();

        }
    }
}
