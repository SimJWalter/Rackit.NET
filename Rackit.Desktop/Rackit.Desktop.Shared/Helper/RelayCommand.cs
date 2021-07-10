using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;

namespace Rackit.Desktop.Helper
{
  public class RelayCommand : RelayCommand<object>
  {

    public RelayCommand(Action executeAction) : base(o => executeAction())
    {
    }

    public RelayCommand(Action executeAction, Func<bool> canExecute)
        : base(o => executeAction(), o => canExecute())
    {
    }
  }
}
