using System;
using System.Collections.ObjectModel;
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
            //TODO: Get the notes
        }
    }

    public ObservableCollection<Note> Notes { get; set; }

    public NewNoteCommand NewNoteCommand { get; set; }
    public NewNotebookCommand NewNotebookCommand { get; set; }

    public NotesViewModel()
    {
        NewNoteCommand = new NewNoteCommand(this);
        NewNotebookCommand = new NewNotebookCommand(this);
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
}