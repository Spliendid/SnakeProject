using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YJWCL;
namespace Snaker.Service.Core.Example
{

    public class ModuleA : BusinessModule
    {
        public override void Creat(object arge = null)
        {
            base.Creat(arge);

            //业务层之间通过Message进行通讯
            ModuleManager.Instance.SendMessage("ModuleB","MessageFormA_1",1,2,3);
            ModuleManager.Instance.SendMessage("ModuleB","MessageFormA_2", "abc", "3");

            //业务层之间，通过event通讯
            ModuleManager.Instance.Event("ModuleB", "onModuleEventB").AddListener(OnModuleEventB);

            //业务层调用服务层，通过事件监听
            ModuleC.Instance.onEvent.AddListener(OnModuleEventC);
            ModuleC.Instance.DoSomething();

            //全局事件
            GlobaleEvent.onLogin.AddListener(OnLogin);
        }

        private void OnModuleEventC(object args)
        {
            this.Log("OnModuleEventC() arg:{0}",args);
        }

        private void OnModuleEventB(object args)
        {
            this.Log("OnModuleEventB() arg:{0}", args);
        }

        private void OnLogin(bool args)
        {
            this.Log("OnLogin() arg:{0}", args);
        }
    }

    public class ModuleB : BusinessModule
    {
        public ModuleEvent onModuleEventB { get { return Event("onModuleEventB"); } }
        public override void Creat(object arge = null)
        {
            base.Creat(arge);
            onModuleEventB.Invoke("aaaa");
        }

        //protected void MessageFormA_1( int args1, int args2,int args3)
        //{
        //    this.Log("MessageFormA_1() args1:{1},args:{2},args:{3}", args1, args2,args3);
        //}

        public void MessageFormA_2(string args1,string  args2)
        {
            this.Log("MessageFormA_2() args1:{1},args{2}", args1,args2);
        }

        protected override void OnModuleMessage(string msg, object[] args)
        {
            base.OnModuleMessage(msg, args);
            this.Log("OnModuleMessage() msg:{0} ,args:{1},{2}", msg,args[0],args[1]);
        }
    }

    public class ModuleC : ServiceModule<ModuleC>
    {
        public ModuleEvent onEvent = new ModuleEvent();
        public void Init()
        {

        }

        public void DoSomething()
        {
            onEvent.Invoke(null);
        }

    }
    class Example
    {
        public void Init()
        {
            ModuleC.Instance.Init();
            ModuleManager.Instance.Init("Snaker.Service.Core.Example");

            ModuleManager.Instance.CreateModule("ModuleA");
            ModuleManager.Instance.CreateModule("ModuleB");
        }
    }
}
