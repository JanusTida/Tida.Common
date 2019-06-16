using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tida.Application.Contracts.TreeView;

namespace Tida.Application.TreeView {
    [Export(typeof(ITreeUnitFactory))]
    class TreeUnitFactoryImpl : ITreeUnitFactory {
        public ITreeUnit CreateNew(string typeGUID) => new TreeUnit(typeGUID);
    }
}
