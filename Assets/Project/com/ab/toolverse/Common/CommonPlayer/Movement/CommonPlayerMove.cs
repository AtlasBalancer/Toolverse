using UnityEngine;

public class CommonPlayerMove : MonoBehaviour
{
    public float _moveSpeed;
    public Rigidbody2D Boody;

    void Update()
    {
        float x = UltimateJoystick.GetHorizontalAxis("Movement");
        float y = UltimateJoystick.GetVerticalAxis("Movement");
        Vector2 movement = new Vector2(x, y);

        Debug.Log($"{movement}");
        Boody.MovePosition(Boody.position + movement * _moveSpeed * Time.fixedDeltaTime);
    }
}