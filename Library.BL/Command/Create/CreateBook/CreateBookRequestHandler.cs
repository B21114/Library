using Library.DL.Domain;
using Library.DL.Domain.Entities;
using Library.DL.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.BL.Command.Create.CreateBook
{
    public class CreateBookRequestHandler : IRequestHandler<CreateBookRequest, CreateBookResponse>
    {
        private readonly IDataBaseContext _dataBaseContext;

        public CreateBookRequestHandler(IDataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public async Task<CreateBookResponse> Handle(
        CreateBookRequest request,
        CancellationToken cancellationToken)
        {

            var author = new Author { Id = request.AuthorId };
            var publisher = new Publisher { Id = request.PublisherId };

            var book = new Book
            {
                Id = Guid.NewGuid(),
                Author = author,
                Name = request.Name,
                NumberOfPages = request.NumberOfPages,
                Publisher = publisher
            };

            // Начинает отслеживание сущности книги.
            await _dataBaseContext.Books.AddAsync(book);

            // Асинхронно сохраняет все изменения, внесенные в этом контексте, в основную базу данных.
            await _dataBaseContext.SaveChangesAsync();

            // Возвращает CreateBookResponse с Id новой записи.
            return new CreateBookResponse
            {
                BookId = book.Id
            };
        }
    }
}
