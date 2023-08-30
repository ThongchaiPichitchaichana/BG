using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DatabaseContext;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FoodSalesController : ControllerBase
    {
        private readonly MyDBContext _context;
        public FoodSalesController(MyDBContext context)
        {
            _context = context;
        }
        [HttpGet(Name = "GetFoodsales")]
        public async Task<IActionResult> GetFoodsales()
        {
            var a = from o in _context.Orders
                    join p in _context.Products on o.ProductId equals p.Id
                    join r in _context.regions on o.RegionId equals r.Id
                    join c in _context.cities on o.CityId equals c.Id
                    select 
                    new
                    {
                        OrderDate = o.OrderDate,
                        Region = r.RegionName,
                        City = c.CityName,
                        Category= p.Category,
                        Product = p.ProductName,
                        Quantity =  o.Quantity,
                        UnitPrice = p.UnitPrice,
                        TotalPrice = o.Quantity * p.UnitPrice
                    };
                  
            return Ok(a);

        }

        [HttpPost]
        public async Task<IActionResult> SearchbyColumn(string? RegionName,string? CityName ,string? Category ,string? ProductName )
        {

            var a = from o in _context.Orders
                    join p in _context.Products on o.ProductId equals p.Id
                    join r in _context.regions on o.RegionId equals r.Id
                    join c in _context.cities on o.CityId equals c.Id
                    where 
                         r.RegionName == RegionName ||
                         c.CityName == CityName ||
                        p.Category == Category ||
                        p.ProductName == ProductName 
                
                    select
                    new
                    {
                        OrderDate = o.OrderDate,
                        Region = r.RegionName,
                        City = c.CityName,
                        Category = p.Category,
                        Product = p.ProductName,
                        Quantity = o.Quantity,
                        UnitPrice = p.UnitPrice,
                        TotalPrice = o.Quantity * p.UnitPrice
                    };

            return Ok(a);
        }
        [HttpPost]
        public async Task<IActionResult> SearchbyDate(string startdate , string enddate)
        {
            DateTime dtFrom = Convert.ToDateTime(startdate);
            DateTime dtTo = Convert.ToDateTime(enddate);
            var a = from o in _context.Orders
                    join p in _context.Products on o.ProductId equals p.Id
                    join r in _context.regions on o.RegionId equals r.Id
                    join c in _context.cities on o.CityId equals c.Id
                    where o.OrderDate >= dtFrom && o.OrderDate <=  dtTo


                    select
                    new
                    {
                        OrderDate = o.OrderDate,
                        Region = r.RegionName,
                        City = c.CityName,
                        Category = p.Category,
                        Product = p.ProductName,
                        Quantity = o.Quantity,
                        UnitPrice = p.UnitPrice,
                        TotalPrice = o.Quantity * p.UnitPrice
                    };

            return Ok(a);
        }

       



    }

}
