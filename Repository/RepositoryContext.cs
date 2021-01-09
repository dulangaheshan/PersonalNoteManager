/**
 * @author [D.5haN]
 * @email [dulangah2@gmail.com]
 * @create date 2021-01-09 17:10:49
 * @modify date 2021-01-09 17:10:49
 * @desc [Repository]
 */
using CordFortPersonalNoteManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CordFortPersonalNoteManager
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
            //IList<User> defaultStandards = new List<User>();

            //defaultStandards.Add(new User() { UserName = "User_1" });
            //defaultStandards.Add(new User() { UserName = "User_2" });
            //defaultStandards.Add(new User() { UserName = "User_3" });

            //context.Users.AddRange(defaultStandards);

          //  base.Set(context);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }


        /*
        * Initial data insertion on migration
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User() { UserID = 1, UserName = "User_1" },
                new User() { UserID = 2, UserName = "User_1" },
                new User() { UserID = 3, UserName = "User_1" });


           modelBuilder.Entity<Note>().HasData(
               new Note() { NoteId = 1, DateCreated = new DateTime(2020, 01, 09),Title = "Test1", UserID= 1,Content= "TestContent1", IsArchived = false  },
               new Note() { NoteId = 2, DateCreated = new DateTime(2020, 01, 09),Title = "Test2", UserID = 2, Content = "TestContent2", IsArchived = false },
               new Note() { NoteId = 3, DateCreated = new DateTime(2020, 01, 09),Title = "Test3", UserID = 1, Content = "TestContent2", IsArchived = false });

        }

    }

    //public class MyInitializer : DropCreateDatabaseAlways<User>
    //{
    //    protected void Seed(RepositoryContext context)
    //    {
    //        IList<User> defaultStandards = new List<User>();

    //        defaultStandards.Add(new User() { UserName = "User_1" });
    //        defaultStandards.Add(new User() { UserName = "User_2" });
    //        defaultStandards.Add(new User() { UserName = "User_3" });

    //        context.Users.AddRange(defaultStandards);

    //       // base.Set(context);
    //    }
    //}

}
