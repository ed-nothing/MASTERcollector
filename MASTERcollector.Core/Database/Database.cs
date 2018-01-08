using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTERcollector.Database
{
    public class Database
    {
        #region Enums

        #endregion

        #region Fields

        [ThreadStatic]
        private DatabaseContext _dbContext;
        private string _databaseName;

        #endregion

        #region Contructor

        internal Database(string configurationName)
        {
            Initialize(configurationName);
        }

        #endregion

        #region Internal Functions

        internal DatabaseContext GetCurrentContext()
        {
            if (_dbContext == null)
                _dbContext = new DatabaseContext(_databaseName);

            return _dbContext;
        }

        internal void ReleaseCurrentContext(object context)
        {
            if (_dbContext == context)
            {
                _dbContext = null;
            }
        }

        #endregion

        #region Private Functions

        private void Initialize(string configurationName)
        {
            _databaseName = configurationName;
        }

        #endregion
    }
}
