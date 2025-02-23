using Mongo.Web.Models.Dtos;

namespace Mongo.Web.Service.IService
{
    public interface ICouponService
    {
        Task<ResponseDto?> GetCouponByCodeAsync(string code);
        Task<ResponseDto?> GetAllCouponsAsync();
        Task<ResponseDto?> GetCouponByIdAsync(int id);
        Task<ResponseDto?> UpdateCouponAsync(CouponDto couponDto);
        Task<ResponseDto?> CreateCouponAsync(CouponDto couponDto);
        Task<ResponseDto?> DeleteCouponAsync(int id);
    }
}
