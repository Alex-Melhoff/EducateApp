using System;
using System.Windows.Input;

public class RelayCommand : ICommand
{
    private readonly Action<object> _execute;
    private readonly Predicate<object> _canExecute;

    /// <summary>
    /// ������� ����� �������, ������� ������ ����� ���� ���������.
    /// </summary>
    /// <param name="execute">������ ����������.</param>
    public RelayCommand(Action<object> execute) : this(execute, null)
    {
    }

    /// <summary>
    /// ������� ����� �������.
    /// </summary>
    /// <param name="execute">������ ����������.</param>
    /// <param name="canExecute">������, ������������, ����� �� ������� ���� ���������.</param>
    public RelayCommand(Action<object> execute, Predicate<object> canExecute)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }

    /// <summary>
    /// ����������, ����� �� ������� ���� ��������� � ������� ���������.
    /// </summary>
    /// <param name="parameter">������, ������������ ��������.  ���� ������� �� ������� �������� ������, ���� �������� ����� ���� null.</param>
    /// <returns>
    /// true, ���� ��� ������� ����� ���������; � ��������� ������ � false.
    /// </returns>
    public bool CanExecute(object parameter)
    {
        return _canExecute == null || _canExecute(parameter);
    }

    /// <summary>
    /// ����������, ����� ���������, �������� �� ����������� ���������� �������, ������ ���������.
    /// </summary>
    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    /// <summary>
    /// ��������� ������ �������.
    /// </summary>
    /// <param name="parameter">������, ������������ ��������.  ���� ������� �� ������� �������� ������, ���� �������� ����� ���� null.</param>
    public void Execute(object parameter)
    {
        _execute(parameter);
    }
}