using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Occlusion : MonoBehaviour {

    RaycastHit hit;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Physics.Linecast(transform.position, GameObject.Find("FPSController").transform.position, out hit))
        {
            Debug.Log("hit");
            AkSoundEngine.SetObjectObstructionAndOcclusion(gameObject, GameObject.Find("FPSController"), 1.0f, 1.0f);
        }

    }
}
