﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BL.Command.Delete.DeleteBook
{
    /// <summary>
    /// DTO книги.
    /// </summary>
    public class DeleteBookResponse
    {
        /// <summary>
        /// Cтатус удаления
        /// </summary>
        public bool Deleted { get; set; }
    }
}
