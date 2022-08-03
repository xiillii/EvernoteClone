using System;
using System.Windows.Input;

namespace EvernoteClone.ViewModel.Commands;

public class NewNotebookCommand : ICommand
{
    public NotesViewModel NotesViewModel { get; set; }

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        //TODO: Create new notebook
    }

    public event EventHandler? CanExecuteChanged;

    public NewNotebookCommand(NotesViewModel vm)
    {
        NotesViewModel = vm;
    }
}