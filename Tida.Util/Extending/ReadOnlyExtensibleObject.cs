using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tida.Util.Extending {
    public class ReadOnlyExtensibleObject : ReadOnlyExtensibleBase, IReadOnlyExtensible {
        public TInstance GetInstance<TInstance>(string extName) => GetInstanceCore<TInstance>(extName);

        public TInstance GetGeneralInstance<TInstance>(string extName) => GetGeneralInstanceCore<TInstance>(extName);
    }
}
