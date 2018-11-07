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

namespace Snaker.Service.Core
{
   public  class  LuaModule:BusinessModule
    {
        private object m_arge = null;
        internal LuaModule(string name) : base(name)
        {

        }

        public override void Creat(object arge = null)
        {
            base.Creat(arge);
            m_arge = null;
            //TODO 加载Name所对应的lua脚本
        }

        public override void Release()
        {
            base.Release();
            //TODO 释放Name所对应的Lua脚本
        }
    }
}
