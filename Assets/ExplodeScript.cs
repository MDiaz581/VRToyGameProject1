using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeScript : MonoBehaviour
{
    public float radius = 5.0f;
    public float power = 10f;
    float timer = 8f;
    public AudioClip breakSound;
    private AudioSource AS;
    

    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();

        AS.pitch = Random.Range(.8f, 1.1f);

        AS.PlayOneShot(breakSound);

        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 0.2F, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 0)
        {
            Destroy(this.gameObject);
        }

        timer -= Time.deltaTime;
    }
}
