using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;

namespace DonatasSimpleUniversal_MVVM_App.MVVMFramework.MVVMHelpers
{
    /// <summary>
    /// A command whose sole purpose is to relay its functionality to other objects by invoking delegates. The default return value for the CanExecute method is 'true'.
    /// Original author - Josh Smith - http://msdn.microsoft.com/en-us/magazine/dd419663.aspx#id0090030
    /// </summary>
    public class RelayCommand : ICommand
    {

        #region Declarations

        readonly Func<Boolean> _canExecute;
        readonly Action _execute;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand&lt;T&gt;"/> class and the command can always be executed.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        public RelayCommand(Action execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand(Action execute, Func<Boolean> canExecute)
        {

            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion

        #region ICommand Members

        public event EventHandler CanExecuteChanged = delegate { };

        internal void RaiseCanExecuteChanged()
        {
            // No need for null check because of empty delegate
            CanExecuteChanged(this, EventArgs.Empty);
        }

        [DebuggerStepThrough]
        public Boolean CanExecute(Object parameter)
        {
            return _canExecute == null ? true : _canExecute();
        }

        public void Execute(Object parameter)
        {
            _execute();
        }

        #endregion
    }
}
