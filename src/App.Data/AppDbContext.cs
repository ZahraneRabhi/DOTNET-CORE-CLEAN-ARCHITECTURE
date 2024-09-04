using App.Models;
using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Database App context.
    /// </summary>
namespace App.Data
{
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OSINTContext" /> class.
        /// </summary>
        /// <param name="options">Creation options. Useful when using InMemory driver for testing.</param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base( options) { }

        /// <summary>
        /// gets or sets ToDoItem entity
        /// </summary>
        public DbSet<ToDoItem> TodoItems { get; set; }  
    }
}
