using UnityEngine;
using System.Collections;

public class DoorScript : ButtonScript {

    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	public override void Update () {
        base.Update();
	}


    public override void PressButton()
    {
        anim.SetBool("Open", true);
        foreach(BoxCollider b in GetComponents<BoxCollider>())
        {
            b.enabled = false;
        }
    }
}
