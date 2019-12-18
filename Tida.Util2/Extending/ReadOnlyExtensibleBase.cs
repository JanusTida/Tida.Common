using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tida.Extending {
    /// <summary>
    /// 只读拓展(提供算法逻辑);
    /// </summary>
    public abstract class ReadOnlyExtensibleBase {
        /// <summary>
        /// 存储状态的集合;
        /// </summary>
        public List<InstanceCell> StateCells { get; } = new List<InstanceCell>();

        private object GetInstance(Type instanceType, string extName) {
            var cell = StateCells.FirstOrDefault(p => p.InstanceType == instanceType
            && p.ExtName == extName);

            if (cell == null) {
                return null;
            }

            if (cell.InstanceType == instanceType) {
                return cell.Instance;
            }

            throw new InvalidCastException($"{nameof(cell.Instance)} can't be cast to {instanceType}.");
        }

        protected virtual TInstance GetInstanceCore<TInstance>(string extName) {
            var ins = GetInstance(typeof(TInstance), extName);
            if (ins != null) {
                return (TInstance)ins;
            }
            return default(TInstance);
        }

        /// <summary>
        /// 类型判断拆箱获取类型;
        /// </summary>
        /// <typeparam name="TInstance"></typeparam>
        /// <param name="extName"></param>
        /// <returns></returns>
        protected virtual TInstance GetGeneralInstanceCore<TInstance>(string extName) {
            foreach (var item in StateCells) {
                if (item.Instance is TInstance) {
                    return (TInstance)item.Instance;
                }
            }

            return default(TInstance);
        }


    }
}
