using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BL.Command.Read.ReadBookId
{
    /// <summary>
    /// Данные запроса на получения публикации по Id.
    /// </summary>
    public class ReadBookByIdRequest: IRequest<ReadBookByIdResponse>
    {
        public Guid Id { get; set; } = default;
    }
}
