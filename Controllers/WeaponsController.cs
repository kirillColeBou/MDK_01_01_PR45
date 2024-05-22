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
    [ApiExplorerSettings(GroupName = "v1")]
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
        /// <summary>
        /// Метод добавления вооружения
        /// </summary>
        /// <param name="weapons">Данные о вооружении</param>
        /// <returns>Статус выполнения запроса</returns>
        /// <remarks>Данный метод добавляет вооружение в базу данных</remarks>
        [Route("Add")]
        [HttpPut]
        [ApiExplorerSettings(GroupName = "v3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult Add([FromForm] Weapons weapons)
        {
            try
            {
                WeaponsContext weaponsContext = new WeaponsContext();
                weaponsContext.Weapons.Add(weapons);
                weaponsContext.SaveChanges();
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
        /// <summary>
        /// Метод обновления вооружения
        /// </summary>
        /// <param name="id">Идентификатор вооружения</param>
        /// <param name="weapons">Данные о вооружении</param>
        /// <returns>Статус выполнения запроса</returns>
        /// <remarks>Данный метод обновляет информацию о вооружении в базе данных</remarks>
        [Route("Update")]
        [HttpPut]
        [ApiExplorerSettings(GroupName = "v3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public ActionResult Update(int id, [FromForm] Weapons weapons)
        {
            try
            {
                WeaponsContext weaponsContext = new WeaponsContext();
                var findWeapons = weaponsContext.Weapons.FirstOrDefault(x => x.Id_weapons == id);
                if (findWeapons != null)
                {
                    findWeapons.Name_weapons = weapons.Name_weapons;
                    findWeapons.Companies = weapons.Companies;
                    findWeapons.Description = weapons.Description;
                    findWeapons.Date_update_information = weapons.Date_update_information;
                    weaponsContext.SaveChanges();
                    return StatusCode(200);
                }
                else return StatusCode(401, "Вооружение не найдено!");
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Метод удаления вооружения
        /// </summary>
        /// <param name="id">Идентификатор вооружения</param>
        /// <param name="Token">Токен пользователя</param>
        /// <returns>Статус выполнения запроса</returns>
        /// <remarks>Данный метод удаляет информацию о вооружении в базе данных</remarks>
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
                WeaponsContext weaponsContext = new WeaponsContext();
                var findWeapons = weaponsContext.Weapons.FirstOrDefault(x => x.Id_weapons == id);
                if (findWeapons != null)
                {
                    var tokenUser = usersContext.Users.FirstOrDefault(x => x.Token == Token);
                    if (tokenUser != null)
                    {
                        weaponsContext.Remove(findWeapons);
                        weaponsContext.SaveChanges();
                        return StatusCode(200);
                    }
                    else return StatusCode(401, "Токен не найден!");
                }
                else return StatusCode(401, "Вооружение не найдено!");
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Метод удаления вооружения
        /// </summary>
        /// <param name="Token">Токен пользователя</param>
        /// <returns>Статус выполнения запроса</returns>
        /// <remarks>Данный метод удаляет всю информацию о вооружении в базе данных</remarks>
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
                WeaponsContext weaponsContext = new WeaponsContext();
                var tokenUser = usersContext.Users.FirstOrDefault(x => x.Token == Token);
                if (tokenUser != null)
                {
                    weaponsContext.RemoveRange(weaponsContext.Weapons);
                    weaponsContext.SaveChanges();
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
