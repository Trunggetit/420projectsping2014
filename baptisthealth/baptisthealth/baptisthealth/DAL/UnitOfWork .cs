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

        private vendorrepo<vendor> _vendorrepository;

        public vendorrepo<vendor> Vendorrepository
        {
            get
            {

                if (this._vendorrepository == null)
                {
                    this._vendorrepository = new vendorrepo<vendor>(context);
                }
                return _vendorrepository;
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