using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class LeverScript : ButtonScript {

    public Gate gate;
    private Animator anim;
    private Transform camParent;
    private Vector3 prevCamPos;
    private Quaternion prevCamRot;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void PressButton()
    {
        if (gate)
        {
            StartCoroutine(OpenGate());
        }
    }


    IEnumerator OpenGate()
    {
        
        if (anim)
        {
            anim.SetBool("Pull", true);
        }
        ThirdPersonCharacter p = GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonCharacter>();
        yield return new WaitForSeconds(1.0f);
        p.enabled = false;
        camParent = Camera.main.transform.parent;
        prevCamPos = Camera.main.transform.localPosition;
        prevCamRot = Camera.main.transform.localRotation;
        Camera.main.transform.parent = gate.transform;
        Camera.main.transform.localPosition = new Vector3(0, 5, 15);
        Camera.main.transform.localRotation = Quaternion.LookRotation(gate.transform.position - Camera.main.transform.position);
        gate.open = true;
        yield return new WaitForSeconds(3);
        p.enabled = true;
        Camera.main.transform.parent = camParent;
        Camera.main.transform.localPosition = prevCamPos;
        Camera.main.transform.localRotation = prevCamRot;

    }
}
