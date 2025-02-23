using AutoMapper;
using Mongo.Services.CouponAPI.Models;
using Mongo.Services.CouponAPI.Models.Dtos;

namespace Mongo.Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Coupon, CouponDto>();
                config.CreateMap<CouponDto, Coupon>();
            });

            return mappingConfig;
        }
    }
}
