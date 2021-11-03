using AutoMapper;
using Library.DL.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.BL.Command.Read.ReadBookId
{
    /// <summary>
    /// Данные запроса на получения обработчиком публикации по Id.
    /// </summary>
    public class ReadBookByIdRequestHandler : IRequestHandler<ReadBookByIdRequest, ReadBookByIdResponse>
    {
        private readonly IBookDbContext _bookDbContext;
        private IMapper _mapper;

        /// <summary>
        /// Конструтктор обработчиков запроса публикаций.
        /// </summary>
        /// <param name="contentDbContext">Контекст базы данных предоставляющий контент.</param>
        /// <param name="httpContextAccessor">Предоставляет доступ к текущему пользователю, если он доступен.</param>
        /// <param name="mapper">Маппер.</param>
        public ReadBookByIdRequestHandler(IBookDbContext bookDbContext, IMapper mapper)
        {
            _bookDbContext = bookDbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Поток обрабатывает запрос, отвечает значением типа ReadBookByIdResponse,
        /// запрашивает тип ReadBookByIdRequest.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">Объект для наблюдения за ожиданием завершения задачи.</param>
        /// <returns></returns>
        public async Task<ReadBookByIdResponse> Handle(ReadBookByIdRequest request, CancellationToken cancellationToken)
        {
            var contentEntity = await _bookDbContext.Books.FindAsync(request.Id);

            return new ReadBookByIdResponse
            {
                Result = _mapper.Map<BookDetailsDto>(contentEntity)
            };
        }
    }
}
