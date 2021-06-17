using SQLite;
using System;
namespace NetworkingDBProject
{
    public interface ISOLiteDb
    {
         SQLiteAsyncConnection GetConnection();
    }
}