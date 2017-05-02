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
                    InitNetworkingTable();
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

                //11 May
                var prEvent = new ProgramEvent { Title = "Registration ", Location = "Main Congress Venue", Date = "May 11", Time = "11:00 – 18:00" };
                db.Insert(prEvent);

                prEvent = new ProgramEvent { Title = "Opening Ceremony ", Location = "St. Ekaterina Aula Maxima", Date = "May 11", Time = "19:00 – 20:00" };
                db.Insert(prEvent);
                //End 11 May

                //12 May
                prEvent = new ProgramEvent { Title = "Workshops ", Location = "Rooms announced on the next pages", Date = "May 12", Time = "9:00- 11:00" };
                db.Insert(prEvent);

                prEvent = new ProgramEvent { Title = "Coffee Break ", Location = "Main Congress Venue 4th Floor", Date = "May 12", Time = "11:00 – 11:15" };
                db.Insert(prEvent);

                prEvent = new ProgramEvent { Title = "Preclinic Oral and Poster Sessions I ", Location = "'Zdrave' Lecture Hall I", Date = "May 12", Time = "11:15 – 13:00" };
                db.Insert(prEvent);

                prEvent = new ProgramEvent { Title = "Therapy Oral and Poster Sessions I ", Location = "'Zdrave' Lecture Hall II", Date = "May 12", Time = "11:15 – 13:00" };
                db.Insert(prEvent);

                prEvent = new ProgramEvent { Title = "Lunch Break ", Location = "Main Congress Venue 4th Floor", Date = "May 12", Time = "13:00 – 13:30" };
                db.Insert(prEvent);

                prEvent = new ProgramEvent { Title = "Preclinic Oral and Poster Sessions II ", Location = "'Zdrave' Lecture Hall I", Date = "May 12", Time = "13:30 – 15:15" };
                db.Insert(prEvent);

                prEvent = new ProgramEvent { Title = "Therapy Oral and Poster Sessions II ", Location = "'Zdrave' Lecture Hall II", Date = "May 12", Time = "13:30 – 15:15" };
                db.Insert(prEvent);

                prEvent = new ProgramEvent { Title = "Coffee Break ", Location = "Main Congress Venue 4th Floor", Date = "May 12", Time = "15:15 – 15:30" };
                db.Insert(prEvent);

                prEvent = new ProgramEvent { Title = "Preclinic Oral and Poster Sessions III ", Location = "'Zdrave' Lecture Hall I", Date = "May 12", Time = "15:30 – 17:15" };
                db.Insert(prEvent);

                prEvent = new ProgramEvent { Title = "Therapy Oral and Poster Sessions III ", Location = "'Zdrave' Lecture Hall II", Date = "May 12", Time = "15:30 – 17:15" };
                db.Insert(prEvent);

                prEvent = new ProgramEvent { Title = "ICMS Special talks Assoc. Prof. Andrey Galev “Current vaccine prophylaxis: summary and key facts”", Location = "Main Congress Venue 4th Floor", Date = "May 12", Time = "17:15 – 17:35" };
                db.Insert(prEvent);

                prEvent = new ProgramEvent { Title = "Keynote Lecture by Dr. Rebecca Spencer The ‘EVERREST’ Project: Can maternal gene therapy treat severe growth restriction?", Location = "St. Ekaterina Aula Maxima", Date = "May 12", Time = "17:40 – 19:10" };
                db.Insert(prEvent);
                //End 12 May

                //13 May
                prEvent = new ProgramEvent { Title = "Workshops", Location = "Main Congress Venue Rooms announced on the next pages", Date = "May 13", Time = "9:00- 11:00" };
                db.Insert(prEvent);

                prEvent = new ProgramEvent { Title = "Coffee Break", Location = "Main Congress Venue 4th Floor", Date = "May 13", Time = "11:00 – 11:15" };
                db.Insert(prEvent);

                prEvent = new ProgramEvent { Title = "Keynote Lecture by Prof. Robert Thomas 'Evidence for Lifestyle and nutritional strategies in the prevention and treatment of cancer and other chronic medical conditions'", Location = "St. Ekaterina Aula Maxima", Date = "May 13", Time = "11:15 – 12:45" };
                db.Insert(prEvent);

                prEvent = new ProgramEvent { Title = "Lunch Break", Location = "Main Congress Venue 4th Floor", Date = "May 13", Time = "12:45 – 13:15" };
                db.Insert(prEvent);

                prEvent = new ProgramEvent { Title = "Surgery Oral and Poster Sessions I", Location = "'Zdrave' Lecture Hall I", Date = "May 13", Time = "13:15 – 15:00" };
                db.Insert(prEvent);

                prEvent = new ProgramEvent { Title = "Dentistry Oral Session", Location = "'Zdrave' Lecture Hall II", Date = "May 13", Time = "13:15 – 15:00" };
                db.Insert(prEvent);

                prEvent = new ProgramEvent { Title = "Public Health and Medical Education Sessions", Location = "'Zdrave' Lecture Hall III", Date = "May 13", Time = "13:15 – 15:00" };
                db.Insert(prEvent);

                prEvent = new ProgramEvent { Title = "Coffee Break", Location = "Main Congress Venue 4th Floor", Date = "May 13", Time = "15:00 – 15:15" };
                db.Insert(prEvent);

                prEvent = new ProgramEvent { Title = "Surgery Oral and Poster Sessions II", Location = "'Zdrave' Lecture Hall I", Date = "May 13", Time = "15:15 – 16:45" };
                db.Insert(prEvent);

                prEvent = new ProgramEvent { Title = "Dentistry Poster Session", Location = "'Zdrave' Lecture Hall II", Date = "May 13", Time = "15:15 – 16:45" };
                db.Insert(prEvent);

                prEvent = new ProgramEvent { Title = "Coffee Break", Location = "Foyer of St. Ekaterina Hospital", Date = "May 13", Time = "16:45 – 17:00" };
                db.Insert(prEvent);

                prEvent = new ProgramEvent { Title = "Keynote Lecture (Prof. Tomas Hanke) “Attacking HIV where it hurts”", Location = "St. Ekaterina Aula Maxima", Date = "May 13", Time = "17:00 – 18:30" };
                db.Insert(prEvent);

                prEvent = new ProgramEvent { Title = "ICMS Special talks Àssoc. Prof. Borislav Georgiec “Arterial hypertension”", Location = "St. Ekaterina Aula Maxima", Date = "May 13", Time = "18:30 – 18:30" };
                db.Insert(prEvent);
                //End 13 May

                //14 May
                prEvent = new ProgramEvent { Title = "Workshops", Location = "Main Congress Venue Rooms announced on the next pages", Date = "May 14", Time = "9:45- 11:45" };
                db.Insert(prEvent);

                prEvent = new ProgramEvent { Title = "Lunch break", Location = "Main Congress Venue 4th Floor", Date = "May 14", Time = "11:45- 12:15" };
                db.Insert(prEvent);

                prEvent = new ProgramEvent { Title = "Keynote Lecture: Prof. Gianni Angelini ‘Taking Engineering to the Heart’", Location = "St. Ekaterina Aula Maxima", Date = "May 14", Time = "12:15- 13:45" };
                db.Insert(prEvent);

                prEvent = new ProgramEvent { Title = "Coffee break", Location = "Foyer of St. Ekaterina Hospital", Date = "May 14", Time = "13:45- 14:00" };
                db.Insert(prEvent);

                prEvent = new ProgramEvent { Title = "Poster Presentation Finals", Location = "Foyer of St. Ekaterina Hospital", Date = "May 14", Time = "14:00- 14:45" };
                db.Insert(prEvent);

                prEvent = new ProgramEvent { Title = "Oral Presentation Finals", Location = "St. Ekaterina Aula Maxima", Date = "May 14", Time = "15:00- 15:45" };
                db.Insert(prEvent);

                prEvent = new ProgramEvent { Title = "Coffee break", Location = "Foyer of St. Ekaterina Hospital", Date = "May 14", Time = "15:45- 16:00" };
                db.Insert(prEvent);

                prEvent = new ProgramEvent { Title = "Duet Keynote Lecture: Prof. Parveen Kumar “Life is Not A Rehearsal” Dr. Michael Clark “The Challenges Of Writing A Medical Textbook”", Location = "St. Ekaterina Aula Maxima", Date = "May 14", Time = "16:00- 17:30" };
                db.Insert(prEvent);

                prEvent = new ProgramEvent { Title = "Closing Ceremony", Location = "St. Ekaterina Aula Maxima", Date = "May 14", Time = "17:30- 18:30" };
                db.Insert(prEvent);
                //End 14 May
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

        private static void InitNetworkingTable()
        {
            string dbPath = FileHelper.GetLocalFilePath(DATABASE_NAME);

            using (var db = new SQLite.SQLiteConnection(dbPath))
            {
                if (TableExists<Networking>(db))
                {
                    return;
                }

                db.CreateTable<Networking>();

                var prNetworking = new Networking { Title = "“Welcome” cocktail", Content = "It’ll take place at the Main Congress Venue on " +
                    "the 2nd Floor at 20:00h right after official opening ceremony. Participants will get the chance " +
                    "to introduce themselves, meet fellow colleagues and start making new friendships and unforgettable" +
                    " memories.", Location = "Main Congress Venue 2nd Floor", Date = "Thursday, 11 May 2017, 20:00h"
                };
                db.Insert(prNetworking);

                prNetworking = new Networking
                {
                    Title = "“As Bulgarians” the project",
                    Content = "This event will take place at …………." +
                    " at 20:00h. When you are participating ICMS 2017 you are obviously smart. But do you dare " +
                    "to try dancing and acting like traditional Bulgarians? If you have the required courage we are " +
                    "gladly expecting you.  We have organized for you an evening with typical Bulgarian cuisine and dances." +
                    " The entertainment is guaranteed for sure!",
                    Location = "*The meeting point will be ………...",
                    Date = "Friday, 12 May 2017, 20:00h"
                };
                db.Insert(prNetworking);

                prNetworking = new Networking
                {
                    Title = "Free Sofia Walk Tour",
                    Content = "We provide you an opportunity to dive into Sofia, to dive into history." +
                    " Through out to more than 1300 years you will have the chance to explore one of the oldest culture in Europe. " +
                    "The tour will take you to the temples and monuments emblematic for our country and folks.",
                    Location = "National Palace of Culture",
                    Date = "Saturday, 13 May 2017, 19:30h"
                };
                db.Insert(prNetworking);

                prNetworking = new Networking
                {
                    Title = "Closing party",
                    Content = "We invite to private closing party to rock on together one last time.Suit up because " +
                    "the Theme of the party will be “Bone Marrow”. Your dress code must include Erythrocytes (red color), Leukocytes " +
                    "(white color) or Plate cells (black color). To get your free welcome drink at the entrance make sure to say the special " +
                    "password. PASSWORD: I’m not a virus!!!",
                    Location = "NDK, 1 Bulgaria Square",
                    Date = "Sunday, 14 May 2017, 22:00h"
                };
                db.Insert(prNetworking);
            }

        }

        public static List<Networking> GetNetworking()
        {
            using (var conn = new SQLite.SQLiteConnection(FileHelper.GetLocalFilePath(DATABASE_NAME)))
            {
                var entities = conn.Table<Networking>().OrderBy(m => m.ID).ToList();
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