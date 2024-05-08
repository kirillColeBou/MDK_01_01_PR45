using API_Тепляков.Context;
using API_Тепляков.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace API_Тепляков.Controllers
{
    [Route("api/Type_of_troopsController")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class Type_of_troopsController : Controller
    {
        /// <summary>
        /// Получение списка видов войск
        /// </summary>
        /// <remarks>Данный метод получает список видов войск, находящийся в базе данных</remarks>
        /// <response code="200">Список успешно получен</response>
        /// <response code="500">При выполнении запроса возникли ошибки</response>
        [Route("List")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Type_of_troops>), 200)]
        [ProducesResponseType(500)]
        public ActionResult List(string sortBy = "Name_type_of_troops")
        {
            try
            {
                IEnumerable<Type_of_troops> Type_of_troops = new Type_of_troopsContext().Type_of_troops.OrderBy(x => EF.Property<object>(x, sortBy));
                return Json(Type_of_troops);
            }
            catch (Exception exp)
            {
                return StatusCode(500, exp.Message);
            }
        }
        /// <summary>
        /// Получение вида войск
        /// </summary>
        /// <remarks>Данный метод получает вид войск, находящегося в базе данных</remarks>
        /// <response code="200">Вид войск успешно получен</response>
        /// <response code="500">При выполнении запроса возникли ошибки</response>
        [Route("Item")]
        [HttpGet]
        [ProducesResponseType(typeof(Type_of_troops), 200)]
        [ProducesResponseType(500)]
        public ActionResult Item(int id)
        {
            try
            {
                Type_of_troops Type_of_troops = new Type_of_troopsContext().Type_of_troops.First(x => x.Id_type_of_troops == id);
                return Json(Type_of_troops);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
