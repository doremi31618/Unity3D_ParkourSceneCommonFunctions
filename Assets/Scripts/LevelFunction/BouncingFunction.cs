using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingFunction : MonoBehaviour {

    public float jumpVelocity_y = 10;
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Rigidbody>().velocity += new Vector3(0, jumpVelocity_y, 0);    
    }
}
