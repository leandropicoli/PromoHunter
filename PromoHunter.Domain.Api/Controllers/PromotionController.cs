using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PromoHunter.Domain.Commands;
using PromoHunter.Domain.Commands.PromotionCommands;
using PromoHunter.Domain.Entities;
using PromoHunter.Domain.Handlers;
using PromoHunter.Domain.Repositories;

namespace PromoHunter.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/promotions")]
    public class PromotionController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public IEnumerable<Promotion> GetPromotions(int page, int limit, [FromServices] IPromotionRepository repository)
        {
            return repository.GetPromotions(page, limit);
        }

        [Route("")]
        [HttpPost]
        public GenericCommandResult Create([FromBody] CreatePromotionCommand command, [FromServices] PromotionHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

    }
}