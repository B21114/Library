using AutoMapper;
using Library.DL.Domain;
using Library.DL.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.BL.Command.Read
{
    public class ReadBook
    {
        private readonly IBookDbContext _bookDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private IMapper _mapper;

        /// <summary>
        /// Конструтктор обработчиков запроса публикаций.
        /// </summary>
        /// <param name="contentDbContext">Контекст базы данных предоставляющий контент.</param>
        /// <param name="httpContextAccessor">Предоставляет доступ к текущему пользователю, если он доступен.</param>
        /// <param name="mapper">Маппер.</param>
        public ReadBook(IBookDbContext booktDbContext, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _bookDbContext = booktDbContext;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }


        public async Task<ReadBook> Handle(BookDTO book, CancellationToken cancellationToken)
        {
            var contentEntity = await _bookDbContext.Books.FindAsync(book.Id);

            return new BookDTO
        /*   {
                Result = _mapper.Map<PublicationDetailsDto>(contentEntity)
            };*/
        }
    }
