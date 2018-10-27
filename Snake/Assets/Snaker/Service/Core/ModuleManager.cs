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

        private Dictionary<string, EventTable> m_mapPrelistEvent; //Ô¤ÍÐ¹ÜÊÂ¼þ
        

    }
}
