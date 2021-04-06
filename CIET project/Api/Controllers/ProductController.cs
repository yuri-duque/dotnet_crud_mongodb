using Api.ViewModels;
using Aplication.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;


        public ProductController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var products = await _productService.GetAll();

                var productsViewModel = _mapper.Map<IList<ProductListViewModel>>(products);

                var result = new Result("Products founded with sucssess!", productsViewModel);

                return Ok(result);
            }
            catch (ResultException ex) // custom return exceptions
            {
                return ex.GetReturn();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                var product = await _productService.GetById(id);

                var productViewModel = _mapper.Map<ProductViewModel>(product);

                var result = new Result("Product founded with sucssess!", productViewModel);

                return Ok(result);
            }
            catch (ResultException ex) // custom return exceptions
            {
                return ex.GetReturn();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductInsertViewModel productViewModel)
        {
            try
            {
                var product = _mapper.Map<Product>(productViewModel);

                product = await _productService.Insert(product);

                var result = new Result("Product inserted with sucssess!", productViewModel);

                return Ok(result);
            }
            catch (ResultException ex) // custom return exceptions
            {
                return ex.GetReturn();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] ProductUpdateViewModel productViewModel)
        {
            try
            {
                var product = _mapper.Map<Product>(productViewModel);

                product = await _productService.Update(id, product);

                var result = new Result("Product updated with sucssess!", productViewModel);

                return Ok(result);
            }
            catch (ResultException ex) // custom return exceptions
            {
                return ex.GetReturn();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _productService.Delete(id);

                var result = new Result("Product deleted with sucssess!");

                return Ok(result);
            }
            catch (ResultException ex) // custom return exceptions
            {
                return ex.GetReturn();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
