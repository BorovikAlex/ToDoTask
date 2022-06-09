using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoTask.DataAccess.IRepositories;
using ToDoTask.DataAccess.Models;
using ToDoTask.Logic.DTOModels;
using ToDoTask.Logic.IServices;

namespace ToDoTask.Logic.Services
{
    public class ToDoService : IToDoService
    {
        private IMapper _mapper;
        private IToDoRepository _repo;

        public ToDoService(IToDoRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<int> CreateToDo(ToDoDTO toDo)
        {
            try
            {
                var id = await _repo.CreateToDo(_mapper.Map<ToDoModel>(toDo)).ContinueWith(t => t.Result);

                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteToDo(int id)
        {
            return await _repo.DeleteToDo(id);
        }

        public async Task<int> EditToDo(ToDoDTO toDo)
        {
            return await _repo.EditToDo(_mapper.Map<ToDoModel>(toDo)).ContinueWith(t => t.Result);
        }

        public async Task<ToDoDTO> FindById(int id)
        {
            return await _repo.FindById(id)
                .ContinueWith(t => _mapper.Map<ToDoDTO>(t.Result));
        }

        public async Task<ToDoDTO> GetToDoDetails(int id)
        {
            return await _repo.GetToDoDetails(id)
              .ContinueWith(t => _mapper.Map<ToDoDTO>(t.Result));
        }

        public async Task<IEnumerable<ToDoDTO>> GetToDos()
        {
            return await _repo.GetToDos()
                 .ContinueWith(t => _mapper.Map<IEnumerable<ToDoDTO>>(t.Result));
        }
    }
}
