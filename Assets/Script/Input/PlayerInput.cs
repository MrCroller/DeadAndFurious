namespace DF.Input
{
    using System;
    using UnityEngine;
    using UnityEngine.InputSystem;

    public sealed class PlayerInput : MonoBehaviour
    {
        public event Action<Vector2> OnMovementEvent;

        public Rigidbody2D Rigidbody;

        private void Reset()
        {
            Rigidbody = Rigidbody != null ? Rigidbody : GetComponent<Rigidbody2D>();
        }


        private void OnMovement(InputValue value)
        {
            OnMovementEvent?.Invoke(value.Get<Vector2>());
        }

        private void OnFire()
        {
            Debug.Log("fire");
        }
    }
}
