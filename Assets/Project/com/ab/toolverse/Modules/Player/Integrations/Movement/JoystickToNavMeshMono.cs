using UnityEngine;
using UnityEngine.AI;

namespace com.ab.toolverse.player
{
    public class JoystickToNavMeshMono : MonoBehaviour
    {
        public NavMeshAgent Agent;
        public UltimateJoystick Joystick;
        bool _idle;

        const string HORIZONTAL_PARAM = "Horizontal";
        const string VERTICAL_PARAM = "Vertical";
        const string MAGNITUDE_PARAM = "Magnitude";

        void FixedUpdate()
        {
            float x = Joystick.GetHorizontalAxis();
            float y = Joystick.GetVerticalAxis();
            Vector3 movementOffset = new Vector3(x, 0, y).normalized;

            // Animation.SetFloat(HORIZONTAL_PARAM, movement.x);
            // Animation.SetFloat(VERTICAL_PARAM, movement.y);
            // Animation.SetFloat(MAGNITUDE_PARAM, movement.magnitude);

            Agent.SetDestination(transform.position + movementOffset);
            
            Debug.Log(movementOffset);
        }
    }
}