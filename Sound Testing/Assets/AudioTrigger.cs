using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour {
        
    //list of colliders
    public List<Collider> colliders = new List<Collider>();

    //get collider list
    public List<Collider> GetColliders() { return colliders; }

    //list of surrounding gameobjects
    public List<GameObject> linePres = new List<GameObject>();

    //raycast for occlusion
    RaycastHit hit;

    //CustomScript myScript;

    // Use this for initialization
    void Start () {
	}

    private void OnTriggerEnter(Collider other)
    {
        //if there are collider around, put their gameObject into the list
        if (!colliders.Contains(other)) {
            
            //add to the list
            colliders.Add(other);

            //make a linerenderer
            GameObject linePre = new GameObject();
            LineRenderer temp = linePre.AddComponent<LineRenderer>();

            //set line width
            temp.SetWidth(0.05F, 0.05F);

            // Set the number of vertex fo the Line Renderer
            temp.SetVertexCount(2);

            //add the line renderer to the list
            linePres.Add(linePre);
        }

        
    }

    private void OnTriggerExit(Collider other)
    {
        //get the line renderer corresponding to the "other" collider's gameObject
        GameObject temp = linePres[colliders.IndexOf(other)];

        //remove the line renderer and gameObject of "other"
        linePres.RemoveAt(colliders.IndexOf(other));
        Destroy(temp);
        colliders.Remove(other);
    }   

    // Update is called once per frame
    void Update () {

        //iterate the list of colliders
		foreach (Collider coll in colliders)
        {
            //draw first pin of the lineRenderer at player
            linePres[colliders.IndexOf(coll)].GetComponent<LineRenderer>().SetPosition(0, gameObject.transform.position);

            //draw the second pin of the lineRenderer at coll's gameobject.transform
            linePres[colliders.IndexOf(coll)].GetComponent<LineRenderer>().SetPosition(1, coll.gameObject.transform.position);

            //send audio occlusion control to WWise 
            if (Physics.Linecast(transform.position, coll.gameObject.transform.position, out hit))
            {
                Debug.Log("hit");

                AkSoundEngine.SetObjectObstructionAndOcclusion(coll.gameObject, GameObject.Find("FirstPersonCharacter"), 0.3f, 0.3f);
            }
            else
            {
                AkSoundEngine.SetObjectObstructionAndOcclusion(coll.gameObject, GameObject.Find("FirstPersonCharacter"), 0.0f, 0.0f);
            }
        }
	}
}
