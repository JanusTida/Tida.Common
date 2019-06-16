using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tida.Util.Extending {
    public abstract class ExtensibleBase : ReadOnlyExtensibleBase {
        public virtual TInstance GetInstance<TInstance>(string extName) => GetInstanceCore<TInstance>(extName);
        public virtual TInstance GetGeneralInstance<TInstance>(string extName) => GetGeneralInstanceCore<TInstance>(extName);

        protected void SetInstanceCore<TInstance>(TInstance instance, string extName) {
            var cell = StateCells.FirstOrDefault(p => p.InstanceType == typeof(TInstance) && p.ExtName == extName);

            if (cell != null) {
                cell.Instance = instance;
            }
            else {
                StateCells.Add(new InstanceCell(typeof(TInstance)) {
                    Instance = instance,
                    ExtName = extName
                });
            }
        }

        protected void RemoveInstanceCore<TInstance>(string extName) {
            var cell = StateCells.FirstOrDefault(p => p.InstanceType == typeof(TInstance) && p.ExtName == extName);
            if (cell != null) {
                StateCells.Remove(cell);
            }
        }
    }
}
