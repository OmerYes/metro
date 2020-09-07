using MetroSMS.Data.Model.ORM.Context;
using MetroSMS.Data.Model.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSMS.Business.Manager.Repository
{
    public class UnitOfWork : IDisposable
    {
        private MetroSMSContext context = new MetroSMSContext();


        public UnitOfWork()
        {
            context = new MetroSMSContext();
        }

        public UnitOfWork(MetroSMSContext db)
        {
            context = db;
        }

        private GenericRepository<User> userRepo;
        private GenericRepository<UserPhoto> userPhotoRepo;
        private GenericRepository<AdminUser> adminUserRepo;

        public GenericRepository<AdminUser> AdminUserRepo
        {
            get
            {
                if (this.adminUserRepo == null)
                {
                    this.adminUserRepo = new GenericRepository<AdminUser>(context);
                }
                return adminUserRepo;
            }
        }
        public GenericRepository<User> UserRepo
        {
            get
            {
                if (this.userRepo == null)
                {
                    this.userRepo = new GenericRepository<User>(context);
                }
                return userRepo;
            }
        }
        public GenericRepository<UserPhoto> UserPhotoRepo
        {
            get
            {
                if (this.userPhotoRepo == null)
                {
                    this.userPhotoRepo = new GenericRepository<UserPhoto>(context);
                }
                return userPhotoRepo;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose (bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
