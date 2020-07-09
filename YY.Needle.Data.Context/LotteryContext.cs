using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YY.Needle.Data.Context.Config;
using YY.Needle.Data.Context.Mapping;
using YY.Needle.Domain.Entities;

namespace YY.Needle.Data.Context
{
  


    public class LotteryContext : BaseDbContext
    {
        static LotteryContext()
        {
           // Database.SetInitializer(new ContextInitializer());
        }

        public LotteryContext()
            : base("LotteryEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new Lottery3DMap());
            modelBuilder.Configurations.Add(new Average3DMap());
        
        }

        #region DbSet

        public DbSet<Lottery3D> Lottery3Ds { get; set; }

        public DbSet<Average3D> Average3Ds { get; set; }
      
        #endregion
    }
}
