using API_Тепляков.Context;
using API_Тепляков.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace API_Тепляков.Controllers
{
    [Route("api/CompaniesController")]
    public class CompaniesController : Controller
    {
        /// <summary>
        /// Получение списка рот
        /// </summary>
        /// <remarks>Данный метод получает список рот, находящийся в базе данных</remarks>
        /// <response code="200">Список успешно получен</response>
        /// <response code="500">При выполнении запроса возникли ошибки</response>
        [Route("List")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Companies>), 200)]
        [ProducesResponseType(500)]
        public ActionResult List(string sortBy = "Name_companies")
        {
            try
            {
                IEnumerable<Companies> Companies = new CompaniesContext().Companies.OrderBy(x => EF.Property<object>(x, sortBy));
                return Json(Companies);
            }
            catch (Exception exp)
            {
                return StatusCode(500, exp.Message);
            }
        }
        /// <summary>
        /// Получение роты
        /// </summary>
        /// <remarks>Данный метод получает роту, находящуюся в базе данных</remarks>
        /// <response code="200">Рота успешно получена</response>
        /// <response code="500">При выполнении запроса возникли ошибки</response>
        [Route("Item")]
        [HttpGet]
        [ProducesResponseType(typeof(Companies), 200)]
        [ProducesResponseType(500)]
        public ActionResult Item(int id)
        {
            try
            {
                Companies Companies = new CompaniesContext().Companies.First(x => x.Id_companies == id);
                return Json(Companies);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
