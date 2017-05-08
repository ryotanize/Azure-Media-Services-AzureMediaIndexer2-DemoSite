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

        [StringLength(1024)]
        public string PlayerURL { get; set; }

        [StringLength(1024)]
        public string CCja { get; set; }

        [StringLength(1024)]
        public string CCen { get; set; }

        [StringLength(1024)]
        public string CCko { get; set; }

        [StringLength(1024)]
        public string CCzhCHS { get; set; }
    }
}
