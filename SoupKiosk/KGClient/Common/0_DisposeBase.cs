using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGClient
{
    [Serializable]
    public abstract class DisposeBase : IDisposable
    {
        public static void DisposeObject<T>(ref T obj) where T : class, IDisposable
        {
            if (obj != null)
            {
                obj.Dispose();
                obj = null;
            }
        }

        protected virtual void DisposeManaged() { }
        protected virtual void DisposeNative() { }

        [field: NonSerialized]
        protected bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            //Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.fff")}\tDisposeBase");
            if (!this.disposed)
            {
                if (disposing)
                    DisposeManaged(); // Managed dispose

                DisposeNative(); // Unmanaged dispose
            }

            disposed = true;
            //Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.fff")}\tDisposeBase - End");
        }

        ~DisposeBase()
        {
            Dispose(false);
        }


        //public void DoSomething()
        //{
        //    if (this.disposed)
        //    {
        //        throw new ObjectDisposedException("");
        //    }
        //}
    }
}
