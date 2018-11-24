using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProtoBuf;
using SGF;
using YJWCL;
public class Example_Protobuf : MonoBehaviour {

	// Use this for initialization
	void Start () {
        YJWCL.Debuger.UseUnityEngine = true;
        Player ziyang = new Player();
        ziyang.ID = 1;
        ziyang.Name = "ziyang";
        ziyang.isGirl = false;
        byte[] buff = PBSerializer.NSerialize<Player>(ziyang);
        var player = PBSerializer.NDeserialize<Player>(buff);
        this.Log("ID:{0},Name:{1},IsGirl:{2}",player.ID,player.Name,player.isGirl);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
[ProtoContract]
public class Player
{
    [ProtoMember(1)]
    public int ID;
    [ProtoMember(2)]
    public string Name;
    public bool isGirl;
}
