using MetroSMS.Data.Model.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MetroSMS.Data.Model.ORM.Context
{
    public class MetroSMSContext:DbContext
    {
        public MetroSMSContext()
        {
            //Database.Connection.ConnectionString = @"Server=35.195.4.159;Database=MtrTest;UID=user_mtr;pwd=mTr43!";
            //Database.Connection.ConnectionString = @"Server=DESKTOP-E661SRM\SQLEXPRESS;Database=MtrTest;UID=sa;pwd=123";      

            Database.Connection.ConnectionString = "Server=.;Database=MetroMenuDB;UID=sa;PWD=123456";
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserPhoto> UserPhotos { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
    }
}
