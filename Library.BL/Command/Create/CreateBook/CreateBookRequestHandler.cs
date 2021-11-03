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
        private readonly ApplicationContext _applicationContext;
        private readonly IAuthorDbContext _author;
        private readonly IBookDbContext _bookDbContext;
        private readonly IPublisherDbContext _publisherDbContext;

        public CreateBookRequestHandler(IAuthorDbContext authorDbContext,
            IBookDbContext bookDbContext,
            IPublisherDbContext publisherDbContext,
            ApplicationContext applicationContext)
        {
            _author = authorDbContext;
            _bookDbContext = bookDbContext;
            _publisherDbContext = publisherDbContext;
            _applicationContext = applicationContext;
        }


        public async Task<CreateBookResponse> Handle(
        CreateBookRequest request,
        CancellationToken cancellationToken)
        {
   
            var author = new Author { Id = request.Author.Id };
            var publisher = new Publisher { Id = request.Author.Id };

            var book = new Book
            {
                Id = Guid.NewGuid(),
                Author = author,
                Name = request.Name,
                NumberOfPages = request.NumberOfPages,
                Publisher = publisher
            };

            // Начинает отслеживание сущности книги.
            await _bookDbContext.Books.AddAsync(book);

            // Асинхронно сохраняет все изменения, внесенные в этом контексте, в основную базу данных.
            await _bookDbContext.SaveChangesAsync();

            // Возвращает CreateBookResponse с Id новой записи.
            return new CreateBookResponse
            {
                IdBook = book.Id
            };
        }
    }
}
