using UnityEngine;
using UnityEngine.SceneManagement;

public class HighscoreState : StateMachineBehaviour
{

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        LevelManager.Instance.SetMenuScreenActive(false);
        LevelManager.Instance.SetHighscoreScreen(true, true);

        GameObject goPaddle = GameObject.FindGameObjectWithTag(ConstantValues.PaddleTag);
        if (goPaddle != null)
            goPaddle.SetActive(false);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        LevelManager.Instance.SetHighscoreScreen(false, false);
        SceneManager.LoadScene(ConstantValues.GameScene);
    }
}
