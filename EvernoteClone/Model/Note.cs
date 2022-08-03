using System;
using SQLite;

namespace EvernoteClone.Model;

public class Note
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    [Indexed]
    public int NotebookId { get; set; }
    public string Title { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public string FileLocation { get; set; }
}