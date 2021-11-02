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
    /// <summary>
    /// Контекст базы данных контента.
    /// </summary>
    public class AuthorDbContext : DbContext, IAuthorDbContext
    {
        /// <inheritdoc>
        public DbSet<Author> Authors { get; set; }

        public AuthorDbContext(DbContextOptions<AuthorDbContext> options) : base(options)
        {

        }
    }
}