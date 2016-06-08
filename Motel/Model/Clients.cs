namespace Motel.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Clients
    {
        public Clients()
        {
            Registrations = new HashSet<Registrations>();
        }

        public int Id { get; set; }

        [StringLength(30)]
        public string LName { get; set; }

        [StringLength(30)]
        public string FName { get; set; }

        [StringLength(30)]
        public string MName { get; set; }

        [StringLength(30)]
        public string Address { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(30)]
        public string PassNumber { get; set; }
        public string FIO
        {
            get
            {
                string str=LName.Replace(" ","")+" "+FName.Replace(" ","")+" "+MName.Replace(" ","");
                return str;
            }
        }

        public virtual ICollection<Registrations> Registrations { get; set; }
    }
}
