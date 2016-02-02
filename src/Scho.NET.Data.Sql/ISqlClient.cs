using System.Data;

namespace Scho.NET.Data.Sql
{
	public interface ISqlClient
	{
		DataRowCollection ExecuteSP(string StoredProcedure);
		DataRowCollection ExecuteSP(string StoredProcedure, object[][] Params);
		DataRowCollection ExecuteQuery(string Query);
	}
}
