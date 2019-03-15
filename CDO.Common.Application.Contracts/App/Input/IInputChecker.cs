using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDO.Common.Application.Contracts.App.Input {
    /// <summary>
    /// 输入检查器;
    /// </summary>
    public interface IInputChecker {
        /// <summary>
        /// 输入检查器;
        /// </summary>
        InputCheckResult Check(string value);
    }
}
