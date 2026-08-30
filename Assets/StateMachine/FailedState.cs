using UnityEngine;
using UnityEngine.SceneManagement;

public class FailedState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        LevelManager.Instance.SetGameOverScreenActive(true);

        GameObject.FindGameObjectWithTag(ConstantValues.PaddleTag).SetActive(false);
        foreach (GameObject goRemainingItem in GameObject.FindGameObjectsWithTag(ConstantValues.ItemTag))
            goRemainingItem.SetActive(false);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SceneManager.LoadScene(ConstantValues.GameScene);
    }
}
