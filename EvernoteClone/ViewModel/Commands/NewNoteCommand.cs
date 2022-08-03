using System;
using System.Windows.Input;
using EvernoteClone.Model;

namespace EvernoteClone.ViewModel.Commands;

public class NewNoteCommand : ICommand
{
    public NotesViewModel NotesViewModel { get; set; }

    public bool CanExecute(object? parameter)
    {
        var selectedNotebook = parameter as Notebook;
        return selectedNotebook != null;
    }

    public void Execute(object? parameter)
    {
        var selectedNotebook = parameter as Notebook;

        NotesViewModel.CreateNote(selectedNotebook.Id);;
    }

    public event EventHandler? CanExecuteChanged;

    public NewNoteCommand(NotesViewModel vm)
    {
        NotesViewModel = vm;
    }
}