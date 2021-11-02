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
    public interface IAuthorDbContext
    {

        /// <summary>
        /// Содержимое таблицы автор.
        /// </summary>
        public DbSet<Author> Authors { get; set; }

        /// <summary>
        /// Асинхронно сохраняет все изменения, внесенные в этом контексте, в основную базу данных.
        /// </summary>
        /// <param name="cancellationToken">Объект для наблюдения за ожиданием завершения задачи.</param>
        /// <returns></returns>
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
