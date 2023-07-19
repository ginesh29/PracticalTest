using AutoMapper;
using PracticalTest.Entities;
using PracticalTest.ViewModels;

namespace PracticalTest
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<FriendViewModel, Friend>();
            CreateMap<Friend, FriendViewModel>();
        }
    }
}
