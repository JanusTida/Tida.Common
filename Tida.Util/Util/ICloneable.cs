using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tida.Util.Common.Util {
    /// <summary>
    /// 可复制契约;
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICloneable<T> {
        /// <summary>
        /// 复制自身;
        /// </summary>
        /// <returns></returns>
        T Clone();
    }
}
