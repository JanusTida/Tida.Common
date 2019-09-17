using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tida.Extending {
   

    /// <summary>
    /// 可拓展契约;
    /// </summary>
    public interface IExtensible : IReadOnlyExtensible {
        /// <summary>
        /// 设定拓展实例;
        /// </summary>
        /// <typeparam name="TInstance"></typeparam>
        /// <param name="instance"></param>
        void SetInstance<TInstance>(TInstance instance,string extName);

        /// <summary>
        /// 移除拓展实例;
        /// </summary>
        /// <typeparam name="TInstance"></typeparam>
        /// <param name="extName"></param>
        void RemoveInstance<TInstance>(string extName);
    }

   

    public interface ITextExtensible:ITextReadOnlyExtensible {
        /// <summary>
        /// 拓展元素;
        /// </summary>
        string this[string extendElemName] { get; set; }

        /// <summary>
        /// 拓展元素属性;
        /// </summary>
        /// <param name="extendElemName"></param>
        /// <param name=""></param>
        /// <returns></returns>
        string this[string extendElemName, string extendAttriName] { get;  set; }
    }

    public interface ITextReadOnlyExtensible {
        /// <summary>
        /// 拓展元素属性;
        /// </summary>
        /// <param name="extendElemName"></param>
        /// <param name=""></param>
        /// <returns></returns>
        string this[string extendElemName, string extendAttriName] { get; }
        /// <summary>
        /// 拓展元素;
        /// </summary>
        string this[string extendElemName] { get;  }
    }

    public interface ITextInstanceExtensible : ITextExtensible, IExtensible {
        
    }
}
