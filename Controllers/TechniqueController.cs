using API_Тепляков.Context;
using API_Тепляков.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace API_Тепляков.Controllers
{
    [Route("api/TechniqueController")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class TechniqueController : Controller
    {
        /// <summary>
        /// Получение списка техники
        /// </summary>
        /// <remarks>Данный метод получает список техники, находящийся в базе данных</remarks>
        /// <response code="200">Список успешно получен</response>
        /// <response code="500">При выполнении запроса возникли ошибки</response>
        [Route("List")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Technique>), 200)]
        [ProducesResponseType(500)]
        public ActionResult List(string sortBy = "Name_technique")
        {
            try
            {
                IEnumerable<Technique> Technique = new TechniqueContext().Technique.OrderBy(x => EF.Property<object>(x, sortBy));
                return Json(Technique);
            }
            catch (Exception exp)
            {
                return StatusCode(500, exp.Message);
            }
        }
        /// <summary>
        /// Получение техники
        /// </summary>
        /// <remarks>Данный метод получает технику, находящееся в базе данных</remarks>
        /// <response code="200">Техника успешно получена</response>
        /// <response code="500">При выполнении запроса возникли ошибки</response>
        [Route("Item")]
        [HttpGet]
        [ProducesResponseType(typeof(Technique), 200)]
        [ProducesResponseType(500)]
        public ActionResult Item(int id)
        {
            try
            {
                Technique Technique = new TechniqueContext().Technique.First(x => x.Id_technique == id);
                return Json(Technique);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
        /// <summary>
        /// Метод добавления техники
        /// </summary>
        /// <param name="technique">Данные о технике</param>
        /// <returns>Статус выполнения запроса</returns>
        /// <remarks>Данный метод добавляет технику в базу данных</remarks>
        [Route("Add")]
        [HttpPut]
        [ApiExplorerSettings(GroupName = "v3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult Add([FromForm] Technique technique)
        {
            try
            {
                TechniqueContext techniqueContext = new TechniqueContext();
                techniqueContext.Technique.Add(technique);
                techniqueContext.SaveChanges();
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
        /// <summary>
        /// Метод обновления техники
        /// </summary>
        /// <param name="id">Идентификатор техники</param>
        /// <param name="technique">Данные о технике</param>
        /// <returns>Статус выполнения запроса</returns>
        /// <remarks>Данный метод обновляет информацию о технике в базе данных</remarks>
        [Route("Update")]
        [HttpPut]
        [ApiExplorerSettings(GroupName = "v3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public ActionResult Update(int id, [FromForm] Technique technique)
        {
            try
            {
                TechniqueContext techniqueContext = new TechniqueContext();
                var findTechnique = techniqueContext.Technique.FirstOrDefault(x => x.Id_technique == id);
                if (findTechnique != null)
                {
                    findTechnique.Name_technique = technique.Name_technique;
                    findTechnique.Companies = technique.Companies;
                    findTechnique.Characteristics = technique.Characteristics;
                    techniqueContext.SaveChanges();
                    return StatusCode(200);
                }
                else return StatusCode(401, "Техника не найдена!");
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
