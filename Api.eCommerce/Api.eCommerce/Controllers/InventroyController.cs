using Api.eCommerce.EC;
using Csharp_project1.Models;
using Library.eCommerce.DTO;
using Library.eCommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.eCommerce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly ILogger<InventoryController> _logger;

        public InventoryController(ILogger<InventoryController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Item?> Get()
        {
            return new InventoryEC().Get();
        }

        [HttpGet("{id}")]
        public Item? GetById(int id)
        {
            return new InventoryEC().Get()
                .FirstOrDefault(i => i?.Id == id);
        }

        [HttpDelete("Delete/{id}")]
        public Item? Delete(int id)
        {
            return new InventoryEC().Delete(id);
        }

        //[Http("Edit/{id}")]
        //public Item? Edit(int id, string name, int quant, double price)
        //{
        //    return new InventoryEC().Edit(id, name, quant, price);
        //}


        //[Http("Add/{id}")]
        //public Item? Add(int id, string name, int quant, double price)
        //{
        //    return new InventoryEC().Edit(id, name, quant, price);
        //}

    }
}
