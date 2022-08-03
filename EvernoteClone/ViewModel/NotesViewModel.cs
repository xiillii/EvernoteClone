using System.Collections.ObjectModel;
using EvernoteClone.Model;
using EvernoteClone.ViewModel.Commands;

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
}