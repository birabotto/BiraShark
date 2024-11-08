using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("/api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public StockController(ApplicationDBContext context) 
        {
            _context = context;    
        }

        [HttpGet]
        public IActionResult getAll() 
        {
            var stocks = _context.Stock.ToList().Select(s => s.toStockDto());

            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public IActionResult getById([FromRoute] int id) 
        {
            var stock = _context.Stock.Find(id);
            if (stock == null) 
                return NotFound();

            return Ok(stock.toStockDto());
        }
    }
}