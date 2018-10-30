using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<MovieDto, Movie>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<MembershipTypeDto, MembershipType>();
            Mapper.CreateMap<Genre, GenreDto>();
            Mapper.CreateMap<GenreDto, Genre>();
            Mapper.CreateMap<Rental, RentalDto>();
            Mapper.CreateMap<RentalDto, Rental>();
        }
    }
}