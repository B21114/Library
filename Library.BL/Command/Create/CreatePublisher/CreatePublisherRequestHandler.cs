﻿using Library.DL.Domain;
using Library.DL.Domain.Entities;
using Library.DL.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.BL.Command.Create.CreatePublisher
{
    public class CreatePublisherRequestHandler : IRequestHandler<CreatePublisherRequest, CreatePublisherResponse>
    {

        private readonly IDataBaseContext _dataBaseContext;
        public CreatePublisherRequestHandler(IDataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public async Task<CreatePublisherResponse> Handle(
         CreatePublisherRequest request,
         CancellationToken cancellationToken)
        {
            var publisher = new Publisher
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Sity = request.Sity
            };

            // Начинает отслеживание сущности контент.
            await _dataBaseContext.Publishers.AddAsync(publisher);

            // Асинхронно сохраняет все изменения, внесенные в этом контексте, в основную базу данных.
            await _dataBaseContext.SaveChangesAsync();

            // Возвращает CreatePublisherResponse с Id новой записи.
            return new CreatePublisherResponse
            {
                PublisherId = publisher.Id
            };
        }
    }
}
