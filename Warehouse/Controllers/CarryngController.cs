using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Model;

namespace MyWebAPI.Controllers
{
    // Атрибут ApiController включает некоторые функции Web API
    [ApiController]
    // Атрибут Route указывает шаблон URL для контроллера
   
    public class CarryngController : ControllerBase
    {
        [Route("Add/[controller]")]
        [HttpPost]
        public IActionResult AddCarryng( int idProduct, int idWarehouse, int quanity)
        {
            // Создаем новый объект Carryng из параметров запроса
            Carryng newCarryng = new Carryng();
            newCarryng.AddNew(idProduct, idWarehouse, quanity); //С помощью методов класса Carryng добавляем в БД 
            return Ok(newCarryng);
        }
        [Route("Show/[controller]")]
        [HttpGet]
        public IActionResult Show()
        {
            Carryng newCarryng = new Carryng();
            return Ok(newCarryng.GetAll());
        }
        [Route("Delete/[controller]")]
        [HttpDelete]
        public IActionResult DeleteCarryng(int id_carryng)
        {
            Carryng newCarryng = new Carryng();
            newCarryng.DeleteById(id_carryng);
            return Ok(newCarryng.GetAll());
        }

    }
}