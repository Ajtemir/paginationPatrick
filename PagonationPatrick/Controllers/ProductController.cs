using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagonationPatrick.Context;
using PagonationPatrick.Entities;
using PagonationPatrick.Models;

namespace PagonationPatrick.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{page:int}")]
        // [HttpGet]
        public async Task<ActionResult<List<Product>>> GetValues(int page)
        {
            if (_context.Products is null)
                return NotFound();

            var pageResults = 3f;
            var pageCount = Math.Ceiling(_context.Products.Count() / pageResults);
            var products = await _context.Products
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();
            var response = new ProductResponse
            {
                Products = products,
                CurrentPage = page,
                Pages = (int)pageCount
            };
            return Ok(products);
        }
    }
}