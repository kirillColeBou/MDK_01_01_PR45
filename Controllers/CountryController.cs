using API_Тепляков.Context;
using API_Тепляков.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace API_Тепляков.Controllers
{
    [Route("api/CountryController")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class CountryController : Controller
    {
        /// <summary>
        /// Получение списка страны
        /// </summary>
        /// <remarks>Данный метод получает список рот, находящийся в базе данных</remarks>
        /// <response code="200">Список успешно получен</response>
        /// <response code="500">При выполнении запроса возникли ошибки</response>
        [Route("List")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Country>), 200)]
        [ProducesResponseType(500)]
        public ActionResult List(string sortBy = "Name")
        {
            try
            {
                IEnumerable<Country> Country = new CountryContext().Country.OrderBy(x => EF.Property<object>(x, sortBy));
                return Json(Country);
            }
            catch (Exception exp)
            {
                return StatusCode(500, exp.Message);
            }
        }
        /// <summary>
        /// Получение страны
        /// </summary>
        /// <remarks>Данный метод получает страну, находящуюся в базе данных</remarks>
        /// <response code="200">Страна успешно получена</response>
        /// <response code="500">При выполнении запроса возникли ошибки</response>
        [Route("Item")]
        [HttpGet]
        [ProducesResponseType(typeof(Country), 200)]
        [ProducesResponseType(500)]
        public ActionResult Item(int id)
        {
            try
            {
                Country Country = new CountryContext().Country.First(x => x.Id == id);
                return Json(Country);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
