using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[UnityEngine.AddComponentMenu("Wwise/AkState")]

public class AreaTrigger : MonoBehaviour {

    private GameObject player;
    private List<Collider> colliders;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("FirstPersonCharacter");
        colliders = new List<Collider>(GetComponentsInChildren<Collider>());
    }
	
	// Update is called once per frame
	void Update () {
    }

    public void OnTriggerEnter(Collider other) {
        AkSoundEngine.SetState("Pre_Post_Zone", "Industrial");
    }

    public void OnTriggerExit(Collider other){
        bool notrigger = false; 
        foreach (Collider coll in colliders){
            if(coll.bounds.Contains(player.transform.position)) { notrigger = true; }
        }
        if(!notrigger) { AkSoundEngine.SetState("Pre_Post_Zone", "None"); }
    }
}

