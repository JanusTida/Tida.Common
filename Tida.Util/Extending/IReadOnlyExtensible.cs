using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tida.Extending {
    /// <summary>
    /// 只读拓展契约;
    /// </summary>
    public interface IReadOnlyExtensible {
        /// <summary>
        /// 获得拓展实例;
        /// </summary>
        /// <typeparam name="TInstance">拓展实例类型</typeparam>
        /// <returns></returns>
        TInstance GetInstance<TInstance>(string extName);

        ///// <summary>
        ///// 获得拓展实例;
        ///// </summary>
        ///// <param name="extName"></param>
        ///// <returns></returns>
        //object GetInstance(Type type,string extName);

        ///// <summary>
        ///// 类型判断拆箱获取类型;
        ///// </summary>
        ///// <typeparam name="TInstance"></typeparam>
        ///// <param name="extName"></param>
        ///// <returns></returns>
        //TInstance GetGeneralInstance<TInstance>(string extName);
    }
}
