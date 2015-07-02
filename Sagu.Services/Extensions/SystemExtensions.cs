using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagu.Services
{
    public static class SystemExtensions
    {
        public static K Get<T, K>(this T item, Func<T, K> selector)
        {
            if (item == null)
                return default(K);

            try
            {
                return selector(item);
            }
            catch (NullReferenceException)
            {
                return default(K);
            }

        }
    }
}
