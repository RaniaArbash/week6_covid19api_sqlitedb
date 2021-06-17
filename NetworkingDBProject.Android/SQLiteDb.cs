

using System;
using System.IO;
using NetworkingDBProject;
using SQLite;
using NetworkingDBProject.Droid;
using Xamarin.Forms;

[assembly:Dependency(typeof(SQLiteDb))]
namespace NetworkingDBProject.Droid
{
	public class SQLiteDb : ISOLiteDb
	{
		public SQLiteAsyncConnection GetConnection()
		{
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			var path = Path.Combine(documentsPath, "test.db3");

			return new SQLiteAsyncConnection(path);
		}
	}

}