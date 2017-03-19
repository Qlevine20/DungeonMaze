using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour {


    public bool open = false;
    private bool animPlayed = false;
    private Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(open && !animPlayed)
        {
            if (anim)
            {
                anim.SetBool("open", true);
            }
        }
	}
}
