using UnityEngine;
using System.Collections;

public class DoorScript : ButtonScript {

    Animator anim;
    public AudioClip doorOpen;
    public AudioClip doorClose;
    public AudioClip doorBreak;
    public Transform Player;
    private bool open = false;
    public bool Interactable = true;
    public bool breakable = false;
	// Use this for initialization
	public override void Start () {
        base.Start();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	public override void Update () {
        if (Interactable)
        {
            base.Update();
        }
        
	}


    public override void OnTriggerEnter(Collider other)
    {
        if (Interactable)
        {
            base.OnTriggerEnter(other);
            if (other.gameObject.tag == "Boulder")
            {
                CrushDoor();
            }
        }

    }

    public override void PressButton()
    {
        if (!breakable)
        {
            base.PressButton();
            open = !open;
            anim.SetBool("Open", open);
            if (open)
            {
                AudioSource.PlayClipAtPoint(doorOpen, Player.position);
                foreach (BoxCollider b in GetComponents<BoxCollider>())
                {
                    b.enabled = false;
                }
            }
            else
            {
                AudioSource.PlayClipAtPoint(doorClose, Player.position);
                foreach (BoxCollider b in GetComponents<BoxCollider>())
                {
                    b.enabled = true;
                }
            }
        }


    }

    public void CrushDoor()
    {
        StartCoroutine(DestroyDoor());
    }

    IEnumerator DestroyDoor()
    {
        anim.SetBool("Destroy", true);
        AudioSource.PlayClipAtPoint(doorBreak, Player.position);
        foreach (BoxCollider b in GetComponents<BoxCollider>())
        {
            b.enabled = false;
        }
        yield return new WaitForSeconds(2);
        //Destroy(gameObject);
    }
}
