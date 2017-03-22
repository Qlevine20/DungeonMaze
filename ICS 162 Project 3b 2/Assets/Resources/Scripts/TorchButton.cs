using UnityEngine;
using System.Collections;

public class TorchButton : ButtonScript {

    private GameObject l1;
    private GameObject l2;
    private TorchScript t;
    bool LightOn = true;
	// Use this for initialization
	void Start () {
        t = GetComponent<TorchScript>();
        l1 = transform.GetChild(0).gameObject;
        l2 = transform.GetChild(1).gameObject;
	}
	
	// Update is called once per frame
	public override void Update () {
        base.Update();
	}

    public override void PressButton()
    {
        if (LightOn)
        {
            t.enabled = false;
            l1.SetActive(false);
            l2.SetActive(false);
            LightOn = false;
        }
        else
        {
            t.enabled = true;
            l1.SetActive(true);
            l2.SetActive(true);
            LightOn = true;
        }

    }
}
