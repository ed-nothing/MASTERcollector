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

        private const string SQLITE_DATABASE_FILE_NAME = "database.db";

        #endregion

        #region Singleton Support

        static Framework _instance = new Framework();

        public static Framework GetInstance()
        {
            return _instance;
        }

        #endregion

        #region Fields

        private bool _isInitalized = false;
        private Database.Database _database;
        private Configuration _configuration;

        #endregion

        #region Properties

        internal Database.Database Database { get { return _database; } }
        public Configuration Configuration { get { return _configuration; } }
        public string PluginPath
        {
            get
            {
                return !Environment.CurrentDirectory.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()) ?
                Environment.CurrentDirectory + System.IO.Path.DirectorySeparatorChar.ToString() + "Plugins" :
                Environment.CurrentDirectory + "Plugins";
            }
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

            _isInitalized = true;
        }

        #endregion

        #region Internal Functions

        internal string GetPluginDllPath(Database.Entities.Plugin pluginInfo)
        {
            return PluginPath + System.IO.Path.DirectorySeparatorChar + pluginInfo.Name + "." + pluginInfo.Identity.ToString() + System.IO.Path.DirectorySeparatorChar + pluginInfo.AssamblyName + ".dll";
        }

        #endregion

        #region Private Functions

        private string _GetSqliteDatabaseFilePath()
        {
            return !Environment.CurrentDirectory.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()) ?
                Environment.CurrentDirectory + System.IO.Path.DirectorySeparatorChar.ToString() + SQLITE_DATABASE_FILE_NAME : 
                Environment.CurrentDirectory + SQLITE_DATABASE_FILE_NAME;
        }

        private void _SetupDatabase()
        {
            //We only support Sqlite for now.
            EntityConnectionStringBuilder entityConnectionStringBuilder = new EntityConnectionStringBuilder();

            System.Data.SQLite.SQLiteConnectionStringBuilder cntStringBuilder = new System.Data.SQLite.SQLiteConnectionStringBuilder();
            cntStringBuilder.DataSource = _GetSqliteDatabaseFilePath();
            cntStringBuilder.Pooling = true;

            var configuration = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);

            if (configuration.ConnectionStrings.ConnectionStrings["SQLITE_CNT_STRING"] != null)
            {
                configuration.ConnectionStrings.ConnectionStrings["SQLITE_CNT_STRING"].ConnectionString = cntStringBuilder.ToString();
            }else
            {
                configuration.ConnectionStrings.ConnectionStrings.Add(
                    new System.Configuration.ConnectionStringSettings()
                    {
                        Name = "SQLITE_CNT_STRING",
                        ConnectionString = cntStringBuilder.ConnectionString,
                        ProviderName = "System.Data.SQLite.EF6"
                    });
            }

            configuration.Save();

            _database = new Database.Database("SQLITE_CNT_STRING");
        }

        private void _SetupConfiguration()
        {
            _configuration = new Configuration();
        }

        private void _SetupPlugins()
        {

        }

        #endregion

    }
}
