namespace DF.Input
{
    using System;
    using UnityEngine;
    using UnityEngine.InputSystem;

    public sealed class PlayerInput : MonoBehaviour
    {
        public event Action<Vector2> OnMovementEvent;
        public event Action          OnOpenOptionEvent;

        public Rigidbody2D Rigidbody;
        [HideInInspector] public bool IsControlable = true;

        private void Reset()
        {
            Rigidbody = Rigidbody != null ? Rigidbody : GetComponent<Rigidbody2D>();
        }

        private void OnMovement(InputValue value)
        {
            if (!IsControlable) return;
            OnMovementEvent?.Invoke(value.Get<Vector2>());
        }

        private void OnFire()
        {
            if (!IsControlable) return;
            Debug.Log("fire");
        }

        private void OnOpenOption()
        {
            OnOpenOptionEvent?.Invoke();
        }
    }
}
