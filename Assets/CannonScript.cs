using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    public float maxTimer;
    public float timer;

    public GameObject vase;
    public Transform shootPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < 0)
        {
            ShootCannon();
            timer = maxTimer;            
        }

        timer -= Time.deltaTime;
    }

    void ShootCannon()
    {
        Instantiate(vase, shootPoint.position, shootPoint.rotation);
    }
}
