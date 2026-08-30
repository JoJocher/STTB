using UnityEngine;

public class MenuState : StateMachineBehaviour
{
    Ball m_ball;
   
    void Awake()
    {
       m_ball = GameObject.FindGameObjectWithTag(ConstantValues.BallTag).GetComponent<Ball>();
        m_ball.IsMenu = true;
    }

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        LevelManager.Instance.SetMenuScreenActive(true);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_ball.IsMenu=false;
        m_ball.StartMovement();
       LevelManager.Instance.SetMenuScreenActive(false);
    }
}
  
