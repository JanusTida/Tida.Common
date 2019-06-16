using Tida.Application.Contracts.Common;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tida.Application.Contracts.Docking.Events {
    public class DockingPaneIsHiddenChangedEvent:PubSubEvent<IDockingPane> {
    }

    public interface IDockingPaneIsHiddenChangedEventHandler : IEventHandler<IDockingPane> {
    }
}
