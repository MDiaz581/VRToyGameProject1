using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcedVase : MonoBehaviour
{
    Rigidbody RB;
    public float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        RB.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
    }

}
