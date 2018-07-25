/* 
 *  Name  : Author
 *  Title :******
 *  Function:*****
 *  Time    : 2017.10
 *  Version : 1.0
 *
 */

using System;
using System.Collections.Generic;

namespace Assets.Snaker.Service.Core
{
    public abstract class BusinessModule:Module
    {
        private string m_name = "";
        public string Name
        {
            get {
                if (string.IsNullOrEmpty(m_name))
                {
                    m_name = this.GetType().Name;
                }
                    return m_name;
            }
        }

        public string Title;

        //========================================
        public BusinessModule()
        {

        }

        internal BusinessModule(string name)
        {
            m_name = name;
        }

        private EventTable m_mtbEvent;

        internal void SetEventTable(EventTable table)
        {
            m_mtbEvent = table;
        }

        public ModuleEvent Event(string type)
        {
            return this.GetEventTable().GetEvent(type);
        }

        //ÊµÀý»¯EventTable
        protected EventTable GetEventTable()
        {
            if (m_mtbEvent == null)
            {
                m_mtbEvent = new EventTable();
            }

            return m_mtbEvent;
        }

        private void Foo()
        {
            BusinessModule module;
            module.Event("µÇÂ¼").AddListener(OnLogin);
        }

        private void OnLogin(object target)
        {

        }
    }
}
