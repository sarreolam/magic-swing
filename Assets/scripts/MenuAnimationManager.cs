using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimationManager : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        animator.SetBool("isAvailable", true);
    }
}
