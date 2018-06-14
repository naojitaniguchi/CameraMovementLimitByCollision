using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {
    public GameObject target;
    public Vector3 offset;
    public float back = 0.2f ;
    bool colliding = false;
    Vector3 lastPosition;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody>().MovePosition(target.transform.position + offset);
        if (!colliding) {
            lastPosition = transform.position;
        }


    }
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Enter");
        Debug.Log(col.transform.gameObject.name);

        gameObject.transform.position = lastPosition;
        colliding = true;
    }

    void OnCollisionExit(Collision col)
    {
        Debug.Log("Exit");
        Debug.Log(col.transform.gameObject.name);
        colliding = false;
    }
    void OnCollisionStay(Collision col)
    {
        Debug.Log("Stay");
        Debug.Log(col.transform.gameObject.name);
        gameObject.transform.position = lastPosition;
    }

}
