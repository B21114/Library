using Library.DL.Domain;
using Library.DL.Domain.Entities;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.BL.Command.Delete
{
    public class DeleteBook
    {
        private readonly IBookDbContext _bookDbContext;
        public DeleteBook(IBookDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
        }
        public async Task<DeleteBook> Handle(
       BookDTO book,
       CancellationToken cancellationToken)
        {
            await _bookDbContext.Books.Remove(book.Id); ;
            // Асинхронно сохраняет все изменения, внесенные в этом контексте, в основную базу данных.
            await _bookDbContext.SaveChangesAsync();
            return ;
        }

    }
}
