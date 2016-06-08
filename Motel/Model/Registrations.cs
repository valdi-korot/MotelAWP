namespace Motel.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Registrations
    {
        public int Id { get; set; }

        public int Id_Client { get; set; }

        public int? Id_Number { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateInsert { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOut { get; set; }

        public int? Cost { get; set; }

        public virtual Clients Clients { get; set; }

        public virtual Numbers Numbers { get; set; }
    }
}
