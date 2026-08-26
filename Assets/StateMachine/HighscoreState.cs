using UnityEngine;
using UnityEngine.SceneManagement;

public class HighscoreState : StateMachineBehaviour
{
    LevelManager lvManager;
   
    void Awake()
    {
        lvManager = GameObject.FindGameObjectWithTag("levelmanager").GetComponent<LevelManager>();
    }
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
            //lvManager.MenuScreenUI.SetActive(false);
        lvManager.MenuScreen(false);
        lvManager.HighscoreScreen(true, true);
        GameObject.FindGameObjectWithTag("paddle").SetActive(false);
    }

   
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        lvManager.HighscoreScreen(false, false);
        SceneManager.LoadScene("SampleScene");

    }

 

}
