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

        #endregion


    }
}
