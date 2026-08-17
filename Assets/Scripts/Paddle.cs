using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    static Vector3 v3Mouse;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    Vector3 thisPos;
    // Update is called once per frame
    void FixedUpdate()
    {
        v3Mouse = Mouse.current.position.ReadValue();
        PaddleMovement(v3Mouse);
    }

    void PaddleMovement(Vector3 _v3Mouse) 
    {
        
        thisPos = this.transform.position;

        thisPos.x = Camera.main.ScreenToWorldPoint(_v3Mouse).x;
        this.transform.position = thisPos;
    }

   public void PaddleSize(float sizeMultiplicator)
    {
        Transform Paddle = this.GetComponent<Transform>();
        Paddle.localScale = new Vector2 (Paddle.localScale.x * sizeMultiplicator, Paddle.localScale.y) ;
    }
}
