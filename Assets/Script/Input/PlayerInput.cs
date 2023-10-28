namespace DF.Input
{
    using System;
    using DF.Data;
    using UnityEngine;
    using UnityEngine.InputSystem;
    using UnityEngine.UI;

    public sealed class PlayerInput : MonoBehaviour
    {
        public event Action<Vector2>   OnMovementEvent;
        public event Action            OnFireEvent;
        public event Action            OnOpenOptionEvent;
        public event Action<GunConfig> OnTakeGun;

        public Rigidbody2D Rigidbody;
        public Slider HPBar;
        public Image ReloadBar;
        public SpriteRenderer GunObject;
        [HideInInspector] public bool IsControlable = true;


        private void Reset()
        {
            Rigidbody = Rigidbody != null ? Rigidbody : GetComponent<Rigidbody2D>();
        }

        public void TakeGunHandler(GunConfig gun)
        {
            OnTakeGun?.Invoke(gun);
        }

        private void OnMovement(InputValue value)
        {
            if (!IsControlable) return;
            OnMovementEvent?.Invoke(value.Get<Vector2>());
        }

        private void OnFire()
        {
            if (!IsControlable) return;
            OnFireEvent?.Invoke();
        }

        private void OnOpenOption()
        {
            OnOpenOptionEvent?.Invoke();
        }
    }
}
