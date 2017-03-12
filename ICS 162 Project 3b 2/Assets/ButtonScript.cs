using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {


    bool canPress = false;
	// Use this for initialization
	void Start () {
	
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


    void OnTriggerEnter(Collider other)
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

    }
}
