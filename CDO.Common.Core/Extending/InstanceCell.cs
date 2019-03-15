using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDO.Common.Core.Extending {
    /// <summary>
    /// 实例状态元素;
    /// </summary>
    public class InstanceCell {
        public InstanceCell(Type instanceType) {
            this.InstanceType = instanceType;
        }

        /// <summary>
        /// 实例类型;
        /// </summary>
        public Type InstanceType { get; }

        /// <summary>
        /// 拓展属性名;
        /// </summary>
        public string ExtName { get; set; }
        /// <summary>
        /// 实例本身;
        /// </summary>
        public object Instance {
            get => _instance;
            set {
                if (_instance == value) {
                    return;
                }
                
                if (value != null && !InstanceType.IsAssignableFrom(value.GetType())) {
                    throw new InvalidCastException($"{value} is not a instance of {InstanceType}.");
                }

                _instance = value;
            }
        }
        private object _instance;
    }
}
