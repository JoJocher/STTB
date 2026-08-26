using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuState : StateMachineBehaviour
{
    LevelManager lvManager;
    Ball m_Ball;
   
    void Awake()
    {
        lvManager = GameObject.FindGameObjectWithTag("levelmanager").GetComponent<LevelManager>();

        m_Ball = GameObject.Find("Ball").GetComponent<Ball>();

        m_Ball.m_bIsMenu = true;
    }


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        lvManager.MenuScreen(true);
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_Ball.m_bIsMenu = false;
        m_Ball.StartMovement();
       lvManager.MenuScreen(false);
       
    }
}
  
