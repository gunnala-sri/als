namespace XboxGame.Models
{
    /// <summary>
    /// A class to mediate data between events
    /// </summary>
    public class EventMessage
    {
        /// <summary>
        /// Gets or sets the value of event message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the value data to be passed between events.
        /// </summary>
        public object Data { get; set; }

    }
}
