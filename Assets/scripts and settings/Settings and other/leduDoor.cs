using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leduDoor : MonoBehaviour
{
    public Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("istrigger",true);
    }
}

