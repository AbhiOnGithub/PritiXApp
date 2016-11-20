using PritiXApp.Models;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace PritiXApp.DataLayer
{
    /// <summary>
    /// Class to manage local SQLite DB Operations
    /// </summary>
    public class PritixDatabase
    {
        private static object locker = new object();
        private SQLiteConnection database;

        /// <summary>
        /// Initializes a new instance of the DB. 
        /// if the database doesn't exist, it will create the database and all the tables.
        /// </summary>
        /// <param name='path'>
        /// Path.
        /// </param>
        public PritixDatabase()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            
            // create the tables
            database.CreateTable<EnglishWord>();
            database.CreateTable<DutchWord>();
            database.CreateTable<FrenchWord>();
            database.CreateTable<GermanWord>();
        }

        /// <summary>
        /// Get List of words from SQLiteDB
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public IEnumerable<IWord> GetWords(Consts.Languages language)
        {
            lock (locker)
            {
                switch(language)
                {
                    case Consts.Languages.English:
                        return (from i in database.Table<EnglishWord>() select i).ToList();
                    case Consts.Languages.Dutch:
                        return (from i in database.Table<DutchWord>() select i).ToList();
                    case Consts.Languages.French:
                        return (from i in database.Table<FrenchWord>() select i).ToList();
                    case Consts.Languages.German:
                        return (from i in database.Table<GermanWord>() select i).ToList();
                    default:
                        return new List<IWord>();
                }
            }
        }

        //public IEnumerable<IWord> GetItemsNotDone()
        //{
        //    lock (locker)
        //    {
        //        return database.Query<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        //    }
        //}

        /// <summary>
        /// Get Word by Id from SQLite DB
        /// </summary>
        /// <param name="id"></param>
        /// <param name="lang"></param>
        /// <returns></returns>
        public IWord GetWord(int id,Consts.Languages lang)
        {
            lock (locker)
            {
                switch (lang)
                {
                    case Consts.Languages.English:
                        return database.Table<EnglishWord>().FirstOrDefault(x => x.Id == id);
                    case Consts.Languages.Dutch:
                        return database.Table<DutchWord>().FirstOrDefault(x => x.Id == id);
                    case Consts.Languages.French:
                        return database.Table<FrenchWord>().FirstOrDefault(x => x.Id == id);
                    case Consts.Languages.German:
                        return database.Table<GermanWord>().FirstOrDefault(x => x.Id == id);
                    default:
                        return null;
                }
                
            }
        }

        /// <summary>
        /// Update or Insert the word into SQLite DB
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public int SaveWord(IWord word)
        {
            lock (locker)
            {
                if (word.Id != 0)
                {
                    database.Update(word);
                    return word.Id;
                }
                else
                {
                    return database.Insert(word);
                }
            }
        }

        /// <summary>
        /// Delete the word from SQLite DB
        /// </summary>
        /// <param name="id"></param>
        /// <param name="lang"></param>
        /// <returns></returns>
        public int DeleteWord(int id,Consts.Languages lang)
        {
            lock (locker)
            {
                switch (lang)
                {
                    case Consts.Languages.English:
                        return database.Delete<EnglishWord>(id);
                    case Consts.Languages.Dutch:
                        return database.Delete<DutchWord>(id);
                    case Consts.Languages.French:
                        return database.Delete<FrenchWord>(id);
                    case Consts.Languages.German:
                        return database.Delete<GermanWord>(id);
                    default:
                        return -1;
                }                
            }
        }
    }
}