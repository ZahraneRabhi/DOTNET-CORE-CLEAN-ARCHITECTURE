namespace App.Models;

/// <summary>
/// Represents a TodoItem.
/// </summary>
public class ToDoItem
{
    /// <summary>
    /// Gets or sets TodoItem id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets TodoItem Title.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets TodoItem Description.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets TodoItem Completion Status
    /// </summary>
    public bool IsCompleted { get; set; }

    /// <summary>
    /// Gets or sets TodoItem creation date.
    /// </summary>
    public DateTime CreatedAt { get; set; }
   
    /// <summary>
    /// Gets or sets TodoItem Completion date.
    /// </summary>
    public DateTime? CompletedAt { get; set; }
}
