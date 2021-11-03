using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
// Start is called before the first frame update
    private Animator animator;
    bool isJumping = false;
    void Start()
    {
        animator = this.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Horizontal") != 0 ||
            Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Vertical") != 0)
        {
            animator.SetBool("run", true);
            animator.SetBool("walk", false);
        }
        else if (Input.GetAxis("Horizontal") != 0 ||
                Input.GetAxis("Vertical") != 0)
        {
            animator.SetBool("walk", true);
            animator.SetBool("run", false);
        }
        else
        {
            animator.SetBool("run", false);
            animator.SetBool("walk", false);
        }

        isJumping = Input.GetKeyDown(KeyCode.Space);
        animator.SetBool("jump", isJumping);
        
    }
}
