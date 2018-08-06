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
using YJWCL;
using System.Reflection;
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

        public BusinessModule()
        {

        }

        internal BusinessModule(string name)
        {
            m_name = name;
        }
        //��Ϣ����
        //========================================
        public virtual void HandleMessage(string message, object[] args)
        {
            this.Log("HandleMessage() message:{0} args{1}",message,args);
            MethodInfo mi = this.GetType().GetMethod(message, BindingFlags.NonPublic | BindingFlags.Instance);
            //�ҵ��������ʱ
            if (mi != null)
            {
                mi.Invoke(this, args);
            }
            //�Ҳ����������ʱ��ͨ�÷���
            else
            {
                OnModuleMessage(message,args);
            }
        }

        protected virtuald void OnModuleMessage(string msg,object[] args)
        {

        }

        //�¼�����
        //========================================
        private EventTable m_mtbEvent;

        internal void SetEventTable(EventTable table)
        {
            m_mtbEvent = table;
        }

        public ModuleEvent Event(string type)
        {
            return this.GetEventTable().GetEvent(type);
        }

        //ʵ����EventTable
        protected EventTable GetEventTable()
        {
            if (m_mtbEvent == null)
            {
                m_mtbEvent = new EventTable();
            }

            return m_mtbEvent;
        }

        public virtual void Creat(object arge = null)
        {
            this.Log("Creat() arge={0}",arge);
        }

        public override void Release()
        {
            if (m_mtbEvent!=null)
            {
                m_mtbEvent.Clear();
                m_mtbEvent = null;
            }
        }

        public virtual void Show()
        {
            this.Log("Show");
        }

    }
}
