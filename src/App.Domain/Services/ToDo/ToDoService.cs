using App.Data;
using App.Models;
using Microsoft.EntityFrameworkCore;


namespace App.Domain.Services.ToDo
{
    public class ToDoService : IToDoService
    {
        private readonly AppDbContext _context;
        /// <summary>
        /// Initializes a new instance of the <see cref="ToDoService"/> class.
        /// </summary>
        /// <param name="AppDbContext">Application Database Context</param>
        public ToDoService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ToDoItem> CreateAsync(ToDoItem item)
        {
            _context.TodoItems.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.TodoItems.FindAsync(id);
            if (item != null)
            {
                _context.TodoItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateAsync(ToDoItem item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ToDoItem>> GetAllAsync()
        {
            return await _context.TodoItems.ToListAsync();
        }

        public async Task<ToDoItem> GetByIdAsync(int id)
        {
            return await _context.TodoItems.FindAsync(id);
        }

        public async Task SeedItemsAsync()
        {
            if (!_context.TodoItems.Any())
            {
                _context.TodoItems.AddRange(new List<ToDoItem>
                {
                    new ToDoItem { Title = "Buy groceries", Description = "Milk, Bread, Cheese", IsCompleted = false, CreatedAt = DateTime.Now },
                    new ToDoItem { Title = "Read a book", Description = "Finish reading 'Clean Code'", IsCompleted = false, CreatedAt = DateTime.Now },
                    new ToDoItem { Title = "Workout", Description = "Go for a run", IsCompleted = false, CreatedAt = DateTime.Now }
                });

                await _context.SaveChangesAsync();
            }
        }

    }
}
