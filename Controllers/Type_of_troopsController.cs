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
        /// <summary>
        /// Метод добавления войск
        /// </summary>
        /// <param name="type_of_troops">Данные о войсках</param>
        /// <returns>Статус выполнения запроса</returns>
        /// <remarks>Данный метод добавляет войска в базу данных</remarks>
        [Route("Add")]
        [HttpPut]
        [ApiExplorerSettings(GroupName = "v3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult Add([FromForm] Type_of_troops type_of_troops)
        {
            try
            {
                Type_of_troopsContext type_of_troopsContext = new Type_of_troopsContext();
                type_of_troopsContext.Type_of_troops.Add(type_of_troops);
                type_of_troopsContext.SaveChanges();
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
        /// <summary>
        /// Метод обновления войск
        /// </summary>
        /// <param name="id">Идентификатор войск</param>
        /// <param name="type_of_troops">Данные о войсках</param>
        /// <returns>Статус выполнения запроса</returns>
        /// <remarks>Данный метод обновляет информацию о войсках в базе данных</remarks>
        [Route("Update")]
        [HttpPut]
        [ApiExplorerSettings(GroupName = "v3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public ActionResult Update(int id, [FromForm] Type_of_troops type_of_troops)
        {
            try
            {
                Type_of_troopsContext type_of_troopsContext = new Type_of_troopsContext();
                var findType_of_troops = type_of_troopsContext.Type_of_troops.FirstOrDefault(x => x.Id_type_of_troops == id);
                if (findType_of_troops != null)
                {
                    findType_of_troops.Name_type_of_troops = type_of_troops.Name_type_of_troops;
                    findType_of_troops.Description = type_of_troops.Description;
                    findType_of_troops.Count_serviceman = type_of_troops.Count_serviceman;
                    findType_of_troops.Date_foundation = type_of_troops.Date_foundation;
                    type_of_troopsContext.SaveChanges();
                    return StatusCode(200);
                }
                else return StatusCode(401, "Войска не найдены!");
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Метод удаления войск
        /// </summary>
        /// <param name="id">Идентификатор войск</param>
        /// <param name="Token">Токен пользователя</param>
        /// <returns>Статус выполнения запроса</returns>
        /// <remarks>Данный метод удаляет информацию о войсках в базе данных</remarks>
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
                Type_of_troopsContext type_of_troopsContext = new Type_of_troopsContext();
                var findType_of_troops = type_of_troopsContext.Type_of_troops.FirstOrDefault(x => x.Id_type_of_troops == id);
                if (findType_of_troops != null)
                {
                    var tokenUser = usersContext.Users.FirstOrDefault(x => x.Token == Token);
                    if (tokenUser != null)
                    {
                        type_of_troopsContext.Remove(findType_of_troops);
                        type_of_troopsContext.SaveChanges();
                        return StatusCode(200);
                    }
                    else return StatusCode(401, "Токен не найден!");
                }
                else return StatusCode(401, "Войска не найдены!");
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Метод удаления войск
        /// </summary>
        /// <param name="Token">Токен пользователя</param>
        /// <returns>Статус выполнения запроса</returns>
        /// <remarks>Данный метод удаляет информацию о войсках в базе данных</remarks>
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
                Type_of_troopsContext type_of_troopsContext = new Type_of_troopsContext();
                var tokenUser = usersContext.Users.FirstOrDefault(x => x.Token == Token);
                if (tokenUser != null)
                {
                    type_of_troopsContext.RemoveRange(type_of_troopsContext.Type_of_troops);
                    type_of_troopsContext.SaveChanges();
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
