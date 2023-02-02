using AutoMapper;
using OrderAPI.Dto;
using OrderAPI.Models;
using System.Collections.Concurrent;

namespace OrderAPI.Helper

{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Customer, CustomerDTO>();
        }
    }
}
