using System.Windows.Input;

namespace Presentation.ViewModel
{
    public class Command : ICommand
    {
        private readonly Action action;
        private readonly Func<bool>? executable;
        public event EventHandler? CanExecuteChanged;

        public Command(Action execute, Func<bool>? canExecute = null)
        {
            action = execute ?? throw new ArgumentNullException(nameof(execute));
            executable = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            if (executable == null)
                return false;
            return executable();
        }

        public void Execute(object? parameter)
        {
            action();
        }

        internal void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}