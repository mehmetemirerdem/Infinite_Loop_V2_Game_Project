using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation_sc : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Jump") > 0.0f)
        {
            animator.SetBool("sniper", false);
        }
        else
        {
            animator.SetBool("sniper", true);
        }

        if (Input.GetAxis("Horizontal") > 0.0f)
        {
            animator.SetBool("smg", false);
        }
        else
        {
            animator.SetBool("smg", true);
        }
    }
}
