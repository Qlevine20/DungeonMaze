using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {


    bool canPress = false;
    private AudioClip successSound;
	// Use this for initialization
	public virtual void Start () {
        successSound = Resources.Load("Success",typeof(AudioClip)) as AudioClip;
        Debug.Log(successSound);
	}
	
	// Update is called once per frame
	public virtual void Update () {
        if (canPress)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PressButton();
                
            }
        }
	}


    public virtual void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            canPress = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            canPress = false;
        }
    }


    public virtual void PressButton()
    {
        AudioSource.PlayClipAtPoint(successSound, Camera.main.transform.position);
    }
}
