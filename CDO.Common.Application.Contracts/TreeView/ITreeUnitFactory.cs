using CDO.Common.Application.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDO.Common.Application.Contracts.TreeView {
    /// <summary>
    /// 树形节点工厂契约(此单位唯一);
    /// </summary>
    public interface ITreeUnitFactory {
        ITreeUnit CreateNew(string typeGUID);
    }

    public class TreeUnitFactory : GenericServiceStaticInstance<ITreeUnitFactory> {
        public static ITreeUnit CreateNew(string typeGuid) => Current?.CreateNew(typeGuid);
    }
}
