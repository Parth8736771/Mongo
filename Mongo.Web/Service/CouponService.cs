using Mongo.Web.Models.Dtos;
using Mongo.Web.Service.IService;
using static Mongo.Web.Utility.StaticDetails;

namespace Mongo.Web.Service
{
    public class CouponService : ICouponService
    {
        private IBaseService _baseService;
        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateCouponAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.POST,
                URL = CouponBaseUrl + "/api/Coupon",
                Data = couponDto,
            });
        }

        public async Task<ResponseDto?> GetAllCouponsAsync()
        {
           return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.GET,
                URL = CouponBaseUrl + "/api/Coupon",
            });
        }

        public Task<ResponseDto?> GetCouponByCodeAsync(string code)
        {
            var responseDto = _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.GET,
                URL = CouponBaseUrl + $"/api/Coupon/GetByCode/{code}",
            });
            return responseDto;
        }

        public async Task<ResponseDto?> GetCouponByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.GET,
                URL = CouponBaseUrl + $"/api/Coupon/{id}",
            });
        }

        public async Task<ResponseDto?> UpdateCouponAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.PUT,
                URL = CouponBaseUrl + "/api/Coupon",
                Data = couponDto,
            });
            
        }
        public async Task<ResponseDto?> DeleteCouponAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.DELETE,
                URL = CouponBaseUrl + $"/api/Coupon/{id}",
            });
        }
    }
}
