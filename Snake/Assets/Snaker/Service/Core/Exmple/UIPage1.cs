using UnityEngine;
using System.Collections;
using Snaker.Service.UIManager;
public class UIPage1 : UIPage
{

    public void OnOpenP2()
    {
        UIManager.Instance.OpenPage("UIPage2");
    }
}
