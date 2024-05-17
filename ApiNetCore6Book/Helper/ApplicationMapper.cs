using ApiNetCore6Book.Data;
using ApiNetCore6Book.Models;
using AutoMapper;

namespace ApiNetCore6Book.Helper
{
    public class ApplicationMapper:Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Bookk, BookModel>().ReverseMap();
        }
    }
}
