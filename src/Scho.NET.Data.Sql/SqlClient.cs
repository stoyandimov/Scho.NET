using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Scho.NET.Data.Sql
{
	public class SqlClient : ISqlClient
	{

		private string _ConnectionString { get; set; }

		public SqlClient(string ConnectionString)
		{
			_ConnectionString = ConnectionString;
		}

		/// <summary>
		/// Executes a command and returns DataRowCollection
		/// </summary>
		/// <param name="Command"></param>
		/// <returns></returns>
		private DataRowCollection Execute(SqlCommand Command)
		{
			var Set = new DataSet();
			using (SqlConnection Conn = new SqlConnection(_ConnectionString))
			{
				try
				{
					Conn.Open();
					Command.Connection = Conn;
					var Adapter = new SqlDataAdapter(Command);
					Adapter.Fill(Set);
				}
				catch (SqlException SqlEx)
				{
					throw new Exception(
						String.Format("Executing SQL command failed! [Command: {0}]", Command.CommandText), SqlEx);
				}
				catch (Exception Ex)
				{
					throw new Exception(
						String.Format("Executing SQL command failed!", Ex));
				}
			}
			if (Set.Tables.Count == 0)
			{
				Set.Tables.Add();
			}

			return Set.Tables[0].Rows;
		}


		/// <summary>
		/// Executes a parameterless stored procedure and returns a DataRowCollection
		/// </summary>
		/// <param name="StoredProcedure"></param>
		/// <returns></returns>
		public DataRowCollection ExecuteSP(string StoredProcedure)
		{
			using (var Command = new SqlCommand(StoredProcedure))
			{
				Command.CommandType = CommandType.StoredProcedure;
				return Execute(Command);
			}
		}

		/// <summary>
		/// Executes stored procedure with parameters and returns a DataRowCollection
		/// </summary>
		/// <param name="StoredProcedure"></param>
		/// <param name="Params"></param>
		/// <returns></returns>
		public DataRowCollection ExecuteSP(string StoredProcedure, object[][] Params)
		{
			using (var Command = new SqlCommand(StoredProcedure))
			{
				Command.CommandType = CommandType.StoredProcedure;
				if (Params != null && Params.Count() > 0)
				{
					foreach (object[] Pair in Params)
					{
						Command.Parameters.AddWithValue(Pair[0].ToString(), Pair[1]);
					}
				}

				return Execute(Command);
			}
		}

		/// <summary>
		/// ExecuteQuery Execute an SQL Statement 
		/// </summary>
		/// <returns></returns>
		public DataRowCollection ExecuteQuery(string Query)
		{
			using (var Command = new SqlCommand(Query))
			{
				Command.CommandType = CommandType.Text;
				return Execute(Command);
			}
		}
	}
}
