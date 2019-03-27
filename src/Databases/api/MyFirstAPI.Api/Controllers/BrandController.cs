using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.Application.MongoDB.Commands;
using MyFirstAPI.Application.MongoDB.Queries;
using MyFirstAPI.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFirstAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private IMediator mediator;
        private IBrandQueries brandQueries;

        public BrandController(IMediator mediator, IBrandQueries brandQueries)
        {
            this.mediator = mediator;
            this.brandQueries = brandQueries;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Brand>> Get()
        {
            try
            {
                IEnumerable<Brand> results = this.brandQueries.GetAll();
                return this.Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody]CreateBrandCommand createBrandCommand)
        {
            try
            {
                await this.mediator.Send(createBrandCommand);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
