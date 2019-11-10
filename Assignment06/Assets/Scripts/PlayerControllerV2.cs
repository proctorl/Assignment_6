using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
using UnityEngine.UI;
public class PlayerControllerV2 : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    public GameObject player;
    public GameObject turkey;
    Animator anim;
    public AudioSource gobble;
    public Text score;
    public float distance;
    int count = 0;
    bool carrying;
    public float height;

    private void Start()
    {
        
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if ( Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
                agent.SetDestination(hit.point);
        }
        float velocity = agent.velocity.magnitude;
        if (velocity > 1)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }


        score.text = "SCORE: " + count;

    }
    void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "Player")
        {
            anim.SetBool("isCarrying", true);
            count++;
            gobble.Play();
            this.GetComponent<Collider>().enabled = false;
        }




    }


}
