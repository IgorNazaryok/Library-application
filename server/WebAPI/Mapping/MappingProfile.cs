﻿using AutoMapper;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;


namespace WebAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDTO>()
                .ForMember(dto => dto.Authors, opt => opt.MapFrom(
                    route => route.BookAuthor.ToList().Select(
                        el => new AuthorDTO
                        {
                            Id = el.Author.Id,
                            FullName = el.Author.FullName
                        })
                    )
                );
            CreateMap<BookDTO, Book>();

            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<Author, AuthorDTO>();
            CreateMap<AuthorDTO, Author>();




        }
    }
}
