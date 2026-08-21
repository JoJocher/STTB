using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class LevelManager : MonoBehaviour
{
   [SerializeField] TMP_Text BrickCounter;

    int m_iBrickCountOld;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BrickCounterText();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Brick.bricks.Count != m_iBrickCountOld)
            BrickCounterText();
    }


    void BrickCounterText()
    {
        m_iBrickCountOld = Brick.bricks.Count;
        BrickCounter.text = "Verbleibende Blöcke: " + Brick.bricks.Count;
    }

    
}