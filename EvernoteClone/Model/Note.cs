using System;

namespace EvernoteClone.Model;

public class Note
{
    public int Id { get; set; }
    public int NotebookId { get; set; }
    public string Title { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public string FileLocation { get; set; }
}