using System;
using UnityEngine;

public class CommonPlayerMove : MonoBehaviour
{
    public float _moveSpeed;
    public Rigidbody2D Boody;
    public Animator Animation;
    bool idle;

    UltimateJoystick _joystick;


    const string HORIZONTAL_PARAM = "Horizontal";
    const string VERTICAL_PARAM = "Vertical";
    const string MAGNITUDE_PARAM = "Magnitude";

    void Start()
    {
        _joystick = UltimateJoystick.ReturnComponent("Movement");
    }

    void FixedUpdate()
    {

        float x = _joystick.GetHorizontalAxis();
        float y = _joystick.GetVerticalAxis();
        Vector2 movement = new Vector2(x, y);

        Animation.SetFloat(HORIZONTAL_PARAM, movement.x);
        Animation.SetFloat(VERTICAL_PARAM, movement.y);
        Animation.SetFloat(MAGNITUDE_PARAM, movement.magnitude);

        Debug.Log($"{movement}");
        Boody.MovePosition(Boody.position + movement * _moveSpeed * Time.fixedDeltaTime);
        
    }
}