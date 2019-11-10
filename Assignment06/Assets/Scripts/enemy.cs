using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public GameObject Player;
    public float movementSpeed = 4;
    public NavMeshAgent agent;
    Animator anim;
    bool isCaught;
    float animTime;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {

        if( Player.transform.position.x > 31 && (Player.transform.position.x < 68 && Player.transform.position.z < 8) && isCaught == false)
        {
            
            transform.LookAt(Player.transform);
            transform.position += transform.forward * movementSpeed * Time.deltaTime;
            anim.SetBool("isRunning", true);
        }
        else if((Player.transform.position.x > 68 && Player.transform.position.z > 8))
            anim.SetBool("isRunning", false);
        else
            anim.SetBool("isRunning", false);

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.dance"))//test if animation named JumpAnim is playing
        {
            animTime = anim.GetCurrentAnimatorStateInfo(0).normalizedTime;//get the time the animation is playing
            if (animTime >= 1f)
            {
                anim.SetBool("isCaught", false);
                isCaught = false;
               
            }
        }

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("isCaught", true);
            isCaught = true;
            
        }
        

    }
}
