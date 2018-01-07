using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTERcollector
{
    public class Framework
    {

        #region Constant

        private const string SQLITE_DATABASE_FILE_NAME = "database.dat";

        #endregion

        #region Singleton Support

        static Framework _instance = new Framework();

        public Framework GetInstance()
        {
            return _instance;
        }

        #endregion

        #region Constructor&Destoryer

        private Framework()
        {
            //
        }

        #endregion

        #region Public Function

        public void Initialize()
        {
            _SetupDatabase();
            _SetupConfiguration();
            _SetupPlugins();
        }

        #endregion

        #region Private Functions

        private string _GetSqliteDatabaseFilePath()
        {
            return !Environment.CurrentDirectory.EndsWith(System.IO.Path.PathSeparator.ToString()) ?
                Environment.CurrentDirectory + System.IO.Path.PathSeparator.ToString() + SQLITE_DATABASE_FILE_NAME : 
                Environment.CurrentDirectory + SQLITE_DATABASE_FILE_NAME;
        }

        private void _SetupDatabase()
        {
            //We only support Sqlite for now.
            EntityConnectionStringBuilder entityConnectionStringBuilder = new EntityConnectionStringBuilder();

            System.Data.SQLite.SQLiteConnectionStringBuilder cntStringBuilder = new System.Data.SQLite.SQLiteConnectionStringBuilder();
            cntStringBuilder.DataSource = _GetSqliteDatabaseFilePath();
            cntStringBuilder.Pooling = true;

            if (System.Configuration.ConfigurationManager.ConnectionStrings["SQLITE_CNT_STRING"] != null)
            {
                System.Configuration.ConfigurationManager.ConnectionStrings["SQLITE_CNT_STRING"].ConnectionString = cntStringBuilder.ToString();
            }


        }

        private void _SetupConfiguration()
        {

        }

        private void _SetupPlugins()
        {

        }

        #endregion

    }
}
