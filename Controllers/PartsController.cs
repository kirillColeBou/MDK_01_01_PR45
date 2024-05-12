﻿using API_Тепляков.Context;
using API_Тепляков.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace API_Тепляков.Controllers
{
    [Route("api/PartsController")]
    [ApiExplorerSettings(GroupName = "v1")]
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
        /// <summary>
        /// Метод добавления части
        /// </summary>
        /// <param name="parts">Данные о части</param>
        /// <returns>Статус выполнения запроса</returns>
        /// <remarks>Данный метод добавляет часть в базу данных</remarks>
        [Route("Add")]
        [HttpPut]
        [ApiExplorerSettings(GroupName = "v3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult Add([FromForm] Parts parts)
        {
            try
            {
                PartsContext partsContext = new PartsContext();
                partsContext.Parts.Add(parts);
                partsContext.SaveChanges();
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
        /// <summary>
        /// Метод обновления части
        /// </summary>
        /// <param name="id">Идентификатор части</param>
        /// <param name="parts">Данные о части</param>
        /// <returns>Статус выполнения запроса</returns>
        /// <remarks>Данный метод обновляет информацию о части в базе данных</remarks>
        [Route("Update")]
        [HttpPut]
        [ApiExplorerSettings(GroupName = "v3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public ActionResult Update(int id, [FromForm] Parts parts)
        {
            try
            {
                PartsContext partsContext = new PartsContext();
                var findParts = partsContext.Parts.FirstOrDefault(x => x.Id_part == id);
                if (findParts != null)
                {
                    findParts.Locations = parts.Locations;
                    findParts.Companies = parts.Companies;
                    findParts.Date_of_foundation = parts.Date_of_foundation;
                    partsContext.SaveChanges();
                    return StatusCode(200);
                }
                else return StatusCode(401, "Часть не найдена!");
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
