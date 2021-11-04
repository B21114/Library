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

            // Прилетает строка с несколькими Id через запятую, она разбивается на несколько авторов
            var authors = request.AuthorsId
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

            // Перебираю найденных авторов в базе данных и присваиваю в темпавтор.
            foreach (var authorId in authors)
            {
                var tempauthor = await _dataBaseContext.Authors.FindAsync(authorId);
            };
            var dfd = List<Author> { new Author { Id} }

            var book = new Book
            {
                Id = Guid.NewGuid(),
                Author = ,
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
