using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mongo.Services.CouponAPI.Data;
using Mongo.Services.CouponAPI.Models;
using Mongo.Services.CouponAPI.Models.Dtos;

namespace Mongo.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ResponseDto responseDto;
        private IMapper _mapper;
        public CouponController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            responseDto = new ResponseDto();
            _mapper = mapper;
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Coupon> objList = _context.Coupons.ToList();
                responseDto.Result = _mapper.Map<IEnumerable<CouponDto>>(objList);
            }
            catch(Exception ex)
            {
                responseDto.IsSuccess = false;
                responseDto.Message = ex.Message;
            }
            return responseDto;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Coupon obj = _context.Coupons.First(c => c.CouponId == id);
                responseDto.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                responseDto.IsSuccess = false;
                responseDto.Message = ex.Message;
            }
            return responseDto;
        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDto GetByCode(string code)
        {
            try
            {
                Coupon obj = _context.Coupons.First(c => c.CouponCode == code);
                responseDto.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                responseDto.IsSuccess = false;
                responseDto.Message = ex.Message;
            }
            return responseDto;
        }

        [HttpPost]
        public ResponseDto Post([FromBody] CouponDto couponDto)
        {
            try
            {
                var couponObj = _mapper.Map<Coupon>(couponDto);
                _context.Coupons.Add(couponObj);
                _context.SaveChanges();
                responseDto.Result = _mapper.Map<CouponDto>(couponObj);
            }
            catch (Exception ex)
            {
                responseDto.IsSuccess = false;
                responseDto.Message = ex.Message;
            }
            return responseDto;
        }

        [HttpPut]
        public ResponseDto Put([FromBody] CouponDto couponDto)
        {
            try
            {
                var couponObj = _mapper.Map<Coupon>(couponDto);
                _context.Coupons.Update(couponObj);
                _context.SaveChanges();
                responseDto.Result = _mapper.Map<CouponDto>(couponObj);
            }
            catch (Exception ex)
            {
                responseDto.IsSuccess = false;
                responseDto.Message = ex.Message;
            }
            return responseDto;
        }

        [HttpDelete]
        [Route("{id}")]
        public ResponseDto Delete(int id)
        {
            try
            {
                var couponObj = _context.Coupons.First(c => c.CouponId == id);
                _context.Coupons.Remove(couponObj);
                _context.SaveChanges();
                responseDto.Result = _mapper.Map<CouponDto>(couponObj);
            }
            catch (Exception ex)
            {
                responseDto.IsSuccess = false;
                responseDto.Message = ex.Message;
            }
            return responseDto;
        }
    }
}
