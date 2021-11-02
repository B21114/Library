using Library.DL.Domain;
using Library.DL.Domain.Entities;
using Library.DL.Infrastructure;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.BL.Command.Create
{
    public class CreateBook
    {
        private readonly ApplicationContext _applicationContext;
        private readonly IAuthorDbContext _author;
        private readonly IBookDbContext _bookDbContext;
        private readonly IPublisherDbContext _publisherDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateBook(IAuthorDbContext authorDbContext,
            IBookDbContext bookDbContext,
            IPublisherDbContext publisherDbContext,
            IHttpContextAccessor httpContextAccessor,
            ApplicationContext applicationContext)
        {
            _author = authorDbContext;
            _bookDbContext = bookDbContext;
            _publisherDbContext = publisherDbContext;
            _httpContextAccessor = httpContextAccessor;
            _applicationContext = applicationContext;
        }


        public async Task<CreateBook> Handle(
        BookDTO book,
        CancellationToken cancellationToken)
        {
            var user = await _applicationContext.Authors
        .FindAsync(new Guid(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value));

            var author = new Author { Id = user.Id };
            var publisher = new Publisher
            { };

            var createBook = new Book
            {
                Id = Guid.NewGuid(),
                Author = author,
                Name = book.Name,
                NumberOfPages = book.NumberOfPages,
                Publisher = publisher
            };

            // Начинает отслеживание сущности книги.
            await _bookDbContext.Books.AddAsync(createBook);


            // Асинхронно сохраняет все изменения, внесенные в этом контексте, в основную базу данных.
            await _bookDbContext.SaveChangesAsync();

            return;
        }
    }
}
