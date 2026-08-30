using UnityEngine;
public class PlayState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        LevelManager.Instance.SetPlayScreenActive(true);
        ScoreManager.Instance.StartPointTimer();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Brick.s_Bricks.Count <= 0)
        {
            ScoreManager.Instance.StopPointTimer();

            foreach (Ball ball in Ball.s_Balls)
                ball.StopMovement();
            
            animator.SetBool("bNoBricks", true);
        }

        if (Ball.s_Balls.Count <= 0)
        {
            ScoreManager.Instance.StopPointTimer();
            animator.SetBool("bNoBalls", true);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        LevelManager.Instance.SetPlayScreenActive(false);
    }
}
