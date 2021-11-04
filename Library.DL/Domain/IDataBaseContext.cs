using Library.DL.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.DL.Domain
{
    public interface IDataBaseContext
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

        /// <summary>
        /// Асинхронно сохраняет все изменения, внесенные в этом контексте, в основную базу данных.
        /// </summary>
        /// <param name="cancellationToken">Объект для наблюдения за ожиданием завершения задачи.</param>
        /// <returns></returns>
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
