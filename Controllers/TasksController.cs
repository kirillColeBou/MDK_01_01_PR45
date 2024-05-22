using API_Тепляков.Context;
using API_Тепляков.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Тепляков.Controllers
{
    [Route("api/TasksController")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class TasksController : Controller
    {
        /// <summary>
        /// Получение списка задач
        /// </summary>
        /// <remarks>Данный метод получает список задач, находящийся в базе данных</remarks>
        /// <response code="200">Список успешно получен</response>
        /// <response code="500">При выполнении запроса возникли ошибки</response>
        [Route("List")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Tasks>), 200)]
        [ProducesResponseType(500)]
        public ActionResult List()
        {
            try
            {
                IEnumerable<Tasks> Tasks = new TasksContext().Tasks;
                return Json(Tasks);
            }
            catch (Exception exp)
            {
                return StatusCode(500, exp.Message);
            }
        }
        /// <summary>
        /// Получение задачи
        /// </summary>
        /// <remarks>Данный метод получает задачу, находящуюся в базе данных</remarks>
        /// <response code="200">Задача успешно получена</response>
        /// <response code="500">При выполнении запроса возникли ошибки</response>
        [Route("Item")]
        [HttpGet]
        [ProducesResponseType(typeof(Tasks), 200)]
        [ProducesResponseType(500)]
        public ActionResult Item(int id)
        {
            try
            {
                Tasks Task = new TasksContext().Tasks.First(x => x.Id == id);
                return Json(Task);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
        /// <summary>
        /// Метод добавления задачи
        /// </summary>
        /// <param name="task">Данные о задаче</param>
        /// <returns>Статус выполнения запроса</returns>
        /// <remarks>Данный метод добавляет задачу в базу данных</remarks>
        [Route("Add")]
        [HttpPut]
        [ApiExplorerSettings(GroupName = "v3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult Add([FromForm]Tasks task)
        {
            try
            {
                TasksContext tasksContext = new TasksContext();
                tasksContext.Tasks.Add(task);
                tasksContext.SaveChanges();
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
        /// <summary>
        /// Метод обновления задачи
        /// </summary>
        /// <param name="id">Идентификатор задачи</param>
        /// <param name="task">Данные о задаче</param>
        /// <returns>Статус выполнения запроса</returns>
        /// <remarks>Данный метод обновляет информацию о задаче в базе данных</remarks>
        [Route("Update")]
        [HttpPut]
        [ApiExplorerSettings(GroupName = "v3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public ActionResult Update(int id, [FromForm] Tasks task)
        {
            try
            {
                TasksContext tasksContext = new TasksContext();
                var findTask = tasksContext.Tasks.FirstOrDefault(x => x.Id == id);
                if (findTask != null)
                {
                    findTask.Name = task.Name;
                    findTask.PriorityId = task.PriorityId;
                    findTask.DateExecute = task.DateExecute;
                    findTask.Comment = task.Comment;
                    findTask.Done = task.Done;
                    tasksContext.SaveChanges();
                    return StatusCode(200);
                }
                else return StatusCode(401, "Задача не найдена!");
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Метод удаления задачи
        /// </summary>
        /// <param name="id">Идентификатор задачи</param>
        /// <param name="Token">Токен пользователя</param>
        /// <returns>Статус выполнения запроса</returns>
        /// <remarks>Данный метод удаляет информацию о задаче в базе данных</remarks>
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
                TasksContext tasksContext = new TasksContext();
                var findTasks = tasksContext.Tasks.FirstOrDefault(x => x.Id == id);
                if (findTasks != null)
                {
                    var tokenUser = usersContext.Users.FirstOrDefault(x => x.Token == Token);
                    if (tokenUser != null)
                    {
                        tasksContext.Remove(findTasks);
                        tasksContext.SaveChanges();
                        return StatusCode(200);
                    }
                    else return StatusCode(401, "Токен не найден!");
                }
                else return StatusCode(401, "Задача не найдена!");
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Метод удаления задачи
        /// </summary>
        /// <param name="Token">Токен пользователя</param>
        /// <returns>Статус выполнения запроса</returns>
        /// <remarks>Данный метод удаляет информацию о задаче в базе данных</remarks>
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
                TasksContext tasksContext = new TasksContext();
                var tokenUser = usersContext.Users.FirstOrDefault(x => x.Token == Token);
                if (tokenUser != null)
                {
                    tasksContext.RemoveRange(tasksContext.Tasks);
                    tasksContext.SaveChanges();
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
