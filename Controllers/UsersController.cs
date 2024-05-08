using API_Тепляков.Context;
using API_Тепляков.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;

namespace API_Тепляков.Controllers
{
    [Route("api/UsersController")]
    [ApiExplorerSettings(GroupName = "v2")]
    public class UsersController : Controller
    {
        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="Login">Логин</param>
        /// <param name="Password">Пароль</param>
        /// <returns>Данный метод преднозначен для авторизации пользователя на сайте</returns>
        /// <response code="200">Пользователь успешно авторизован</response>
        /// <response code="403">Ошибка запроса, данные не указаны</response>
        /// <response code="500">При выполнении запроса возникли ошибки</response>
        [Route("SingIn")]
        [HttpPost]
        [ProducesResponseType(typeof(Users), 200)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public ActionResult SingIn([FromForm] string Login, [FromForm] string Password)
        {
            if (Login == null || Password == null) return StatusCode(403);
            try
            {
                Users User = new UsersContext().Users.First(x => x.Login == Login && x.Password == Password);
                return Json(User);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Регистрация нового пользователя
        /// </summary>
        /// <param name="Login">Логин</param>
        /// <param name="Password">Пароль</param>
        /// <returns>Данный метод предназначен для регистрации пользователя на сайте</returns>
        /// <response code="200">Пользователь успешно зарегистрирован</response>
        /// <response code="401">Пользователь с такими данными уже существует</response>
        /// <response code="403">Ошибка запроса, данные не указаны</response>
        /// <response code="500">При выполнении запроса возникла ошибка</response>
        [Route("RegIn")]
        [HttpPost]
        [ProducesResponseType(typeof(Users), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public ActionResult RegIn([FromForm] string Login, [FromForm] string Password)
        {
            if (Login == null || Password == null) return StatusCode(403);
            try
            {
                var newUser = new UsersContext();
                if (newUser.Users.First(x => x.Login == Login && x.Password == Password) != null) return StatusCode(401);
                else
                {
                    Users User = new Users()
                    {
                        Login = Login,
                        Password = Password
                    };
                    newUser.Users.Add(User);
                    newUser.SaveChanges();
                    return Json(newUser);
                }
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
