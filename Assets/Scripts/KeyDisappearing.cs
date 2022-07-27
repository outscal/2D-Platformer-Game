using UnityEngine;

public class KeyDisappearing : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Disappeared",true);
    }
}