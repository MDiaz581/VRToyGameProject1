using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR.Interaction;
using UnityEngine.XR.Interaction.Toolkit;

public class DestructableScript : MonoBehaviour
{
    ScoreManager scoreManager;
    public GameObject vaseBrokenPrefab;
    private Rigidbody RB;

    private bool magReached;
    public float maxMagnitude;

    private float timer;
    private float maxTimer = 0.3f;

    private XRGrabInteractable grabInteractable;
    private MeshCollider meshCollider;
    public BoxCollider boxCollider;


    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        meshCollider = GetComponent<MeshCollider>();
        boxCollider = GetComponent<BoxCollider>();


        scoreManager = GameObject.Find("GameManager").GetComponent<ScoreManager>();
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.onActivate.AddListener(Break);
        grabInteractable.onSelectEnter.AddListener(DisableCollision);
    }

    // Update is called once per frame
    void Update()
    {
        if(meshCollider.enabled == false)
        {
            Debug.Log("Starting Countdown");
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                Debug.Log("Countdown finished");
                meshCollider.enabled = true;
            }
        }


        if (RB.velocity.magnitude > maxMagnitude)
        {
            Debug.Log("magReached");
            magReached = true;
            
        }
           
    }

    void Break(XRBaseInteractor interactor)
    {
        scoreManager.score += 100;
        Instantiate(vaseBrokenPrefab, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
    void DisableCollision(XRBaseInteractor interactor)
    {
        timer = maxTimer;
        meshCollider.enabled = false;
        if(boxCollider != null)
        {

            boxCollider.enabled = false;

        }

        
    }


    public void OnCollisionEnter(Collision col)
    {
        if(magReached)
        {            
            scoreManager.score += 100;
            Instantiate(vaseBrokenPrefab, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
        if (col.gameObject.tag == "Hammer")
        {           
            Debug.Log("COLL!");
            scoreManager.score += 100;
            Instantiate(vaseBrokenPrefab, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
