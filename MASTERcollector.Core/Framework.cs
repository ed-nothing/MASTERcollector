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

        private void _SetupDatabase()
        {
            EntityConnectionStringBuilder cntStringBuilder = new EntityConnectionStringBuilder();
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
