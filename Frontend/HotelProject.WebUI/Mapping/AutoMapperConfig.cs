﻿using AutoMapper;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.AboutDto;
using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.LoginDto;
using HotelProject.WebUI.Dtos.RegisterDto;
using HotelProject.WebUI.Dtos.RoomDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using HotelProject.WebUI.Dtos.StaffDto;
using HotelProject.WebUI.Dtos.SubscribeDto;
using HotelProject.WebUI.Dtos.TestimonialDto;

namespace HotelProject.WebUI.Mapping
{
    public class AutoMapperConfig :Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ResultServiceDto,Service>().ReverseMap();
            CreateMap<UpdateServiceDto, Service>().ReverseMap();
            CreateMap<CreateServiceDto, Service>().ReverseMap();

            CreateMap<CreateNewUserDto, AppUser>().ReverseMap();
            CreateMap<LoginUserDto, AppUser>().ReverseMap();

            CreateMap<ResultAboutDto, About>().ReverseMap();
            CreateMap<UpdateAboutDto, About>().ReverseMap();

            CreateMap<ResultRoomDto, Room>().ReverseMap();
            CreateMap<UpdateRoomDto, Room>().ReverseMap();

            CreateMap<ResultTestimonialDto, Testimonial>().ReverseMap();
            CreateMap<UpdateTestimonialDto, Testimonial>().ReverseMap();
            CreateMap<CreateTestimonialDto, Testimonial>().ReverseMap();

            CreateMap<ResultStaffDto, Staff>().ReverseMap();

            CreateMap<CreateSubscribeDto, Subscribe>().ReverseMap();
            CreateMap<ResultSubscribeDto, Subscribe>().ReverseMap();

            CreateMap<CreateBookingDto, Booking>().ReverseMap();
            CreateMap<ResultBookingDto, Booking>().ReverseMap();
            CreateMap<ApprovedBookingDto, Booking>().ReverseMap();

            CreateMap<CreateContactDto, Contact>().ReverseMap();
        }
    }
}
