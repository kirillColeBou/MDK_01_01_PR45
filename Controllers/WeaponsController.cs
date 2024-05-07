using API_Тепляков.Context;
using API_Тепляков.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace API_Тепляков.Controllers
{
    [Route("api/WeaponsController")]
    public class WeaponsController : Controller
    {
        /// <summary>
        /// Получение списка вооружений
        /// </summary>
        /// <remarks>Данный метод получает список вооружений, находящийся в базе данных</remarks>
        /// <response code="200">Список успешно получен</response>
        /// <response code="500">При выполнении запроса возникли ошибки</response>
        [Route("List")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Weapons>), 200)]
        [ProducesResponseType(500)]
        public ActionResult List(string sortBy = "Name_weapons")
        {
            try
            {
                IEnumerable<Weapons> Weapons = new WeaponsContext().Weapons.OrderBy(x => EF.Property<object>(x, sortBy));
                return Json(Weapons);
            }
            catch (Exception exp)
            {
                return StatusCode(500, exp.Message);
            }
        }
        /// <summary>
        /// Получение вооружения
        /// </summary>
        /// <remarks>Данный метод получает вооружение, находящегося в базе данных</remarks>
        /// <response code="200">Вооружение успешно получено</response>
        /// <response code="500">При выполнении запроса возникли ошибки</response>
        [Route("Item")]
        [HttpGet]
        [ProducesResponseType(typeof(Weapons), 200)]
        [ProducesResponseType(500)]
        public ActionResult Item(int id)
        {
            try
            {
                Weapons Weapons = new WeaponsContext().Weapons.First(x => x.Id_weapons == id);
                return Json(Weapons);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
