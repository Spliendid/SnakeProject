using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
public class ReflectionTest : MonoBehaviour {

    public string ClassType;

    [ContextMenu("AA")]
	// Use this for initialization
	void aa () {
        MethodInfo mi = this.GetType().GetMethod("AA");
        object[] a = { "A","A"};
        mi.Invoke(this, a);

        Type type = Type.GetType(ClassType);
        root obj = Activator.CreateInstance(type) as root ;
        obj.LogName();
        
	}
	
	// Update is called once per frame
	public void AA (string a,string b) {
        Debug.Log(a+b);
	}
}

public  class root
{
    public virtual void LogName() { }
}
public class A:root
{
    public override void LogName()
    {
        Debug.Log("A");        
    }
}
public class B:root
{
    public override void LogName()
    {
        Debug.Log("B");
    }
}