using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BL.Command.Create.CreatePublisher
{
    /// <summary>
    /// DTO издателя.
    /// </summary>
    public class CreatePublisherRequest : IRequest<CreatePublisherResponse>
    {

        /// <summary>
        /// Наименование издателя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Город издателя.
        /// </summary>
        public string Sity { get; set; }
    }
}
