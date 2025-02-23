using Microsoft.AspNetCore.Mvc;
using Mongo.Services.CouponAPI.Models;
using Mongo.Web.Models.Dtos;
using Mongo.Web.Service.IService;
using Newtonsoft.Json;

namespace Mongo.Web.Controllers
{
    public class CouponController : Controller
    {
        private ICouponService _couponService;
        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDto?> couponListObj = new();

            ResponseDto? responseDto = await _couponService.GetAllCouponsAsync();
            if (responseDto != null && responseDto.IsSuccess) 
            {
                couponListObj = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(responseDto.Result));
            }

            return View(couponListObj);
        }

        [HttpGet]
        public async Task<IActionResult> CouponCreate()
        {
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> CouponCreate(CouponDto couponDto)
		{
			if (ModelState.IsValid)
            {
				ResponseDto? responseDto = await _couponService.CreateCouponAsync(couponDto);

				if (responseDto != null && responseDto.IsSuccess)
				{
                    return RedirectToAction(nameof(CouponIndex));
				}
			}
            return View(couponDto);
		}

        [HttpGet]
        public async Task<IActionResult> CouponDelete(int couponId)
        {
            ResponseDto? responseDto = await _couponService.GetCouponByIdAsync(couponId);

            if (responseDto != null && responseDto.IsSuccess)
            {
                CouponDto? couponObj = JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(responseDto.Result));

                return View(couponObj);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CouponDelete(CouponDto couponDto)
        {
            ResponseDto? responseDto = await _couponService.DeleteCouponAsync(couponDto.CouponId);

            if (responseDto != null && responseDto.IsSuccess)
            {
                return RedirectToAction(nameof(CouponIndex));
            }

            return View(couponDto);
        }

    }
}
