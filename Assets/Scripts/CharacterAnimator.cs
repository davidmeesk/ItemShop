using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    public Animator[] animators;
    public RuntimeAnimatorController[] hatAnimations;
    public RuntimeAnimatorController[] clothingAnimations;

    private void OnEnable()
    {
        PlayerInput playerInput = GetComponent<PlayerInput>();
        playerInput.startedMoving += SetMovementAnimation;
    }

    private void OnDisable()
    {
        PlayerInput playerInput = GetComponent<PlayerInput>();
        playerInput.startedMoving -= SetMovementAnimation;
    }

    private void SetMovementAnimation(Vector2 direction)
    {
        foreach (Animator animator in animators)
        {
            if (animator.runtimeAnimatorController != null)
            {
                animator.SetBool("Walking Up", direction.y > 0);
                animator.SetBool("Walking Down", direction.y < 0);
                animator.SetBool("Walking Right", direction.x > 0);
                animator.SetBool("Walking Left", direction.x < 0);
            }
        }

    }

    private void ResetAnimation()
    {
        foreach (Animator animator in animators)
        {
            animator.Play("Idle Down");
        }
    }
}
