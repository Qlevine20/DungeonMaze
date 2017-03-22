using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class LeverScript : ButtonScript {

    public DoorScript gate;
    private Animator anim;
    private Animator doorAnim;
    private Transform camParent;
    private Vector3 prevCamPos;
    private Quaternion prevCamRot;
    public Bridge b;
    public bool BridgeButton;
    public bool LeverReady;
    private bool bridgeDown;
    private FinalBridgeScript bScript;
    private bool LeverPulled = false;

	// Use this for initialization
	public override void Start () {
        base.Start();
        GetComponentInChildren<Light>().color = Color.red;
        anim = GetComponent<Animator>();
        if (gate)
        {
            doorAnim = gate.GetComponent<Animator>();
        }
        
        if (b)
        {
            bScript = b.GetComponent<FinalBridgeScript>();
        }
        
	}

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void PressButton()
    {
        if (!LeverPulled)
        {
            base.PressButton();
            if (BridgeButton)
            {
                BridgeLever();

            }
            else
            {
                StartCoroutine(OpenGate());
                LeverPulled = true;
            }
        }

    }


    IEnumerator OpenGate()
    {

        GetComponentInChildren<Light>().color = Color.green;
        ThirdPersonCharacter p = GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonCharacter>();
        yield return new WaitForSeconds(1.0f);
        //Delete everything above this if no animation for button

        if (doorAnim)
        {
            doorAnim.SetBool("Open", true);
        }
        p.enabled = false;
        camParent = Camera.main.transform.parent;
        prevCamPos = Camera.main.transform.localPosition;
        prevCamRot = Camera.main.transform.localRotation;
        Camera.main.transform.parent = gate.transform;
        Camera.main.transform.localPosition = new Vector3(0, 3, 2);
        Camera.main.transform.localRotation = Quaternion.LookRotation(gate.transform.position - Camera.main.transform.position);

		foreach (Collider c in gate.GetComponents<Collider> ()) 
		{
			c.enabled = false;
		}

        yield return new WaitForSeconds(2);
        p.enabled = true;
        Camera.main.transform.parent = camParent;
        Camera.main.transform.localPosition = prevCamPos;
        Camera.main.transform.localRotation = prevCamRot;

    }

    public void BridgeLever()
    {
        LeverReady = !LeverReady;
        if (LeverReady)
        {
            GetComponentInChildren<Light>().color = Color.green;
        }
        else
        {
            GetComponentInChildren<Light>().color = Color.red;
        }

        bScript.OnLeverChange();
        
    }


}
