using UnityEngine;

public class Enemy_Anim : MonoBehaviour
{
    [SerializeField] private Animator enemyAnimator;

    public void PlayWalkAnimation(bool isWalking)
    {
        if (enemyAnimator != null)
        {
            enemyAnimator.SetBool("isWalking", isWalking);
        }
    }
}
