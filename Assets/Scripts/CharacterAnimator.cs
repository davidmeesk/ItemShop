using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    public Animator animator;

    public void SetMovementAnimation(Vector2 direction)
    {
      
        animator.SetBool("Walking Up", direction.y > 0);
        animator.SetBool("Walking Down", direction.y < 0);
        animator.SetBool("Walking Right", direction.x > 0);
        animator.SetBool("Walking Left", direction.x < 0);

    }
}
