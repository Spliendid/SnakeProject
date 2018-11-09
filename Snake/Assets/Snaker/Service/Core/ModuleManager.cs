/* 
 *  Name  : Author
 *  Title :******
 *  Function:*****
 *  Time    : 2018.10
 *  Version : 1.0
 *
 */

using System;
using System.Collections.Generic;

namespace Snaker.Service.Core
{
    class ModuleManager:ServiceModule<ModuleManager> 
    {
        class MessageObject
        {
            public string target;
            public string msg;
            public object[] args;
        }

        private Dictionary<string, BusinessModule> m_mapModule;

        private Dictionary<string, EventTable> m_mapPrelistEvent; //Ԥ�й��¼�

        private Dictionary<string, List<MessageObject>> m_mapCacheMessage;

        private string m_domain;

        public ModuleManager()
        {
            m_mapModule = new Dictionary<string, BusinessModule>();

            m_mapPrelistEvent = new Dictionary<string, EventTable>();

            m_mapCacheMessage = new Dictionary<string, List<MessageObject>>();

        }

        public void Init(string domain = "Snaker.Model")
        {
            CheckSingleton();
            m_domain = domain;
        }

        public T CreateModule<T>(object args = null) where T: BusinessModule
        {
            return (T)CreateModule(typeof(T).Name,args);
        }

        public BusinessModule CreateModule(string name, object args = null)
        {
            if (m_mapModule.ContainsKey(name))
            {
                return null;
            }

            BusinessModule module = null;

            Type type = Type.GetType(m_domain + "." + name);

            if (type != null)
            {
                module = Activator.CreateInstance(type) as BusinessModule;
            }
            else
            {
                module = new LuaModule(name);
            }

            m_mapModule.Add(name, module);
            //����Ԥ�����¼�
            if (m_mapPrelistEvent.ContainsKey(name))
            {
                EventTable tblEvent = m_mapPrelistEvent[name];
                m_mapPrelistEvent.Remove(name);

                module.SetEventTable(tblEvent);
            }

            module.Creat(args);
            //���������Ϣ

            if (m_mapCacheMessage.ContainsKey(name))
            {
                List<MessageObject> list = m_mapCacheMessage[name];

                for (int i = 0; i < list.Count; i++)
                {
                    MessageObject msgobj = list[i];
                    module.HandleMessage(msgobj.msg,msgobj.args);
                }
                m_mapCacheMessage.Remove(name);
            }

            return module;
          
        }

        public void ReleaseModule(BusinessModule module)
        {
            if (module != null)
            {
                if (m_mapModule.ContainsKey(module.Name))
                {
                    m_mapModule.Remove(module.Name);
                    module.Release();
                }
                else
                {

                }
            }
        }

        public void ReleaseAll()
        {
            foreach (var @event in m_mapPrelistEvent)
            {
                @event.Value.Clear();
            }
            m_mapPrelistEvent.Clear();

            m_mapCacheMessage.Clear();

            foreach (var module in m_mapModule)
            {
                module.Value.Release();
            }

            m_mapModule.Clear();
        }

        public T GetModule<T>() where T : BusinessModule
        {
            return (T) GetModule(typeof(T).Name);
        }

        public BusinessModule GetModule(string name)
        {
            if (m_mapModule.ContainsKey(name))
            {
                return m_mapModule[name];
            }

            return null;
        }

        //=============================================

        //������Ϣ
        public void SendMessage(string target,string msg,params object[] args)
        {
            BusinessModule module = GetModule(target);

            if (module != null)
            {
                module.HandleMessage(msg,args);
            }
            else
            {
                List<MessageObject> list = GetCacheMessageList(target);
                MessageObject msgobj = new MessageObject();
                list.Add(msgobj);

                msgobj.target = target;
                msgobj.msg = msg;
                msgobj.args = args;
            }

        }

        private List<MessageObject> GetCacheMessageList(string target)
        {
            List<MessageObject> list = null;
            if (!m_mapCacheMessage.ContainsKey(target))
            {
                list = new List<MessageObject>();
                m_mapCacheMessage.Add(target,list);
            }
            else
            {
                list = m_mapCacheMessage[target];
            }

            return list;
        }
        //======================================================

        public ModuleEvent Event(string target, string type)
        {
            ModuleEvent evt = null;
            BusinessModule module = GetModule(target);
            if (module!=null)
            {
                evt = module.Event(type);
            }
            else
            {
                EventTable table = GetPreListEventTable(target);
                evt = table.GetEvent(type);
            }
            return evt;
        }
        private EventTable GetPreListEventTable(string target)
        {
            EventTable table = null;

            if (!m_mapPrelistEvent.ContainsKey(target))
            {
                table = new EventTable();
                m_mapPrelistEvent.Add(target,table);
            }
            else
            {
                table = m_mapPrelistEvent[target];
            }

            return table;
        }
    }
}
