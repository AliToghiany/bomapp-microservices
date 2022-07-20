using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Discount.Grpc.Entities;
using Discount.Grpc.Protos;
using Discount.Grpc.Repositories.Interface;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace Discount.Grpc.Services
{
    public class DiscountService:DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly IDiscountRipository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<DiscountService> _logger;

        public DiscountService(IDiscountRipository repository, IMapper mapper, ILogger<DiscountService> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var coupon = await _repository.GetDiscount(request.Productid);
            if (coupon==null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"not found Coupon for product with id{request.Productid}"));
            }
            _logger.LogInformation("Discount is retrieved for ProductName : {productName}, Amount : {amount}", coupon.ProductName, coupon.Amount);
            var couponmodel = _mapper.Map<CouponModel>(coupon);
            return couponmodel;
        }
        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var coupon = _mapper.Map<Coupon>(request.Coupon);

            await _repository.CreateDiscount(coupon);
            _logger.LogInformation("Discount is successfully created. ProductName : {ProductName}", coupon.ProductName);

            var couponModel = _mapper.Map<CouponModel>(coupon);
            return couponModel;
        }
        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var coupon = _mapper.Map<Coupon>(request.Coupon);
             await _repository.UpdateDiscount(coupon);
            _logger.LogInformation($"copoun wih product id:{coupon.ProductId} has been updated");
            return _mapper.Map<CouponModel>(coupon);
        }
        public override async Task<DeleteResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            bool res = await _repository.DeleteDiscount(request.ProductId);
            if (res)
            {
                _logger.LogInformation($"copoun wih product id:{request.ProductId} has been Deleted");
            }
            
            return new DeleteResponse
            {
                IsSucsses = res
        };
        }

    }
}
