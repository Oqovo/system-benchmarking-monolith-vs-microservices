﻿using DistanceService.Requests;
using DistanceService.Responses;
using DistanceService.Services;

using Microsoft.AspNetCore.Mvc;

namespace DistanceService.Controllers
{
    [ApiController]
    public class DistanceController : ControllerBase
    {
        private readonly SphericalDistanceService _sphericalDistanceService;

        public DistanceController(SphericalDistanceService sphericalDistanceService)
        {
            _sphericalDistanceService = sphericalDistanceService;
        }

        [Route("api/distance")]
        [HttpPost]
        public IActionResult Distance(DistanceRequest req)
        {
            var points = DistanceRequest.DtoToEntityMapper(req);

            var point1 = points[0];
            var point2 = points[1];

            var distance = _sphericalDistanceService.CalculateDistance(point1.Latitude, point1.Longitude, point2.Latitude, point2.Longitude);

            return Ok(DistanceResponse.EntityToDtoMapper(distance));
        }
    }
}
