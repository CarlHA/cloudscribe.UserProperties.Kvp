﻿using cloudscribe.Kvp.Models;
using cloudscribe.Kvp.Storage.EFCore.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace cloudscribe.Kvp.Storage.EFCore.pgsql
{
    public class KvpDbContext : KvpDbContextBase, IKvpDbContext
    {
        public KvpDbContext(DbContextOptions<KvpDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            IKvpTableNames tableNames = this.GetService<IKvpTableNames>();
            if (tableNames == null)
            {
                tableNames = new KvpTableNames();
            }

            modelBuilder.Entity<KvpItem>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Id).HasMaxLength(36);

                entity.Property(p => p.FeatureId).HasMaxLength(36);

                entity.HasIndex(p => p.FeatureId);

                entity.Property(p => p.SetId).HasMaxLength(36);

                entity.HasIndex(p => p.SetId);

                entity.Property(p => p.SubSetId).HasMaxLength(36);

                entity.HasIndex(p => p.SubSetId);

                entity.Property(p => p.Key).HasMaxLength(255);

                entity.HasIndex(p => p.Key);

                entity.Property(p => p.Custom1).HasMaxLength(255);

                entity.Property(p => p.Custom2).HasMaxLength(255);

            });

        }

    }
}
