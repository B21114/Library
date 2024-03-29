﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DL.Domain.Entities
{
    /// <summary>
    /// Класс книги.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Идентификатор книги.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Aвтор книги.
        /// </summary>
        public Author Author { get; set; }

        /// <summary>
        /// Наименование книги.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Количество страниц книги.
        /// </summary>
        public int NumberOfPages { get; set; }

        /// <summary>
        /// Издатель книги.
        /// </summary>
        public Publisher Publisher { get; set; }
    }
}
