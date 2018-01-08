using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTERcollector
{
    public class Configuration
    {
        #region Fields



        #endregion


        #region Properties

        public string this[string key]
        {
            get
            {
                lock (_syncLocker)
                {
                    if (_settingDic.ContainsKey(key))
                    {
                        return _settingDic[key];
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            set
            {
                lock (_syncLocker)
                {
                    if (_settingDic.ContainsKey(key))
                    {
                        using (var context = Framework.GetInstance().Database.GetCurrentContext())
                        {
                            context.SetSetting(key, value);
                        }
                        _settingDic[key] = value;
                    }
                    else
                    {
                        using (var context = Framework.GetInstance().Database.GetCurrentContext())
                        {
                            context.SetSetting(key, value);
                        }
                        _settingDic.Add(key, value);
                    }
                }
            }
        }


        #endregion

        #region Fields

        private Dictionary<string, string> _settingDic = new Dictionary<string, string>();
        private readonly object _syncLocker = new object();

        #endregion


        #region Contructor

        internal Configuration()
        {
            Framework.GetInstance().Database.GetCurrentContext().EnumSettings((index, key, value) =>
            {
                _settingDic.Add(key, value);
            });
        }

        #endregion

        #region Public Functions


        #endregion

    }
}
