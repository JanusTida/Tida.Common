using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tida.Util.Extending {
    /// <summary>
    /// 可动态拓展类;
    /// </summary>
    public class ExtensibleObject : ExtensibleBase, IExtensible {
        public void RemoveInstance<TInstance>(string extName) => RemoveInstanceCore<TInstance>(extName);

        public void SetInstance<TInstance>(TInstance instance, string extName) => SetInstanceCore(instance, extName);
    }
    
  

    

    
}
