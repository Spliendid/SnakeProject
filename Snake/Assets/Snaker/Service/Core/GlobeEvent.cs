/* 
 *  Name  : Author
 *  Title :******
 *  Function:*****
 *  Time    : 2018.9
 *  Version : 1.0
 *
 */

using System;
using System.Collections.Generic;

namespace Snaker.Service.Core
{
    public static  class GlobaleEvent
    {
        public static ModuleEvent<bool> onLogin = new ModuleEvent<bool>();
        public static ModuleEvent<bool> onPay = new ModuleEvent<bool>();

        public static void Foo()
        {
            GlobaleEvent.onLogin.Invoke(true);
            GlobaleEvent.onLogin.AddListener(OnLogin);
        }

        private static void OnLogin(bool args)
        {

        }
    }
}
