using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    [SerializeField] private MoveZ _moveZ;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        _moveZ = FindObjectOfType<MoveZ>();
    }



    void Update()
    {
        if (_moveZ.isMove==true)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (Input.GetKey(KeyCode.W))
        {

            animator.SetBool("isPunching", true);

        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("isPunching", false);

        }
    }
}