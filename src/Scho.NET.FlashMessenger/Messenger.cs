using System.Linq;
using System.Collections.Generic;
using Scho.NET.FlashMessenger.Storage;

namespace Scho.NET.FlashMessenger
{
	public class Messenger
	{

		private IList<Message> Messages { get; set; }

		private IMessageStorage Storage { get; set; }

		public Messenger(IMessageStorage MessageStorage)
		{
			Storage = MessageStorage;
			Messages = Storage.Read().ToList();
		}

		public void AddInfoMessage(string Format, params string[] args)
		{
			AddMessage(string.Format(Format, args), MessageType.Info);
		}

		public void AddInfoMessage(string Content)
		{
			AddMessage(Content, MessageType.Info);
		}

		public void AddSuccessMessage(string Format, params string[] args)
		{
			AddMessage(string.Format(Format, args), MessageType.Success);
		}

		public void AddSuccessMessage(string Content)
		{
			AddMessage(Content, MessageType.Success);
		}

		public void AddWarningMessage(string Format, params string[] args)
		{
			AddMessage(string.Format(Format, args), MessageType.Warning);
		}

		public void AddWarningMessage(string Content)
		{
			AddMessage(Content, MessageType.Warning);
		}

		public void AddCriticleMessage(string Format, params string[] args)
		{
			AddMessage(string.Format(Format, args), MessageType.Criticle);
		}

		public void AddCriticleMessage(string Content)
		{
			AddMessage(Content, MessageType.Criticle);
		}


		public IEnumerable<string> GetInfoMessages()
		{
			return GetMessages(MessageType.Info);
		}

		public IEnumerable<string> GetSuccessMessages()
		{
			return GetMessages(MessageType.Success);
		}

		public IEnumerable<string> GetWarningMessages()
		{
			return GetMessages(MessageType.Warning);
		}

		public IEnumerable<string> GetCriticleMessages()
		{
			return GetMessages(MessageType.Criticle);
		}

		public void AddMessage(string Content, MessageType Type)
		{
			AddMessage(new Message(Content, Type));
		}

		public void AddMessage(Message Message)
		{
			Messages.Add(Message);
			Storage.Save(Messages);
		}

		public IEnumerable<string> GetMessages(MessageType Type)
		{
			return Messages.Where(m => m.Type == Type)
						   .Select(m => m.Content);
		}

		public IEnumerable<Message> GetAllMessages()
		{
			return Messages;
		}

	}
}