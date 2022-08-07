using System;
using System.Collections.ObjectModel;
using System.Linq;
using EvernoteClone.Model;
using EvernoteClone.ViewModel.Commands;
using EvernoteClone.ViewModel.Helpers;

namespace EvernoteClone.ViewModel;

public class NotesViewModel
{
    public ObservableCollection<Notebook> Notebooks { get; set; }

    private Notebook _selectedNotebook;

    public Notebook SelectedNotebook
    {
        get => _selectedNotebook;
        set
        {
            _selectedNotebook = value;
            

            GetNotes();
        }
    }

    public ObservableCollection<Note> Notes { get; set; }

    public NewNoteCommand NewNoteCommand { get; set; }
    public NewNotebookCommand NewNotebookCommand { get; set; }

    public NotesViewModel()
    {
        NewNoteCommand = new NewNoteCommand(this);
        NewNotebookCommand = new NewNotebookCommand(this);

        Notebooks = new ObservableCollection<Notebook>();
        Notes = new ObservableCollection<Note>();

        GetNotebooks();
    }

    public void CreateNotebook()
    {
        var newNotebook = new Notebook
        {
            Name = "New notebook",
        };

        DatabaseHelper.Insert(newNotebook);
    }

    public void CreateNote(int notebookId)
    {
        var newNote = new Note
        {
            NotebookId = notebookId,
            CreatedAt = DateTimeOffset.Now,
            UpdatedAt = DateTimeOffset.Now,
            Title = "New  note",
        };

        DatabaseHelper.Insert(newNote);
    }

    private void GetNotebooks()
    {
        var notebooks = DatabaseHelper.Read<Notebook>();
        
        Notebooks.Clear();
        foreach (var notebook in notebooks)
        {
            Notebooks.Add(notebook);
        }
    }

    private void GetNotes()
    {
        if (SelectedNotebook != null && SelectedNotebook.Id > 0)
        {
            var notes = DatabaseHelper.Read<Note>().Where(n => n.NotebookId == SelectedNotebook.Id);

            Notes.Clear();
            foreach (var note in notes)
            {
                Notes.Add(note);
            } 
        }
    }
}