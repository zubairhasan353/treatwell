using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using treatwell.Models;
using treatwell.Dtos;

namespace treatwell.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Venues, VenuesDto>();
            Mapper.CreateMap<VenuesDto, Venues>().ForMember(dto => dto.Id, options => options.Ignore());

            Mapper.CreateMap<VenueServices, VenueServicesDto>();
            Mapper.CreateMap<VenueServicesDto, VenueServices>().ForMember(dto => dto.Id, options => options.Ignore());

            Mapper.CreateMap<SubCategories, SubCategoriesDto>();
            Mapper.CreateMap<SubCategoriesDto, SubCategories>().ForMember(dto => dto.Id, options => options.Ignore());


            Mapper.CreateMap<ApplicationUser, ApplicationUserDto>();
            Mapper.CreateMap<ApplicationUserDto, ApplicationUser>().ForMember(dto => dto.Id, options => options.Ignore());

            Mapper.CreateMap<UserVenues, UserVenuesDto>();
            Mapper.CreateMap<UserVenuesDto, UserVenues>().ForMember(dto => dto.Id, options => options.Ignore());

            Mapper.CreateMap<Cities, CitiesDto>();
            Mapper.CreateMap<CitiesDto, Cities>().ForMember(dto => dto.Id, options => options.Ignore());

            Mapper.CreateMap<VenueServices, AppVenueServicesDtos>();
            Mapper.CreateMap<AppVenueServicesDtos, VenueServices>().ForMember(dto => dto.Id, options => options.Ignore());

            Mapper.CreateMap<Categories, CategoriesDto>();
            Mapper.CreateMap<CategoriesDto, Categories>().ForMember(dto => dto.Id, options => options.Ignore());

            Mapper.CreateMap<CustomerBooking, CustomerBookingDto>();
            Mapper.CreateMap<CustomerBookingDto, CustomerBooking>().ForMember(dto => dto.Id, options => options.Ignore());

            Mapper.CreateMap<VenueImages, VenueImagesDto>();
            Mapper.CreateMap<VenueImagesDto, VenueImages>().ForMember(dto => dto.Id, options => options.Ignore());

            Mapper.CreateMap<CustomerReviews, CustomerReviewsDto>();
            Mapper.CreateMap<CustomerReviewsDto, CustomerReviews>().ForMember(dto => dto.Id, options => options.Ignore());

            Mapper.CreateMap<Days, DaysDto>();
            Mapper.CreateMap<DaysDto, Days>().ForMember(dto => dto.Id, options => options.Ignore());

            Mapper.CreateMap<BookingDaysTime, BookingDaysTimeDto>();
            Mapper.CreateMap<BookingDaysTimeDto, BookingDaysTime>().ForMember(dto => dto.Id, options => options.Ignore());
        }
    }
}