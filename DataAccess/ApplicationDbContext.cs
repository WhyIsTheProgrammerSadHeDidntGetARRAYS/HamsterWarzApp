//using DataAccess.Extensions;
using HamsterWarz.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context) : base(context) 
        {

        }

        public DbSet<Hamster> Hamsters { get; set; }
        public DbSet<MatchData> MatchesData { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Seed();
        //    base.OnModelCreating(modelBuilder);
        //}

    }
}
