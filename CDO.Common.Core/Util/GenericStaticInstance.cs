using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDO.Common.Core.Util {
    /// <summary>
    /// 静态实例基类;
    /// </summary>
    /// <typeparam name="TInstance"></typeparam>
    public abstract class GenericStaticInstance<TInstance> where TInstance:class,new() {
        public static readonly TInstance StaticInstance = new TInstance();
    }
}
