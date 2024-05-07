using API_Тепляков.Context;
using API_Тепляков.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace API_Тепляков.Controllers
{
    [Route("api/PartsController")]
    public class PartsController : Controller
    {
        /// <summary>
        /// Получение списка частей
        /// </summary>
        /// <remarks>Данный метод получает список частей, находящийся в базе данных</remarks>
        /// <response code="200">Список успешно получен</response>
        /// <response code="500">При выполнении запроса возникли ошибки</response>
        [Route("List")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Parts>), 200)]
        [ProducesResponseType(500)]
        public ActionResult List(string sortBy = "Locations")
        {
            try
            {
                IEnumerable<Parts> Parts = new PartsContext().Parts.OrderBy(x => EF.Property<object>(x, sortBy));
                return Json(Parts);
            }
            catch (Exception exp)
            {
                return StatusCode(500, exp.Message);
            }
        }
        /// <summary>
        /// Получение места дислокации
        /// </summary>
        /// <remarks>Данный метод получает место дислокации, находящееся в базе данных</remarks>
        /// <response code="200">Место дислокации успешно получено</response>
        /// <response code="500">При выполнении запроса возникли ошибки</response>
        [Route("Item")]
        [HttpGet]
        [ProducesResponseType(typeof(Parts), 200)]
        [ProducesResponseType(500)]
        public ActionResult Item(int id)
        {
            try
            {
                Parts Parts = new PartsContext().Parts.First(x => x.Id_part == id);
                return Json(Parts);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
