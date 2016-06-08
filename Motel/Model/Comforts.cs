namespace Motel.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comforts
    {
        public int Id { get; set; }

        public int Id_Number { get; set; }

        [StringLength(40)]
        public string Name { get; set; }

        public virtual Numbers Numbers { get; set; }
    }
}
