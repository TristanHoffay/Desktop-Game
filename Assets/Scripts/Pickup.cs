using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public MetaControls.Tools pickupTool;
    private bool active = true;
    private void Update()
    {
        transform.position += 0.4f * Vector3.up * Mathf.Cos(Time.time * 6f) * Time.deltaTime;
        transform.rotation *= Quaternion.Euler(0,0, 50f * Mathf.Cos(Time.time * 3f) * Time.deltaTime);
    }
    public bool PickUp() // used to make sure it can be picked up
    {
        if (active)
        {
            active = false;
            return true;
        }
        return false;
    }
}
