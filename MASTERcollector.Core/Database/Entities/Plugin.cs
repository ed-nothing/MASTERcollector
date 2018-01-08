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
    [Table("Plugins")]
    internal class Plugin
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Plugin()
        {
        }

        [Key]
        public Guid Identity { get; set; }

        [Required,StringLength(64)]
        public string Name { get; set; }

        [Required,StringLength(256)]
        public string AssamblyName { get; set; }

        [Required, StringLength(256)]
        public string PluginClassPath { get; set; }

        [Required]
        public long Version { get; set; }

    }
}
