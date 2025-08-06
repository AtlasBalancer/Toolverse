using UnityEngine;

namespace com.ab.toolverse.player
{
    public class PlayerDirectionMono : MonoBehaviour
    {
        public Transform RenderContainer;
        public SpriteRenderer Up;
        public SpriteRenderer Down;
        
        Movement _movement;

        void Awake() => _movement = GetComponent<PlayerStateMono>().Movement;

        void Update()
        {
            if (_movement.Walk())
            {
                
            }

            if (_movement.Direction.y > 0)
            {
                Up.enabled = true;
                Down.enabled = false;
            }
            else
            {
                Up.enabled = false;
                Down.enabled = true;
            }


            if (_movement.Direction.x > 0)
            {
                RenderContainer.transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                RenderContainer.transform.localScale = new Vector3(1, 1, 1);
            }
            
        }
    }
}