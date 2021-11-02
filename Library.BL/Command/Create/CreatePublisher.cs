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
    public class CreatePublisher
    {

        private readonly PublisherDbContext _publisherDbContext;
        public CreatePublisher(PublisherDbContext publisherDbContext)
        {
            _publisherDbContext = publisherDbContext;
        }

        public async Task<CreatePublisher> Handle(
         PublisherDTO publisher,
         CancellationToken cancellationToken)
        {

            var createPublisher = new Publisher
            {
                Id = Guid.NewGuid(),
                Name = publisher.Name,
                Sity = publisher.Sity
            };

            // Начинает отслеживание сущности контент.
            await _publisherDbContext.Publishers.AddAsync(createPublisher);

            // Асинхронно сохраняет все изменения, внесенные в этом контексте, в основную базу данных.
            await _publisherDbContext.SaveChangesAsync();

            return ;
        }
    }
}
