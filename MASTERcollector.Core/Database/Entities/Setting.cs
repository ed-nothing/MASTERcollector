using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using System.Collections.Generic;

namespace MASTERcollector.Database.Entities
{
    [Table("Settings")]
    internal class Setting
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Setting()
        {
        }

        [Key, MaxLength(64), Required]
        public string Key { get; set; }

        [Required]
        public string Value { get; set; }
    }
}
