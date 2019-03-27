using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.Application.SQLServer.Commands;
using MyFirstAPI.Application.SQLServer.Queries;
using MyFirstAPI.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFirstAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IMediator mediator;
        private IProductQueries productQueries;

        public ProductsController(IMediator mediator, IProductQueries productQueries)
        {
            this.mediator = mediator;
            this.productQueries = productQueries;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            try
            {
                IEnumerable<Product> results = await this.productQueries.GetAll();
                return this.Ok(results);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            } 
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody]CreateProductCommand createProductCommand)
        {
            try
            {
                await this.mediator.Send(createProductCommand);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
