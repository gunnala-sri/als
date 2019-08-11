using Caliburn.Micro;
using XboxGame.Interface;
using XboxGame.Models;

namespace XboxGame {
    public class ShellViewModel : Caliburn.Micro.PropertyChangedBase, IShell,  IHandle<EventMessage>
    {
        private readonly IEventAggregator _eventAggregator;

        public object GameListVM { get; set; }

        public ShellViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);

            GameListVM = new GameListViewModel(IoC.Get<IGameService>(), _eventAggregator);
        }

        public void LoadDetails()
        {
            GameListVM = new GameDetailViewModel(IoC.Get<IGameService>(), _eventAggregator);
        }

        public void Handle(EventMessage message)
        {
            if (message.Text == "Details")
            {
                GameListVM = new GameDetailViewModel(IoC.Get<IGameService>(), _eventAggregator);
            }
            else
            {
                GameListVM = new GameListViewModel(IoC.Get<IGameService>(), _eventAggregator);
            }
        }
    }
}