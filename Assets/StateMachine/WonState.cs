using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class WonState : StateMachineBehaviour
{
  
    public string PlayerText {  get; private set; }
    LevelManager lvManager;
    
    void Awake()
    {
        lvManager = GameObject.FindGameObjectWithTag("levelmanager").GetComponent<LevelManager>();
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        lvManager.GameWon(true);
            

        for (int i = 0; i < Ball.balls.Count; i++)
        {
            Ball.balls[i].StopMovement();
        }

        List<GameObject> RemainingIems = new List<GameObject>(GameObject.FindGameObjectsWithTag("item"));
        Debug.Log("Remaining dbs " + RemainingIems.Count);

        foreach (GameObject go in RemainingIems)
            go.gameObject.SetActive(false);

        GameObject.FindGameObjectWithTag("paddle").SetActive(false);
    

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      //  if(animator.Trigger)
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        lvManager.HighscoreScreen(false, false);
        SceneManager.LoadScene("SampleScene");
    }

}
