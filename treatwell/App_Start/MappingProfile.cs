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
            CreateMap<Venues, VenuesDto>();
            CreateMap<VenuesDto, Venues>().ForMember(dto => dto.Id, options => options.Ignore());

            CreateMap<VenueServices, VenueServicesDto>();
            CreateMap<VenueServicesDto, VenueServices>().ForMember(dto => dto.Id, options => options.Ignore());

            CreateMap<SubCategories, SubCategoriesDto>();
            CreateMap<SubCategoriesDto, SubCategories>().ForMember(dto => dto.Id, options => options.Ignore());


            CreateMap<ApplicationUser, ApplicationUserDto>();
            CreateMap<ApplicationUserDto, ApplicationUser>().ForMember(dto => dto.Id, options => options.Ignore());

            CreateMap<UserVenues, UserVenuesDto>();
            CreateMap<UserVenuesDto, UserVenues>().ForMember(dto => dto.Id, options => options.Ignore());

            CreateMap<Cities, CitiesDto>();
            CreateMap<CitiesDto, Cities>().ForMember(dto => dto.Id, options => options.Ignore());

            CreateMap<VenueServices, AppVenueServicesDtos>();
            CreateMap<AppVenueServicesDtos, VenueServices>().ForMember(dto => dto.Id, options => options.Ignore());

            CreateMap<Categories, CategoriesDto>();
            CreateMap<CategoriesDto, Categories>().ForMember(dto => dto.Id, options => options.Ignore());

            CreateMap<CustomerBooking, CustomerBookingDto>();
            CreateMap<CustomerBookingDto, CustomerBooking>().ForMember(dto => dto.Id, options => options.Ignore());

            CreateMap<VenueImages, VenueImagesDto>();
            CreateMap<VenueImagesDto, VenueImages>().ForMember(dto => dto.Id, options => options.Ignore());

            CreateMap<CustomerReviews, CustomerReviewsDto>();
            CreateMap<CustomerReviewsDto, CustomerReviews>().ForMember(dto => dto.Id, options => options.Ignore());

            CreateMap<Days, DaysDto>();
            CreateMap<DaysDto, Days>().ForMember(dto => dto.Id, options => options.Ignore());

            CreateMap<BookingDaysTime, BookingDaysTimeDto>();
            CreateMap<BookingDaysTimeDto, BookingDaysTime>().ForMember(dto => dto.Id, options => options.Ignore());
        }
    }
}