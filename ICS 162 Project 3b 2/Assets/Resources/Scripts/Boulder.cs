using UnityEngine;
using System.Collections;

public class Boulder : ButtonScript {

    private Rigidbody rb;
    public int force;
    private bool pressed = false;
    // Use this for initialization
    public override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void PressButton()
    {
        if (!pressed)
        {
            base.PressButton();

            rb.isKinematic = false;
            rb.AddForce(transform.forward * force);
            pressed = true;
        }

    }
}
