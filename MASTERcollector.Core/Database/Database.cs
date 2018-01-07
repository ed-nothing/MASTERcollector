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

        private DatabaseContext _dbContext;

        #endregion

        #region Contructor

        internal Database(string configurationName)
        {
            Initialize(configurationName);
        }

        #endregion

        #region Internal Functions

        internal DatabaseContext GetContext()
        {
            return _dbContext;
        }

        internal void EnumSettings(Action<int, string, string> predicate)
        {
            var results = from Setting in _dbContext.Settings.AsNoTracking() select Setting;
            int i = 0;
            foreach(var result in results)
            {
                predicate(i++, result.Key, result.Value);
            }
        }

        #endregion

        #region Private Functions

        private void Initialize(string configurationName)
        {
            _dbContext = new DatabaseContext(configurationName);
        }

        #endregion
    }
}
