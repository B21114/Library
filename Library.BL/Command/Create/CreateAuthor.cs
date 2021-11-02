using Library.DL.Domain.Entities;
using Library.DL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.BL.Command.Create
{
    public class CreateAuthor
    {
        private readonly AuthorDbContext _authorDbContext;
        public CreateAuthor(AuthorDbContext authorDbContext)
        {
            _authorDbContext = authorDbContext;
        }

        public async Task<CreateAuthor> Handle(
         AuthorDTO author,
         CancellationToken cancellationToken)
        {

            var createAuthor = new Author
            {
                Id = Guid.NewGuid(),
                Lastname = author.Lastname,
                Firstname = author.Firstname,
                Patronymic = author.Patronymic,
                Activity = author.Activity
            };

            // Начинает отслеживание сущности контент.
            await _authorDbContext.Authors.AddAsync(createAuthor);

            // Асинхронно сохраняет все изменения, внесенные в этом контексте, в основную базу данных.
            await _authorDbContext.SaveChangesAsync();

            return; 
        }
    }
}
