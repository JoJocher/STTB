using UnityEngine;
using System.Collections.Generic;

public class Brick : MonoBehaviour
{
    ItemFactory itemFactory;
    Transform BrickTransform;

    public static List<Brick> bricks = new List<Brick>();
    public static List<Brick> deadbricks = new List<Brick>();
   int m_iLeben = 3;
    int m_iID;
    

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {

        itemFactory = GameObject.FindGameObjectWithTag("levelmanager").GetComponent<ItemFactory>();
        BrickTransform = GetComponent<Transform>();

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Random.ColorHSV(0f, 1f /*Farbton*/, 0.7f, 1f /*Sättigung*/, 0.7f, 1f /*Helligkeit*/);

        bricks.Add(this);
        m_iID = bricks.Count - 1;
    }


    void Start()
    {
 
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
            itemFactory.ItemRandomizer(BrickTransform);

        }

    }

void OnDisable()
    {
        bricks.Remove(this);
    }
}
