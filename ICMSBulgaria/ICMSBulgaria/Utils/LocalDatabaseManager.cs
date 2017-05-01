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
                    InitSpeakersTable();
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

        private static void InitSpeakersTable()
        {
            string dbPath = FileHelper.GetLocalFilePath(DATABASE_NAME);

            using (var db = new SQLite.SQLiteConnection(dbPath))
            {
                if (TableExists<Speaker>(db))
                {
                    return;
                }

                db.CreateTable<Speaker>();

                var prSpeaker = new Speaker { Name = "Dr. Mike Clark ", Image = "Assets/mikeclark.jpg", Url = "http://icmsbg.org/speaker/dr-mike-clark/", Possition = "MD" };
                db.Insert(prSpeaker);

                prSpeaker = new Speaker { Name = "Prof. Parveen Kumar", Image = "Assets/parveenkumar.jpg", Url = "http://icmsbg.org/speaker/prof-parveen-kumar/", Possition = "CBE, BSc, MD, FRCP, FRCP(E)" };
                db.Insert(prSpeaker);

                prSpeaker = new Speaker { Name = "Prof. Gianni Angelini ", Image = "Assets/gianniangelini.jpg", Url = "http://icmsbg.org/speaker/prof-gianni-angelini/", Possition = "MD, MCh, FRCS, FETCS, FMedSci" };
                db.Insert(prSpeaker);

                prSpeaker = new Speaker { Name = "Dr. Rebecca Spencer ", Image = "Assets/rebeccaspencer.jpg", Url = "http://icmsbg.org/speaker/dr-rebecca-spencer/", Possition = "MD" };
                db.Insert(prSpeaker);

                prSpeaker = new Speaker { Name = "Prof. Robert Thomas ", Image = "Assets/robertthomas.jpg", Url = "http://icmsbg.org/speaker/prof-robert-thomas-2/", Possition = "Mb, ChB, MRCP, MD, FRCR" };
                db.Insert(prSpeaker);

                prSpeaker = new Speaker { Name = "Prof. Tomas Hanke ", Image = "Assets/tomashanke.jpg", Url = "http://icmsbg.org/speaker/prof-tomas-hanke/", Possition = "MSc BSc PhD" };
                db.Insert(prSpeaker);
            }

        }

        public static List<Speaker> GetSpeakers()
        {
            using (var conn = new SQLite.SQLiteConnection(FileHelper.GetLocalFilePath(DATABASE_NAME)))
            {
                var entities = conn.Table<Speaker>().OrderBy(m => m.ID).ToList();
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