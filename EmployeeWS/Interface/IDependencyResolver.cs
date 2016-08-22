using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWS.Interface
{
    public interface IDependencyResolver : IDependencyScope, IDisposable
    {
        IDependencyScope BeginScope();
    }

    public interface IDependencyScope : IDisposable
    {
        object GetService(Type serviceType);
        IEnumerable<object> GetServices(Type serviceType);
    }
}
