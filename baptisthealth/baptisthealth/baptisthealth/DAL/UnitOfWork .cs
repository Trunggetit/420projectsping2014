using baptisthealth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace baptisthealth.DAL
{
    public class UnitOfWork : IDisposable
    {
        private baptisthealthdbcontext context = new baptisthealthdbcontext();

        private vendorrepo<vendor> vendorrepository;

        public vendorrepo<vendor> Vendorrepository
        {
            get
            {

                if (this.vendorrepository == null)
                {
                    this.vendorrepository = new vendorrepo<vendor>(context);
                }
                return vendorrepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
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