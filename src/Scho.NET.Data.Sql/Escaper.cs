namespace Scho.NET.Data.Sql
{

	/// <summary>
	/// Static wrapper for escaping Sql special charecters
	/// </summary>
	public static class Escaper
	{

		/// <summary>
		/// Escapes quotes in SQL
		/// </summary>
		/// <param name="Value"></param>
		/// <returns></returns>
		public static string EscapeQuotes(string Value)
		{
			return Value.Replace("'", "''");
		}
	}
}
