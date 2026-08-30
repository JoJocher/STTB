using UnityEngine;
using UnityEngine.SceneManagement;

public class WonState : StateMachineBehaviour
{

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        LevelManager.Instance.SetGameWonScreenActive(true);

        foreach (GameObject goRemainingItem in GameObject.FindGameObjectsWithTag(ConstantValues.ItemTag))
            goRemainingItem.SetActive(false);

        //Stop Paddle Movement after Play State
        GameObject.FindGameObjectWithTag(ConstantValues.PaddleTag).SetActive(false);
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        LevelManager.Instance.SetHighscoreScreen(false, false);
        SceneManager.LoadScene(ConstantValues.GameScene);
    }
}