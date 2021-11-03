using Library.BL.Command.Create.CreateBook;
using Library.DL.Domain;
using Library.DL.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.BL.Command.Delete.DeleteBook
{
    public class DeleteBookRequestHandler : IRequestHandler<DeleteBookRequest, DeleteBookResponse>
    {
        private readonly IBookDbContext _bookDbContext;
        public DeleteBookRequestHandler(IBookDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
        }
        public async Task<DeleteBookResponse> Handle(
       DeleteBookRequest request,
       CancellationToken cancellationToken)
        {
            // Поиск книги в базе данных.
            Book book = _bookDbContext.Books.Where(o => o.Id == request.IdBook).FirstOrDefault();

            if (book == null)
            {
                return new DeleteBookResponse
                {
                    Deleted = false
                };
            }
            else
            {
                // Удаление найденной книги. 
                _bookDbContext.Books.Remove(book);

                // Асинхронно сохраняет все изменения, внесенные в этом контексте, в основную базу данных.
                await _bookDbContext.SaveChangesAsync();

                return new DeleteBookResponse
                {
                    Deleted = true
                };
            }
        }

    }
}
