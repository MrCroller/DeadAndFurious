using UnityEngine;

namespace DF.Map
{
    public class BorderWater : MonoBehaviour
    {
        public enum Vector
        {
            Up,
            Down
        }

        public float ForceValue;
        public Vector ForceOrientation;

        private Vector2 _forceVector;

        private void Awake()
        {
            switch (ForceOrientation)
            {
                case Vector.Up:
                    _forceVector = Vector2.up;
                    break;
                case Vector.Down:
                    _forceVector = Vector2.down;
                    break;
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            collision.attachedRigidbody.AddForce(_forceVector * ForceValue);
        }
    }
}