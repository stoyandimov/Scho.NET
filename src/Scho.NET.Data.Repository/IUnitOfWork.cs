using System;

namespace Scho.NET.Data.Repository
{
	public interface IUnitOfWork : IDisposable
	{
		int Complete();
	}
}
