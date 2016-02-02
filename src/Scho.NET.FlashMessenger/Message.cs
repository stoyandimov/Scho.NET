namespace Scho.NET.FlashMessenger
{
	public class Message
	{

		/// <summary>
		/// The content of the message
		/// </summary>
		public string Content { get; private set; }

		/// <summary>
		/// Info, Success, Warning or Criticle defined by the MessageType Enum
		/// </summary>
		public MessageType Type { get; private set; }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="Content">The content of the message</param>
		/// <param name="Type">The type of the message ()</param>
		public Message(string Content, MessageType Type)
		{
			this.Content = Content;
			this.Type = Type;
		}

		/// <summary>
		/// Overrides the default implementation to output the message content
		/// </summary>
		/// <returns>this.Content</returns>
		public override string ToString()
		{
			return Content;
		}
	}
}
