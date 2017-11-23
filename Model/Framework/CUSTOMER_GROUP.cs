namespace Model.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CUSTOMER_GROUP
    {
        [Key]
        [StringLength(20)]
        public string Customer_Group_ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Customer_Group_Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public bool Active { get; set; }
    }
}
