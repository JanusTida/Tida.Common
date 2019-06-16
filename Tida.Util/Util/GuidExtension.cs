using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tida.Util.Util {
    /// <summary>
    /// GUID相关拓展;
    /// </summary>
    public static class GuidExtension {
        /// <summary>
        /// 随机生成一个新的GUID字符串;
        /// </summary>
        /// <returns></returns>
        public static string Random() => Guid.NewGuid().ToString("P");
    }
}
