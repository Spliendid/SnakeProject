using UnityEngine;
using System.Collections;
using Snaker.Service.UIManager;
using YJWCL;
public class UIPage2 : UIPage
{
    public void OnOpenWind1()
    {
        UIManager.Instance.OpenWindow("UIWindow1").onClose+=OnWin1Close;
    }

    void OnWin1Close(object arg)
    {
        this.Log("OnWin1Close");
    }

    public void OnOpenWidet1()
    {
        UIManager.Instance.OpenWidget("UIWidget1");
    }
}
