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
            //TODO ����Name����Ӧ��lua�ű�
        }

        public override void Release()
        {
            base.Release();
            //TODO �ͷ�Name����Ӧ��Lua�ű�
        }
    }
}
