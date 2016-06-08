namespace Motel.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Numbers
    {
        public Numbers()
        {
            Comforts = new HashSet<Comforts>();
            Registrations = new HashSet<Registrations>();
        }

        public int Id { get; set; }

        [StringLength(30)]
        public string Type_number { get; set; }

        public int? Cost { get; set; }

        public virtual ICollection<Comforts> Comforts { get; set; }

        public virtual ICollection<Registrations> Registrations { get; set; }
    }
}
