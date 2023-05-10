using Microsoft.AspNetCore.Mvc;
using Warehouse.Model;

namespace Warehouse.Controllers
{
    // Атрибут ApiController включает некоторые функции Web API
    [ApiController]
    // Атрибут Route указывает шаблон URL для контроллера
    
    public class SalesController : ControllerBase
    {
        [Route("Add/[controller]")]
        [HttpPost]
        public IActionResult AddSales(int idProduct, int idWarehouse, int quanity)
        {
            // Создаем новый объект Sales из параметров запроса
            Sales newSales = new Sales();
            newSales.AddNew(idProduct, idWarehouse, quanity); //С помощью методов класса Sales добавляем в БД 
            return Ok(newSales);
        }
        [Route("Show/[controller]")]
        [HttpGet]
        public IActionResult Show()
        {
            Sales newSales = new Sales();
            return Ok(newSales.GetAll());
        }
        [Route("Delete/[controller]")]
        [HttpDelete]
        public IActionResult DeleteCarryng(int id_sales)
        {
            Sales newSales = new Sales();
            newSales.DeleteById(id_sales);
            return Ok(newSales.GetAll());
        }

    }
}

