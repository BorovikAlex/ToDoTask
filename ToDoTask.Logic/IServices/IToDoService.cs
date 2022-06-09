using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoTask.Logic.DTOModels;

namespace ToDoTask.Logic.IServices
{
    public interface IToDoService
    {
        Task<IEnumerable<ToDoDTO>> GetToDos();
        Task<ToDoDTO> GetToDoDetails(int id);
        Task<int> CreateToDo(ToDoDTO toDo);
        Task<ToDoDTO> FindById(int id);
        Task<int> EditToDo(ToDoDTO toDo);
        Task<bool> DeleteToDo(int id);
    }
}
