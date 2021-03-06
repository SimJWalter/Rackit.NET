using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;

namespace Rackit.Desktop.Helper
{
  public class RelayCommand<T> : ICommand
  {

    public event EventHandler CanExecuteChanged;

    private Predicate<T> _canExecute = null;
    private Action<T> _executeAction = null;

    public RelayCommand(Action<T> executeAction)
    {
      _executeAction = executeAction;
    }

    public RelayCommand(Action<T> executeAction, Predicate<T> canExecute)
        : this(executeAction)
    {
      _canExecute = canExecute;
    }

    public bool CanExecute(T parameter)
    {
      if (_canExecute != null)
      {
        return _canExecute(parameter);
      }
      return true;
    }

    public void Execute(T parameter)
    {
      if (_executeAction != null)
        _executeAction(parameter);

      if (CanExecuteChanged != null)
        CanExecuteChanged(this, EventArgs.Empty);
    }

    public void RaiseCanExecuteChanged()
    {
      OnCanExecuteChanged();
    }

    protected virtual void OnCanExecuteChanged()
    {
      EventHandler handler = CanExecuteChanged;
      if (handler != null)
      {
        handler(this, EventArgs.Empty);
      }
    }

    #region ICommand Members

    bool ICommand.CanExecute(object parameter)
    {
      return this.CanExecute((T)(parameter ?? default(T)));
    }

    void ICommand.Execute(object parameter)
    {
      this.Execute((T)parameter);
    }

    #endregion
  }
}
