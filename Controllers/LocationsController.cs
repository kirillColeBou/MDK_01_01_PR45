using API_Тепляков.Context;
using API_Тепляков.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis;

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
        /// <summary>
        /// Метод добавления места дислокации
        /// </summary>
        /// <param name="locations">Данные о месте дислокации</param>
        /// <returns>Статус выполнения запроса</returns>
        /// <remarks>Данный метод добавляет место дислокации в базу данных</remarks>
        [Route("Add")]
        [HttpPut]
        [ApiExplorerSettings(GroupName = "v3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult Add([FromForm] Locations locations)
        {
            try
            {
                LocationsContext locationsContext = new LocationsContext();
                locationsContext.Locations.Add(locations);
                locationsContext.SaveChanges();
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
        /// <summary>
        /// Метод обновления места дислокации
        /// </summary>
        /// <param name="id">Идентификатор места дислокации</param>
        /// <param name="locations">Данные о месте дислокации</param>
        /// <returns>Статус выполнения запроса</returns>
        /// <remarks>Данный метод обновляет информацию о месте дислокации в базе данных</remarks>
        [Route("Update")]
        [HttpPut]
        [ApiExplorerSettings(GroupName = "v3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public ActionResult Update(int id, [FromForm] Locations locations)
        {
            try
            {
                LocationsContext locationsContext = new LocationsContext();
                var findLocations = locationsContext.Locations.FirstOrDefault(x => x.Id_locations == id);
                if (findLocations != null)
                {
                    findLocations.Country = locations.Country;
                    findLocations.City = locations.City;
                    findLocations.Address = locations.Address;
                    findLocations.Square = locations.Square;
                    findLocations.Count_structures = locations.Count_structures;
                    locationsContext.SaveChanges();
                    return StatusCode(200);
                }
                else return StatusCode(401, "Место дислокации не найдено!");
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
