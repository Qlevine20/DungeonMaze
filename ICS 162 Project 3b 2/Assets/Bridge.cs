using UnityEngine;
using System.Collections;

public class Bridge : MonoBehaviour {

    // Use this for initialization
    public bool fall = false;
    private Rigidbody rb;
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(fall && !rb.useGravity)
        {
            rb.useGravity = true;
        }
	}


    void OnCollisionEnter(Collision other)
    {
        rb.useGravity = false;
        rb.isKinematic = true;
    }
}
