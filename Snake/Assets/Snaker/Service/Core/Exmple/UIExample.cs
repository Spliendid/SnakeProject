using UnityEngine;
using System.Collections;
using Snaker.Service.UIManager;
public class UIExample : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        UIManager.Instance.Init("ui/example/");
        UIManager.MainPage = "UIPage1";
        UIManager.Instance.EnterMainPage();
    }

   
}
