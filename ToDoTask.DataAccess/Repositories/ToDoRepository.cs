using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoTask.DataAccess.Contexts;
using ToDoTask.DataAccess.IRepositories;
using ToDoTask.DataAccess.Models;

namespace ToDoTask.DataAccess.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly DBContext _context;

        public ToDoRepository(DBContext context) => _context = context;

        public async Task<int> CreateToDo(ToDoModel toDo)
        {
            _context.ToDos.Add(toDo);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return toDo.ToDoID;
        }

        public async Task<bool> DeleteToDo(int id)
        {
            ToDoModel toDo = await _context.ToDos.FirstAsync(p => p.ToDoID == id).ConfigureAwait(false);

            var result = _context.ToDos.Remove(toDo);

            if (result == null)
            {
                return false;
            }

            await _context.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }

        public async Task<int> EditToDo(ToDoModel toDo)
        {
            var _toDo = await _context.ToDos.FirstOrDefaultAsync(p => p.ToDoID == toDo.ToDoID).ConfigureAwait(false);

            var entry = _context.Entry(_toDo);
            entry.CurrentValues.SetValues(toDo);

            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<ToDoModel> FindById(int id)
        {
            return await _context.ToDos.FirstAsync(o => o.ToDoID == id).ConfigureAwait(false);
        }

        public async Task<ToDoModel> GetToDoDetails(int id)
        {
            return await _context.ToDos.FirstAsync(o => o.ToDoID == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ToDoModel>> GetToDos()
        {
            return await _context.ToDos.ToListAsync().ConfigureAwait(false);
        }
    }
}
