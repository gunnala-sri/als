using Caliburn.Micro;
using XboxGame.Interface;
using XboxGame.Models;

namespace XboxGame
{
    /// <summary>
    /// The main parent shell view model class for the application
    /// </summary>
    public class ShellViewModel : Caliburn.Micro.PropertyChangedBase, IShell,  IHandle<EventMessage>
    {
        /// <summary>
        /// Event aggregator object
        /// </summary>
        private readonly IEventAggregator _eventAggregator;

        /// <summary>
        /// Gets or sets the value of content view to be displayed
        /// </summary>
        public object ConentView { get; set; }

        /// <summary>
        /// Instantiates the new object of shell view model class
        /// </summary>
        /// <param name="eventAggregator">event aggregator object</param>
        public ShellViewModel(IEventAggregator eventAggregator)
        {
            //Initialization
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);

            // Set the view
            ConentView = new GameListViewModel(IoC.Get<IGameService>(), _eventAggregator);
        }

        /// <summary>
        /// Event aggregator handler method
        /// </summary>
        /// <param name="message">Handler message object</param>
        public void Handle(EventMessage message)
        {
            if (message.Message == "Details")
            {
                ConentView = new GameDetailViewModel(IoC.Get<IGameService>(), _eventAggregator, message.Data as Game );
            }
            else
            {
                ConentView = new GameListViewModel(IoC.Get<IGameService>(), _eventAggregator);
            }
        }
    }
}