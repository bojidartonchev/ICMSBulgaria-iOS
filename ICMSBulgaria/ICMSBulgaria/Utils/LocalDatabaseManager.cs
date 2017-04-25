using ICMSBulgaria.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICMSBulgaria.Utils
{
    public static class LocalDatabaseManager
    {
        private static string DATABASE_NAME = "ICMSDatabase.db3";
        static LocalDatabaseManager()
        {
            if(!File.Exists(FileHelper.GetLocalFilePath(DATABASE_NAME)))
            {
                using (var conn = new SQLite.SQLiteConnection(FileHelper.GetLocalFilePath(DATABASE_NAME)))
                {
                    InitProgramEventsTable();
                }
            }            
        }

        private static void InitProgramEventsTable()
        {
            string dbPath = FileHelper.GetLocalFilePath(DATABASE_NAME);

            using (var db = new SQLite.SQLiteConnection(dbPath))
            {
                if(TableExists<ProgramEvent>(db))
                {
                    return;
                }

                db.CreateTable<ProgramEvent>();

                var prEvent = new ProgramEvent { Title = "John ", Content = "Doe", Date = "May 22", Time = "14:20" };
                db.Insert(prEvent);

                prEvent = new ProgramEvent { Title = "John1 ", Content = "Doe1", Date = "May 221", Time = "14:21" };
                db.Insert(prEvent);

                prEvent = new ProgramEvent { Title = "John2 ", Content = "Doe2", Date = "May 222", Time = "14:22" };
                db.Insert(prEvent);
            }

        }

        public static List<ProgramEvent> GetProgramEvents()
        {
            using (var conn = new SQLite.SQLiteConnection(FileHelper.GetLocalFilePath(DATABASE_NAME)))
            {
                var entities = conn.Table<ProgramEvent>().OrderBy(m => m.ID).ToList();
                return entities;
            }            
        }

        public static bool TableExists<T>(SQLiteConnection connection)
        {
            const string cmdText = "SELECT name FROM sqlite_master WHERE type='table' AND name=?";
            var cmd = connection.CreateCommand(cmdText, typeof(T).Name);
            return cmd.ExecuteScalar<string>() != null;
        }
    }
}