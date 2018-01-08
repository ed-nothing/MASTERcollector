using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using System.Collections.Generic;

namespace MASTERcollector.Database
{
    internal class DatabaseContext : DbContext
    {
        #region Constructor

        internal DatabaseContext(string name) :
            base(name)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


        #endregion

        #region Entities

        public virtual DbSet<Entities.Setting> Settings { get; set; }
        public virtual DbSet<Entities.Plugin> Plugins { get; set; }

        #endregion

        internal void EnumSettings(Action<int, string, string> predicate)
        {
            var results = from Setting in this.Settings.AsNoTracking() select Setting;
            int i = 0;
            foreach (var result in results)
            {
                predicate(i++, result.Key, result.Value);
            }
        }

        internal void SetSetting(string key, string value)
        {
            var setting = (from TSetting in Settings where TSetting.Key == key select TSetting).FirstOrDefault();
            if(setting == null)
            {
                setting = new Entities.Setting();
                setting.Key = key;
                setting.Value = value;
                this.Settings.Add(setting);
                this.SaveChanges();
            }
            else
            {
                setting.Value = value;
                this.SaveChanges();
            }
        }

        /// <summary>
        /// Get the Value of the setting sepcified by Key
        /// </summary>
        /// <param name="key">The unique Key to the Setting</param>
        /// <param name="defaultValue">If there is no such a Setting in the database and the defaultValue is valid, the defaultValue will be returned. And also Setting with the Key and the defaultValue will be stored in the database.</param>
        /// <returns></returns>
        internal string GetSetting(string key,string defaultValue = null)
        {
            var setting = (from TSetting in Settings.AsNoTracking() where TSetting.Key == key select TSetting).FirstOrDefault();
            if (setting == null)
            {
                if (defaultValue != null)
                {
                    setting = new Entities.Setting();
                    setting.Key = key;
                    setting.Value = defaultValue;
                    this.Settings.Add(setting);
                    this.SaveChanges();
                    return defaultValue;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return setting.Value;
            }
        }

        protected override void Dispose(bool disposing)
        {
            Framework.GetInstance().Database.ReleaseCurrentContext(this);
            base.Dispose(disposing);
        }
    }
}
