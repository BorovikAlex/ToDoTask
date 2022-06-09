using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoTask.DataAccess.Models;

namespace ToDoTask.DataAccess.IRepositories
{
    public interface IToDoRepository
    {
        Task<IEnumerable<ToDoModel>> GetToDos();
        Task<ToDoModel> GetToDoDetails(int id);
        Task<int> CreateToDo(ToDoModel toDo);
        Task<ToDoModel> FindById(int id);
        Task<int> EditToDo(ToDoModel toDo);
        Task<bool> DeleteToDo(int id);
    }
}
