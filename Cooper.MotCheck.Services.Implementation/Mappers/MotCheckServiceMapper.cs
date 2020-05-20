using AutoMapper;
using Cooper.MotCheck.Models;
using Cooper.MotCheck.Models.Enumeration;
using Cooper.MotCheck.Services.Dto;
using System;

namespace Cooper.MotCheck.Services.Implementation.Mappers
{
    public class MotCheckServiceMapper
    {
        private readonly IMapper mapper;

        public MotCheckServiceMapper()
        {
            var mapperConfiguration = new AutoMapper.MapperConfiguration(cfg =>
            {

                cfg.CreateMap<VehicleMotStatus, MotCheckResponse>()
                    .ForMember(dst => dst.Status, map => map.MapFrom(src => Enum.Parse<MotStatus>(src.Status)));

            });
            mapper = mapperConfiguration.CreateMapper();
        }

        public MotCheckResponse ToMotCheckResponse(VehicleMotStatus source) =>
            mapper.Map<VehicleMotStatus, MotCheckResponse>(source);
    }
}
