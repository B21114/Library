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
                .ForMember(dto => dto.Id, o2 => o2.MapFrom(o3 => o3.Id))
                .ForMember(dto => dto.Name, o2 => o2.MapFrom(o3 => o3.Name))
                .ForMember(dto => dto.NumberOfPages, o2 => o2.MapFrom(o3 => o3.NumberOfPages))
                .ForMember(
                    destinationMember: dto => dto.AuthorFullInfo,
                    memberOptions: o2 => o2.MapFrom(o3 => string.Join(
                        " ",
                        o3.Author.Count
                   //     o3.Author.Lastname,
                   //     o3.Author.Firstname,
                   //     o3.Author.Patronymic
                        )))
                .ForMember(
                    destinationMember: dto => dto.PublisherFullInfo,
                    memberOptions: o2 => o2.MapFrom(o3 => string.Join(
                        " ",
                        o3.Publisher.Id,
                        o3.Publisher.Name,
                        o3.Publisher.Sity)));
        }
    }
}
