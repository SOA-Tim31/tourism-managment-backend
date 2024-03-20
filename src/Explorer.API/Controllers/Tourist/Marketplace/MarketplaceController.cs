using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Payments.API.Dtos.ShoppingCartDtos;
using Explorer.Payments.API.Public.ShoppingCart;
using Explorer.Payments.Core.Domain.ShoppingCarts;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Administration;
using Explorer.Tours.Core.UseCases.Administration;
using Explorer.Tours.Core.UseCases.Marketplace;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist.Marketplace
{

    //[Authorize(Policy = "touristPolicy")]
    [Route("api/marketplace")]
    public class MarketplaceController : BaseApiController
    {
        private readonly ITourService _tourService;
        private readonly ITourPointService _tourPointService;
        private readonly IShoppingCartService _shoppingCartService;
        public MarketplaceController(ITourService tourService, ITourPointService tourPointService, IShoppingCartService shoppingCartService)
        {
            _tourService = tourService;
            _tourPointService = tourPointService;
            _shoppingCartService = shoppingCartService;
        }

        [HttpGet]
        public ActionResult<PagedResult<TourDTO>> GetAll()
        {
           var result = _tourService.GetPublished();
           foreach(var tour in result.Value.Results)
           {
              var tourPoints = _tourPointService.GetTourPointsByTourId(tour.Id);
               tour.TourPoints = tourPoints.Value.Results;
           }
           return CreateResponse(result);
        }

        [HttpPut("buy")]
        public ActionResult<ShoppingCartDto> Buy([FromBody] ShoppingCartDto cart)
        {
                var result = _shoppingCartService.Buy(cart);
                return CreateResponse(result);
        }


        [HttpGet("{tourId:int}")]

        public ActionResult<List<TourPointDto>> GetFirstTourPointByTourId(int tourId)
        {
            var result = _tourPointService.GetFirstTourPoint(tourId);
            return CreateResponse(result);
        }



        [HttpGet("selectedTour/{tourId:int}")]

        public ActionResult<TourDTO> Get([FromRoute] int tourId)
        {
           var result = _tourService.Get(tourId);
            var tourPoints = _tourPointService.GetTourPointsByTourId(result.Value.Id);
           result.Value.TourPoints = tourPoints.Value.Results;
            return CreateResponse(result);
        }

    }
}
