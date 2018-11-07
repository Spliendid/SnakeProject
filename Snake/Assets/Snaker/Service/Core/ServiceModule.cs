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
   public abstract class ServiceModule<T>:Module where T :ServiceModule<T>,new()
    {
        private static T ms_instance = default(T);

        public static T Instance
        {
            get {
                if (ms_instance == null)
                {
                    ms_instance = new T();
                }
                return ms_instance;
            }
        }

        protected virtual void CheckSingleton()
        {
            if (ms_instance == null)
            {
                var exp = new Exception("ServiceModule<"+typeof(T).Name+">无法实例化，因为它是个单例");
            }
        }

    }

   
}
