using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ADONetMovie_RazorPages.Models
{
    [Table("Studio")]
    public partial class Studio
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Column("HQCity")]
        [StringLength(30)]
        public string Hqcity { get; set; }
        public int NoOfEmployees { get; set; }
    }
}
