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
    [ApiExplorerSettings(GroupName = "v1")]
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
            catch
            {
                return StatusCode(500);
            }
        }
        /// <summary>
        /// Метод добавления роты
        /// </summary>
        /// <param name="companies">Данные о роте</param>
        /// <returns>Статус выполнения запроса</returns>
        /// <remarks>Данный метод добавляет роту в базу данных</remarks>
        [Route("Add")]
        [HttpPut]
        [ApiExplorerSettings(GroupName = "v3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult Add([FromForm] Companies companies)
        {
            try
            {
                CompaniesContext companiesContext = new CompaniesContext();
                companiesContext.Companies.Add(companies);
                companiesContext.SaveChanges();
                return StatusCode(200);
            }
            catch
            {
                return StatusCode(500);
            }
        }
        /// <summary>
        /// Метод обновления роты
        /// </summary>
        /// <param name="id">Идентификатор роты</param>
        /// <param name="companies">Данные о роте</param>
        /// <returns>Статус выполнения запроса</returns>
        /// <remarks>Данный метод обновляет информацию о роте в базе данных</remarks>
        [Route("Update")]
        [HttpPut]
        [ApiExplorerSettings(GroupName = "v3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public ActionResult Update(int id, [FromForm] Companies companies)
        {
            try
            {
                CompaniesContext companiesContext = new CompaniesContext();
                var findCompanies = companiesContext.Companies.FirstOrDefault(x => x.Id_companies == id);
                if (findCompanies != null)
                {
                    findCompanies.Name_companies = companies.Name_companies;
                    findCompanies.Commander = companies.Commander;
                    findCompanies.Type_of_troops = companies.Type_of_troops;
                    findCompanies.Date_foundation = companies.Date_foundation;
                    findCompanies.Date_update_information = companies.Date_update_information;
                    companiesContext.SaveChanges();
                    return StatusCode(200);
                }
                else return StatusCode(401, "Рота не найдена!");
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Метод удаления роты
        /// </summary>
        /// <param name="id">Идентификатор роты</param>
        /// <param name="Token">Токен пользователя</param>
        /// <returns>Статус выполнения запроса</returns>
        /// <remarks>Данный метод удаляет информацию о роте в базе данных</remarks>
        [Route("Delete")]
        [HttpDelete]
        [ApiExplorerSettings(GroupName = "v4")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public ActionResult Delete(int id, [FromForm] string Token)
        {
            try
            {
                UsersContext usersContext = new UsersContext();
                CompaniesContext companiesContext = new CompaniesContext();
                var findCompanies = companiesContext.Companies.FirstOrDefault(x => x.Id_companies == id);
                if (findCompanies != null)
                {
                    var tokenUser = usersContext.Users.FirstOrDefault(x => x.Token == Token);
                    if (tokenUser != null)
                    {
                        companiesContext.Remove(findCompanies);
                        companiesContext.SaveChanges();
                        return StatusCode(200);
                    }
                    else return StatusCode(401, "Токен не найден!");
                }
                else return StatusCode(401, "Рота не найдена!");
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Метод удаления роты
        /// </summary>
        /// <param name="Token">Токен пользователя</param>
        /// <returns>Статус выполнения запроса</returns>
        /// <remarks>Данный метод удаляет всю информацию о роте в базе данных</remarks>
        [Route("Delete")]
        [HttpDelete]
        [ApiExplorerSettings(GroupName = "v4")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public ActionResult Delete([FromForm] string Token)
        {
            try
            {
                UsersContext usersContext = new UsersContext();
                CompaniesContext companiesContext = new CompaniesContext();
                var tokenUser = usersContext.Users.FirstOrDefault(x => x.Token == Token);
                if (tokenUser != null)
                {
                    companiesContext.RemoveRange(companiesContext.Companies);
                    companiesContext.SaveChanges();
                    return StatusCode(200);
                }
                else return StatusCode(401, "Токен не найден!");
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
