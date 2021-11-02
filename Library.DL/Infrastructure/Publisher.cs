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
    public class PublisherDbContext : DbContext, IPublisherDbContext
    {
        /// <inheritdoc>
        public DbSet<Publisher> Publishers { get; set; }

        public PublisherDbContext(DbContextOptions<PublisherDbContext> options) : base(options)
        {

        }
    }
}