using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BL.Command.Read.ReadBookId
{
    /// <summary>
    /// Данные ответа на запрос.
    /// </summary>
    public class ReadBookByIdResponse
    {
        public BookDetailsDto Result { get; set; }
    }
}
