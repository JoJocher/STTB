using UnityEngine;
using System.Collections.Generic;

public class Brick : MonoBehaviour
{
    public static List<Brick> bricks = new List<Brick>();
    public static List<Brick> deadbricks = new List<Brick>();
   int m_iLeben = 3;
    int m_iID;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Random.ColorHSV(0f, 1f /*Farbton*/, 0.7f, 1f /*Sättigung*/, 0.7f, 1f /*Helligkeit*/);
        bricks.Add(this);
        m_iID = bricks.Count - 1;
    }

    

    void OnCollisionEnter2D()
    {

        m_iLeben--;

        if( m_iLeben <= 0 )

        {
            this.gameObject.SetActive(false);
            // destroy den brick & trigger ein item
            bricks.Remove(this);
            deadbricks.Add(this);

            
        }

    }

    void OnEnable()
    {

    }

    void OnDisable()
    {

    }
}
