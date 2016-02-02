using Scho.NET.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scho.NET.FlashMessenger.Storage
{
	public class MessageRepository : IMessageStorage
	{
		private readonly IRepository<Message> Repository;

		public MessageRepository(IRepository<Message> repository)
		{
			Repository = repository;
		}

		public IEnumerable<Message> Read()
		{
			return Repository.GetAll();
		}

		public void Save(IEnumerable<Message> messages)
		{
			Repository.AddRange(messages);
		}
	}
}
