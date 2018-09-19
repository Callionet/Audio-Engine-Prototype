using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigate : MonoBehaviour {

    public float timer;

    public int newtarget;

    public float speed;

    public NavMeshAgent nav;

    public Vector3 target;

    private float x, y, z;

	// Use this for initialization
	void Start () {
        nav = gameObject.GetComponent<NavMeshAgent>();
        x = gameObject.transform.position.x;
        y = gameObject.transform.position.y;
        z = gameObject.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if(timer >= newtarget)
        {
            NewTarget();
            timer = 0;
        }

        //feeding speed to navmeshagent
        nav.speed = speed;
	}

    void NewTarget()
    {
        float myX = gameObject.transform.position.x;
        float myZ = gameObject.transform.position.z;

        float xPos = Random.Range(x - 15, x +15);
        float zPos = Random.Range(z - 15, z + 15);

        target = new Vector3(xPos, y, zPos);

        //target = new Vector3(223.47f, -993.48f, 851.26f);

        nav.SetDestination(target);
    }
}
