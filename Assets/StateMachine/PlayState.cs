using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayState : StateMachineBehaviour
{
    ScoreManager m_scoreManager;
    LevelManager m_lvManager;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //SceneManager.LoadScene("SampleScene");
        m_scoreManager = GameObject.FindGameObjectWithTag("levelmanager").GetComponent<ScoreManager>();
        m_lvManager = GameObject.FindGameObjectWithTag("levelmanager").GetComponent<LevelManager>();

        m_lvManager.PlayScreen(true);

        m_scoreManager.m_bTimerActive = true;
        animator.SetBool("bGameStart", false);



    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(Brick.bricks.Count <= 0)
        {
          animator.SetBool("bNoBricks", true);
        }

        if (Ball.balls.Count <= 0)
        {
           

            animator.SetBool("bNoBalls", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_lvManager.PlayScreen(false);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
