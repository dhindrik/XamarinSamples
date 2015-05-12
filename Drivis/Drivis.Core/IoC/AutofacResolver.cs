using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace Drivis.Core.IoC
{
    public class AutofacResolver : IResolver
    {
        private readonly IContainer _container;

        public AutofacResolver(IContainer container)
        {
            _container = container;
        }

        public T Resolve<T>()
        {
            _container.Resolve<T>();
        }
    }
}
