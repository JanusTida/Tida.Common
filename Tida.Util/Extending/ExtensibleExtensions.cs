using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tida.Util.Extending {
    public static class ExtensibleExtensions {
        /// <summary>
        /// 从可拓展实例中获取或创建实例;
        /// </summary>
        /// <typeparam name="TInstance"></typeparam>
        /// <param name="ext"></param>
        /// <param name="extName"></param>
        /// <param name="factory">生产方法</param>
        /// <returns></returns>
        public static TInstance GetOrCreateInstance<TInstance>(this IExtensible ext, string extName, Func<TInstance> factory) 
            => GetOrCreateInstanceInform(ext, extName, factory).Key;

        /// <summary>
        /// 从可拓展实例中获取或创建实例;并能告知是否为新建;
        /// </summary>
        /// <typeparam name="TInstance"></typeparam>
        /// <param name="ext"></param>
        /// <param name="extName"></param>
        /// <param name="factory">生产方法</param>
        /// <returns>isNew指示是否为新建的实例</returns>
        public static KeyValuePair<TInstance,bool> GetOrCreateInstanceInform<TInstance>(this IExtensible ext, string extName, Func<TInstance> factory) {
            if (ext == null) {
                throw new ArgumentNullException(nameof(ext));
            }
            if(factory == null) {
                throw new ArgumentNullException(nameof(factory));
            }

            var created = false;
            var ins = ext.GetInstance<TInstance>(extName);
            if (ins == null) {
                ins = factory();
                ext.SetInstance(ins, extName);
                created = true;
            }
            return new KeyValuePair<TInstance, bool>(ins,created);
        }
    }
}
