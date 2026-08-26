using UnityEngine;

public class StateMachineScript : MonoBehaviour
{
    public static StateMachineScript Instance { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
      

     if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

       // DontDestroyOnLoad(this.gameObject);

       
    }

    // Update is called once per frame
    void Update()
    {
        

    }


}
