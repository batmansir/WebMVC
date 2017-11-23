namespace Model.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CUSTOMER")]
    public partial class CUSTOMER
    {
        [Key]
        [StringLength(20)]
        public string Customer_ID { get; set; }

        public long? OrderID { get; set; }

        [Required]
        [StringLength(255)]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(20)]
        public string Customer_Type_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Customer_Group_ID { get; set; }

        [StringLength(255)]
        public string CustomerAddress { get; set; }

        public DateTime? Birthday { get; set; }

        [StringLength(20)]
        public string Barcode { get; set; }

        [StringLength(20)]
        public string Tax { get; set; }

        [StringLength(20)]
        public string Tel { get; set; }

        [StringLength(20)]
        public string Fax { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Mobile { get; set; }

        [StringLength(100)]
        public string Website { get; set; }

        [StringLength(100)]
        public string Contact { get; set; }

        [StringLength(100)]
        public string Position { get; set; }

        [StringLength(20)]
        public string NickYM { get; set; }

        [StringLength(20)]
        public string NickSky { get; set; }

        [StringLength(100)]
        public string Area { get; set; }

        [StringLength(100)]
        public string District { get; set; }

        [StringLength(100)]
        public string Contry { get; set; }

        [StringLength(100)]
        public string City { get; set; }

        [StringLength(20)]
        public string BankAccount { get; set; }

        [StringLength(100)]
        public string BankName { get; set; }

        [Column(TypeName = "money")]
        public decimal? CreditLimit { get; set; }

        [Column(TypeName = "money")]
        public decimal? Discount { get; set; }

        public bool? IsDebt { get; set; }

        public bool? IsDebtDetail { get; set; }

        public bool? IsProvider { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public bool? Active { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}
