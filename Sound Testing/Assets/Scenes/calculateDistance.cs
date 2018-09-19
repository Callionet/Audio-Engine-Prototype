using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class calculateDistance : MonoBehaviour {

    public float distance;
    public GameObject object1;
    public GameObject object2;
    
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        distance = Vector3.Distance(object1.transform.position, object2.transform.position);
    }
}
