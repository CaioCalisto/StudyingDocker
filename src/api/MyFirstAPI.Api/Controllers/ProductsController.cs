using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.Application.SQLServer.Commands;
using MyFirstAPI.Domain;
using MyFirstAPI.Domain.Ports;
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
        private IProductRepository productRepository;

        public ProductsController(IMediator mediator, IProductRepository productRepository)
        {
            this.mediator = mediator;
            this.productRepository = productRepository;
        }

        [HttpGet("sqlserver")]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return this.Ok(this.productRepository.GetAllAsync());
        }

        [HttpPost("sqlserver")]
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
