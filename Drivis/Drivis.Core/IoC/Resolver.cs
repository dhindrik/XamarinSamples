using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivis.Core.IoC
{
    public class Resolver
    {
        private static IResolver _resolver;

        public static void SetResolver(IResolver resolver)
        {
            _resolver = resolver;
        }

        public static T Resolve<T>()
        {
            if (_resolver == null)
            {
                throw new Exception("You have to set resolver before use this method");
            }

            return _resolver.Resolve<T>();
        }
    }
}
