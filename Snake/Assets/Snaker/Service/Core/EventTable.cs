
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
    public Dictionary<string, ModuleEvent> m_mapEvent;

    /// <summary>
    /// 获取Type所指的ModuleEvent，其实它是一个EventTable
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public ModuleEvent GetEvent(string type)
    {
        if (m_mapEvent == null)
        {
            m_mapEvent = new Dictionary<string, ModuleEvent>();
        }

        if (!m_mapEvent.ContainsKey(type))
        {
            m_mapEvent.Add(type, new ModuleEvent());
        }
        else if (m_mapEvent[type]==null)
        {
            m_mapEvent[type] = new ModuleEvent();
        }
        return m_mapEvent[type];
    }

    public void Clear()
    {

    }
	
}
