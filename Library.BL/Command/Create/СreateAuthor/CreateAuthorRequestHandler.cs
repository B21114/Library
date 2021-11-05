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

namespace Library.BL.Command.Create.CreateAuthor
{
    public class CreateAuthorRequestHandler : IRequestHandler<CreateAuthorRequest, CreateAuthorResponse>
    {
        private readonly IDataBaseContext _dataBaseContext;
        public CreateAuthorRequestHandler(IDataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public async Task<CreateAuthorResponse> Handle(
         CreateAuthorRequest request,
         CancellationToken cancellationToken)
        {
            var author = new Author
            {
                Id = Guid.NewGuid(),
                Lastname = request.Lastname,
                Firstname = request.Firstname,
                Patronymic = request.Patronymic,
                Activity = request.Activity
            };

            // Начинает отслеживание сущности автор.
            await _dataBaseContext.Authors.AddAsync(author);

            // Асинхронно сохраняет все изменения, внесенные в этом контексте, в основную базу данных.
            await _dataBaseContext.SaveChangesAsync();

            return new CreateAuthorResponse
            {
                AuthorId = author.Id
            };
        }
    }
}
