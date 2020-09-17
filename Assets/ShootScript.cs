using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ShootScript : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    public GameObject bullet;
    public Transform shootPoint;
    public AudioClip shootSound;
    AudioSource AS;

    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.onActivate.AddListener(Shoot);
    }

    void Shoot(XRBaseInteractor interactor)
    {
        AS.PlayOneShot(shootSound);
        Instantiate(bullet,shootPoint.position, shootPoint.rotation);
    }
}
