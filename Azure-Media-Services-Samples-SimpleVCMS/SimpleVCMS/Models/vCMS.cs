namespace SimpleVCMS.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class vCMS : DbContext
    {
        public vCMS()
            : base("name=vCMS")
        {
        }

        public virtual DbSet<VideoLiST> VideoLiST { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
