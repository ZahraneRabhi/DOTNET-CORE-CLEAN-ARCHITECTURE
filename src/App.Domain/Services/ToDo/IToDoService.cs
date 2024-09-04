using App.Models;

namespace App.Domain.Services.ToDo
{
    /// <summary>
    /// Defines methods for managing <see cref="ToDoItem"/> entities.
    /// </summary>
    public interface IToDoService
    {
        /// <summary>
        /// Retrieves all <see cref="ToDoItem"/> entities.
        /// </summary>
        /// <returns>A <see cref="Task{IEnumerable{ToDoItem}}"/> representing the asynchronous operation, with an <see cref="IEnumerable{ToDoItem}"/> as its result.</returns>
        Task<IEnumerable<ToDoItem>> GetAllAsync();

        /// <summary>
        /// Retrieves a <see cref="ToDoItem"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the <see cref="ToDoItem"/>.</param>
        /// <returns>A <see cref="Task{ToDoItem}"/> representing the asynchronous operation, with the <see cref="ToDoItem"/> as its result.</returns>
        Task<ToDoItem> GetByIdAsync(int id);

        /// <summary>
        /// Creates a new <see cref="ToDoItem"/>.
        /// </summary>
        /// <param name="item">The <see cref="ToDoItem"/> to create.</param>
        /// <returns>A <see cref="Task{ToDoItem}"/> representing the asynchronous operation, with the created <see cref="ToDoItem"/> as its result.</returns>
        Task<ToDoItem> CreateAsync(ToDoItem item);

        /// <summary>
        /// Updates an existing <see cref="ToDoItem"/>.
        /// </summary>
        /// <param name="item">The <see cref="ToDoItem"/> to update.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task UpdateAsync(ToDoItem item);

        /// <summary>
        /// Deletes a <see cref="ToDoItem"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the <see cref="ToDoItem"/> to delete.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task DeleteAsync(int id);

        /// <summary>
        /// Seeds initial <see cref="ToDoItem"/> hardcoded data.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task SeedItemsAsync();
    }
}
