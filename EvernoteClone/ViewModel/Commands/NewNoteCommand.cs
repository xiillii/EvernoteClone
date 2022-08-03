using System;
using System.Windows.Input;

namespace EvernoteClone.ViewModel.Commands;

public class NewNoteCommand : ICommand
{
    public NotesViewModel NotesViewModel { get; set; }

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        //TODO: New note
    }

    public event EventHandler? CanExecuteChanged;

    public NewNoteCommand(NotesViewModel vm)
    {
        NotesViewModel = vm;
    }
}