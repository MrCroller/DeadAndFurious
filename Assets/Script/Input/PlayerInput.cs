namespace DF.Input
{
    using System;
    using System.Linq;
    using DF.Data;
    using DF.Extension;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.InputSystem;
    using UnityEngine.UI;

    public sealed class PlayerInput : MonoBehaviour
    {
        public event Action<Vector2>   OnMovementEvent;
        public event Action            OnFireEvent;
        public event Action            OnOpenOptionEvent;
        public event Action<GunConfig> OnTakeGun;
        public event Action<int>       OnTakeExp;
        public event Action<int>       OnTakeDamage;

        public UnityEvent OnLVLUp;
        public UnityEvent<float, float> OnHPChange;
        public UnityEvent OnPlayerDeath;

        public Rigidbody2D Rigidbody;
        public Slider HPBar;
        public Image ReloadBar;
        public SpriteRenderer GunObject;
        [SerializeField] private AudioSource _audioSource;

        [Header("Исходники звуков")]
        public AudioClip SwapGunSound;
        public AudioClip[] HitSound;
        public AudioClip[] SwimSound;
        [Tooltip("Задержка в проигрывании звука плавания")]
        public float SwimDelay;

        [HideInInspector] public bool IsControlable = true;

        private void Start()
        {
            OnLVLUp       ??= new();
            OnHPChange    ??= new();
            OnPlayerDeath ??= new();
        }

        private void Reset()
        {
            Rigidbody = Rigidbody != null ? Rigidbody : GetComponent<Rigidbody2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<BulletInput>(out BulletInput bullet))
            {
                PlaySound(HitSound.RandomElement());
                if (bullet.bulletSource == BulletSource.EnemyBullet)
                {
                    OnTakeDamageHandler(bullet.Damage);
                    bullet.bulletPool.AddToPool(bullet);
                }
            }
        }

        public void OnTakeDamageHandler(int value)
        {
            OnTakeDamage?.Invoke(value);
        }

        public void TakeGunHandler(GunConfig gun)
        {
            OnTakeGun?.Invoke(gun);
        }
        public void TakeExpHandler(int value)
        {
            OnTakeExp?.Invoke(value);
        }

        public void PlaySound(AudioClip clip)
        {
            _audioSource.Play(clip);
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
