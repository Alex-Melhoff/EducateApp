using System;
using System.Windows.Input;

public class RelayCommand : ICommand
{
    private readonly Action<object> _execute;
    private readonly Predicate<object> _canExecute;

    /// <summary>
    /// —оздает новую команду, котора€ всегда может быть выполнена.
    /// </summary>
    /// <param name="execute">Ћогика выполнени€.</param>
    public RelayCommand(Action<object> execute) : this(execute, null)
    {
    }

    /// <summary>
    /// —оздает новую команду.
    /// </summary>
    /// <param name="execute">Ћогика выполнени€.</param>
    /// <param name="canExecute">Ћогика, определ€юща€, может ли команда быть выполнена.</param>
    public RelayCommand(Action<object> execute, Predicate<object> canExecute)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }

    /// <summary>
    /// ќпредел€ет, может ли команда быть выполнена в текущем состо€нии.
    /// </summary>
    /// <param name="parameter">ƒанные, используемые командой.  ≈сли команда не требует передачи данных, этот параметр может быть null.</param>
    /// <returns>
    /// true, если эту команду можно выполнить; в противном случае Ч false.
    /// </returns>
    public bool CanExecute(object parameter)
    {
        return _canExecute == null || _canExecute(parameter);
    }

    /// <summary>
    /// ѕроисходит, когда изменени€, вли€ющие на возможность выполнени€ команды, должны произойти.
    /// </summary>
    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    /// <summary>
    /// ¬ыполн€ет логику команды.
    /// </summary>
    /// <param name="parameter">ƒанные, используемые командой.  ≈сли команда не требует передачи данных, этот параметр может быть null.</param>
    public void Execute(object parameter)
    {
        _execute(parameter);
    }
}