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
        private readonly IDataBaseContext _dataBaseContext;
        public DeleteBookRequestHandler(IDataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        public async Task<DeleteBookResponse> Handle(
       DeleteBookRequest request,
       CancellationToken cancellationToken)
        {
            // Поиск книги в базе данных.
            Book book = _dataBaseContext.Books.Where(o => o.Id == request.BookId).FirstOrDefault();

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
                _dataBaseContext.Books.Remove(book);

                // Асинхронно сохраняет все изменения, внесенные в этом контексте, в основную базу данных.
                await _dataBaseContext.SaveChangesAsync();

                return new DeleteBookResponse
                {
                    Deleted = true
                };
            }
        }

    }
}
