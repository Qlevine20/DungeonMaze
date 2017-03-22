using UnityEngine;
using System.Collections;

public class TorchScript : MonoBehaviour {


    Light l;
    float minWaitForFlicker = .5f;

    float maxWaitForFlicker = 1;
    float minIncrementFlicker = .001f;
    float minAngle = 30;
    float maxAngle = 32;
    // Use this for initialization
    void Start () {
        l = GetComponentInChildren<Light>();
        l.type = LightType.Spot;
        StartCoroutine(flicker());
	}

    // Update is called once per frame

    


    IEnumerator flicker()
    {
        l.spotAngle = minAngle;
        yield return new WaitForSeconds(Random.Range(minWaitForFlicker,maxWaitForFlicker));
        l.spotAngle = minAngle + 1;
        yield return new WaitForSeconds(minIncrementFlicker);
        l.spotAngle = minAngle + 1;
        yield return new WaitForSeconds(minIncrementFlicker);
        l.spotAngle = minAngle + 1;
        yield return new WaitForSeconds(minIncrementFlicker);
        l.spotAngle = minAngle + 1;
        yield return new WaitForSeconds(minIncrementFlicker);
        l.spotAngle = minAngle - 1;
        yield return new WaitForSeconds(minIncrementFlicker);
        l.spotAngle = minAngle - 1;
        yield return new WaitForSeconds(minIncrementFlicker);
        l.spotAngle = minAngle - 1;
        yield return new WaitForSeconds(minIncrementFlicker);
        StartCoroutine(flicker());
    }
}
