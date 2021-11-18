using EntityFramework.Data;
using EntityFramework.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDBContext _applicationDBContext;


        public ProductsController(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        [Route(template: "List")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public List<Product> GetList()
        {
           var test = _applicationDBContext.Products.ToList();
            foreach (var item in test)
            {
                
            //_applicationDBContext.Categories.FirstOrDefault(x=>x.Id == item.Id)
                var category =  item.Category.Name;
            }
            var products = _applicationDBContext.Products.Include(x => x.Category).ToList();
            var chair = new Product { Name = "Chair", Price = 100 };
            var desk = new Product { Name = "Desk", Price = 50 };

            return new List<Product> { chair, desk };
        }
    }
}
