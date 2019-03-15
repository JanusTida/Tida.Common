using CDO.Common.Application.Contracts.Common;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDO.Common.Application.Contracts.App.Events {
    /// <summary>
    /// 应用程序开始事件;
    /// </summary>
    public class ApplicationStartUpEvent:PubSubEvent {
    }

    public interface IApplicationStartUpEventHandler : IEventHandler {

    }
}
