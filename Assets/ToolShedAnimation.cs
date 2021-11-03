using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolShedAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    void Start()
    {
        animator = this.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        animator.SetBool("doorOpen", true);
    }

    private void OnTriggerExit(Collider other) {
        animator.SetBool("doorOpen", false);
        
    }
}
