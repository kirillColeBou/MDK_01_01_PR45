using API_Тепляков.Context;
using API_Тепляков.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace API_Тепляков.Controllers
{
    [Route("api/LocationsController")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class LocationsController : Controller
    {
        /// <summary>
        /// Получение списка мест дислокации
        /// </summary>
        /// <remarks>Данный метод получает список мест дислокации, находящийся в базе данных</remarks>
        /// <response code="200">Список успешно получен</response>
        /// <response code="500">При выполнении запроса возникли ошибки</response>
        [Route("List")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Locations>), 200)]
        [ProducesResponseType(500)]
        public ActionResult List(string sortBy = "City")
        {
            try
            {
                IEnumerable<Locations> Locations = new LocationsContext().Locations.OrderBy(x => EF.Property<object>(x, sortBy));
                return Json(Locations);
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
        [ProducesResponseType(typeof(Locations), 200)]
        [ProducesResponseType(500)]
        public ActionResult Item(int id)
        {
            try
            {
                Locations Locations = new LocationsContext().Locations.First(x => x.Id_locations == id);
                return Json(Locations);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
