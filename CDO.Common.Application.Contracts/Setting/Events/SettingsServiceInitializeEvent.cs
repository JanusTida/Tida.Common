using CDO.Common.Application.Contracts.Common;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDO.Common.Application.Contracts.Setting.Events {
    /// <summary>
    /// 设定服务初始化事件;
    /// </summary>
    public class SettingsServiceInitializeEvent:PubSubEvent<ISettingsService> {
    }

    public interface ISettingsServiceInitializeEventHandler:IEventHandler<ISettingsService> {

    }
}
