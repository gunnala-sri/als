using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace XboxGame
{
    class NavigationViewModel : INotifyPropertyChanged
    {
        public ICommand GameListCommand { get; set; }
        public ICommand GameDetailCommand { get; set; }

        public object SelectedViewModel { get; set; }


        //public NavigationViewModel()
        //{
        //    GameListCommand = new BaseCommand(OpenGameList);
        //    GameDetailCommand = new BaseCommand(OpenGameDetail);

        //    OpenGameList(null);
        //}

        //private void OpenGameList(object obj)
        //{
        //    SelectedViewModel = new GameListViewModel();
        //}
        //private void OpenGameDetail(object obj)
        //{
        //    SelectedViewModel = new GameDetailViewModel();
        //}

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class BaseCommand : ICommand
    {
        private Predicate<object> _canExecute;
        private Action<object> _method;
        public event EventHandler CanExecuteChanged;

        public BaseCommand(Action<object> method)
            : this(method, null)
        {
        }

        public BaseCommand(Action<object> method, Predicate<object> canExecute)
        {
            _method = method;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }

            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _method.Invoke(parameter);
        }
    }
}
