using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    int isPunchingHash;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        isPunchingHash = Animator.StringToHash("isPunching");
    }



    void Update()
    {
        bool isPunching = animator.GetBool(isPunchingHash);
        bool punchingKey = Input.GetKey(KeyCode.W);
        if (!isPunching&& punchingKey)
        {
            animator.SetBool(isPunchingHash, true);
            Debug.Log("sss");

        }
    }
}