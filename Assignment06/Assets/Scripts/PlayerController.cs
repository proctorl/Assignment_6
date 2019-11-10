using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    public AudioSource gobble;
    public AudioSource Col;
    public Text score;
    public Text jscore;
    Animator anim;
    public float distance;
    bool carrying;
    public float height;
    int count = 0;
    int jCount = 0;
    bool jumping;

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
        if (agent.isOnOffMeshLink)
            jumping = true;
        if (jumping)
        {
            anim.SetBool("isJumping", true);
            if (!agent.isOnOffMeshLink)
            {
                jCount++;
                jumping = false;
                anim.SetBool("isJumping", false);
            }
                
            
        }
        
        score.text = "SCORE: " + count;
        jscore.text = "Jumps: " + jCount;
        
        

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Turkey")
        {
            gobble.Play();
            other.gameObject.SetActive(false);
            count++;
        }
        if (other.gameObject.tag == "Fire")
        {
            Col.Play();
        }
        if (other.gameObject.tag == "Enemy")
        {
            count++;
        }
        if (other.gameObject.tag == "Link")
            jCount++;


    }
    void OnTriggerExit(Collider other)
    {
        
    }

}
