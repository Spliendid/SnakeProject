using UnityEngine;
using System.Collections;
using Snaker.Service.Core.Example;
using YJWCL;
public class AppMain : MonoBehaviour {

	// Use this for initialization
	void Start () {
        YJWCL.Debuger.UseUnityEngine = true;
        Example example = new Example();
        example.Init();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
