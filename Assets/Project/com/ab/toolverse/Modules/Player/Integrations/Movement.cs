using System;
using UnityEngine;

namespace com.ab.toolverse.player
{
    [Serializable]
    public class Movement
    {
        public Vector2 Direction;
        public float Velocity;

        public float VelocityStopGap = 0.02f;

        public bool Walk() => 
            Velocity > VelocityStopGap;
    }
}