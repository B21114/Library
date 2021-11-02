using Library.DL.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DL.Infrastructure
{
    public class ApplicationContext
    {
        /// <summary>
        ///  Коллекция авторов.
        /// </summary>
        public DbSet<Author> Authors { get; set; }

        /// <summary>
        ///  Набор книг.
        /// </summary>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        ///  Коллекция издателей.
        /// </summary>
        public DbSet<Publisher> Publishers { get; set; }
    }
}
