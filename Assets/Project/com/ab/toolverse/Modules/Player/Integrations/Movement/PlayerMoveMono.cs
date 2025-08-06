
using UnityEngine;

namespace com.ab.toolverse.player
{
    public class PlayerMoveMono : MonoBehaviour
    {
        public float _moveSpeed;
        public Rigidbody2D Boody;
        bool idle;

        UltimateJoystick _joystick;
        Movement _movement;
        
        const string HORIZONTAL_PARAM = "Horizontal";
        const string VERTICAL_PARAM = "Vertical";
        const string MAGNITUDE_PARAM = "Magnitude";


        void Awake() => _movement = GetComponent<PlayerStateMono>().Movement;

        void Start() => _joystick = UltimateJoystick.ReturnComponent("Movement");

        void FixedUpdate()
        {
            float x = _joystick.GetHorizontalAxis();
            float y = _joystick.GetVerticalAxis();
            Vector2 movement = new Vector2(x, y);
            
            // Animation.SetFloat(HORIZONTAL_PARAM, movement.x);
            // Animation.SetFloat(VERTICAL_PARAM, movement.y);
            // Animation.SetFloat(MAGNITUDE_PARAM, movement.magnitude);

            Boody.AddForce(Boody.position + movement * _moveSpeed);
            
            _movement.Direction = movement;
            _movement.Velocity = 0;
            
            Debug.Log($"sqr: {Boody.linearVelocity.sqrMagnitude}; mag: {Boody.linearVelocity.magnitude}");
        }
    }
}