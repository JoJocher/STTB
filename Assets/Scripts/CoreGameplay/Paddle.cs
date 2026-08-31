using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    public float BasePaddleScaleX { get; private set; }
    private void Awake()
    {
       BasePaddleScaleX  = transform.localScale.x;
    }
    void Update()
    {
        Vector3 v3Mouse = Mouse.current.position.ReadValue();
        MovePaddle(v3Mouse);
    }

    void MovePaddle(Vector3 _mousePosition) 
    { 
        Vector3 v3PaddlePosition = transform.position;

        v3PaddlePosition.x = Camera.main.ScreenToWorldPoint(_mousePosition).x;
        transform.position = v3PaddlePosition;
    }

   public void ScalePaddleWidth(float _sizeMultiplier)
    {
        transform.localScale = new Vector3(transform.localScale.x * _sizeMultiplier, transform.localScale.y, transform.localScale.z);
    }
}
