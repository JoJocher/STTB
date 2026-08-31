using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    ItemFactory m_itemFactory;
    public static readonly List<Brick> s_Bricks = new List<Brick>();
    int m_iLives = 3;

    void Awake()
    {
        m_itemFactory = GameObject.FindGameObjectWithTag(ConstantValues.LevelmanagerTag).GetComponent<ItemFactory>();

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Random.ColorHSV(0f, 1f /*Hue*/, 0.7f, 1f /*Saturation*/, 0.7f, 1f /*Brightness*/);

        s_Bricks.Add(this);
    }


    void OnCollisionEnter2D()
    {
        m_iLives--;

        if (m_iLives <= 0)
        {
            gameObject.SetActive(false);
            m_itemFactory.SpawnRandomItem(transform);
            ScoreManager.Instance.AddPoints(PointType.Brick);
        }
    }

    void OnDisable()
    {
        s_Bricks.Remove(this);
    }
}
