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

            var publisher = await _dataBaseContext.Publishers.FindAsync(request.PublisherId);
            if (publisher == null)
            {
                new Exception("publisher null");
            }

            // Получаем строку с несколькими Id, перечисленных через запятую,
            // она разбивается на несколько авторов.
            var authors = request.AuthorsId.Split(',');

            IEnumerable<Guid> guidsCollection = authors.Select(p => Guid.Parse(p));
            /*List<Author> authors1 = new List<Author>();

            foreach (Guid guid in guidsCollection)
            {
                authors1.Add(await _dataBaseContext.Authors.FindAsync(guid));
            };*/
            var author = await _dataBaseContext.Authors.FindAsync(guidsCollection.First());
            if (author == null)
            {
                new Exception("author null");
            }
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
