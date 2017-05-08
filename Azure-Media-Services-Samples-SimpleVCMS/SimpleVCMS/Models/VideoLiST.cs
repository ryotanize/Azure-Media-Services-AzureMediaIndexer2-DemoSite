namespace SimpleVCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VideoLiST")]
    public partial class VideoLiST
    {
        [Key]
        [StringLength(250)]
        public string FileName { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [StringLength(500)]
        public string PlayerURL { get; set; }

        [StringLength(500)]
        public string CCja { get; set; }

        [StringLength(500)]
        public string CCen { get; set; }

        [StringLength(500)]
        public string CCfr { get; set; }

        [StringLength(500)]
        public string CCde { get; set; }

        [StringLength(500)]
        public string CCko { get; set; }

        [StringLength(500)]
        public string CCzhCHS { get; set; }

        [StringLength(500)]
        public string CCes { get; set; }
    }
}
