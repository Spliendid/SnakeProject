
using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;
public class ModuleEvent: UnityEvent<object>
{

}
public class ModuleEvent<T> : UnityEvent<T>
{

}
public class EventTable
{
    //存储ModuleEvent
    public Dictionary<string, ModuleEvent> m_mapEvents;

    /// <summary>
    /// 获取Type所指的ModuleEvent，ModuleEvent
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public ModuleEvent GetEvent(string type)
    {
        if (m_mapEvents == null)
        {
            m_mapEvents = new Dictionary<string, ModuleEvent>();
        }

        if (!m_mapEvents.ContainsKey(type))
        {
            m_mapEvents.Add(type, new ModuleEvent());
        }
        else if (m_mapEvents[type]==null)
        {
            m_mapEvents[type] = new ModuleEvent();
        }
        return m_mapEvents[type];
    }

    public void Clear()
    {
        if (m_mapEvents!=null)
        {

            foreach (var item in m_mapEvents)
            {
                item.Value.RemoveAllListeners();
            }
        }
    }
	
}
