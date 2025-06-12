using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private float Xinput, Yinput;
    private bool Sprinting;

    private void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();

    }

    private void Update()
    {
        Xinput = Mathf.Abs(GetComponent<PlayerMovement>().MoveX);
        Yinput = GetComponent<PlayerMovement>().MoveY;
        Sprinting = GetComponent<PlayerMovement>().IsSprinting;

        animator.SetFloat("XFloat", Xinput);
        animator.SetFloat("YFloat", Yinput);
        animator.SetBool("Sprint", Sprinting);
    }
}
