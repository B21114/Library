using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Library.BL.Querises.ReadBookById;
using Library.DL.Domain.Entities;

namespace Library.BL.Mapping
{
    public class BookProfile : Profile
    {
        /// <summary>
        /// Конструктор публичного экземпляра.
        /// </summary>
        public BookProfile()
        {
              CreateMap<Book, BookDetailsDto>()
                     .ForMember(
                     destinationMember: dto => dto.BookFullInfo,
                     memberOptions: o2 => o2.MapFrom(o3 => string.Join(
                          " ",
                          "Book =",
                         $"Id = {o3.Id},",
                         $"Name = {o3.Name},",
                         $"NumberOfPages = {o3.NumberOfPages},"
                          )))
                  .ForMember(
                     destinationMember: dto => dto.AuthorFullInfo,
                     memberOptions: o2 => o2.MapFrom(o3 => string.Join(
                          " ",
                          "Author =",
                         $"Patronomic = {o3.Author.Id},",
                         $"Lastname = {o3.Author.Lastname},",
                         $"Firstname = {o3.Author.Firstname},",
                         $"Patronomic = {o3.Author.Patronymic},",
                         $"Activity = {o3.Author.Activity}"

                          )))
                  .ForMember(
                      destinationMember: dto => dto.PublisherFullInfo,
                      memberOptions: o2 => o2.MapFrom(o3 => string.Join(
                          " ",
                          "Publisher =",
                          $"Id = {o3.Publisher.Id}",
                          $"Name = {o3.Publisher.Name},",
                          $"Sity = {o3.Publisher.Sity}")));
        }
    }
}
