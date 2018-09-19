using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propagation : MonoBehaviour {

    // Use this for initialization
    public Camera camera;

	void Start () {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Camera.main.transform.position - transform.position);	

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CastRay()
    {

    }
}
