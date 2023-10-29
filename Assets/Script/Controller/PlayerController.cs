namespace DF.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DF.Data;
    using DF.Input;
    using DF.Interface;
    using DF.Model;
    using DF.ObjectPool;
    using Unity.VisualScripting;
    using UnityEngine;
    using UnityEngine.InputSystem;
    using UnityEngineTimers;
    using static Cinemachine.DocumentationSortingAttribute;
    using PlayerInput = Input.PlayerInput;

    public sealed class PlayerController : IExecute, IExecuteLater, IDisposable
    {

        #region Fields

        public readonly PlayerInput Input;
        private readonly PlayerModel _data;

        private Vector2 _moveInput;
        private Vector2 _move;
        private Vector2 m_Velocity = Vector2.zero;
        private float _angleRotaitGun;
        private bool _pressFlag = false;

        private Dictionary<GunConfig, ObjectPool<Rigidbody2D>> _bulletPoolMap;
        private Transform _bulletParent;

        public Vector2 CursorPosition
        {
            get
            {
                Vector2 cursorPosition = Mouse.current.position.ReadValue();
                return Camera.main.ScreenToWorldPoint(cursorPosition);
            }
        }

        #endregion


        #region ClassLife

        public PlayerController(PlayerInput input, PlayerConfig config, Transform bulletParent) 
        {
            Input = input;
            _data = new PlayerModel(config);
            _bulletParent = bulletParent;

            _bulletPoolMap = new() 
            { {_data.CurrentGun, new(_bulletParent) } };
            
        }

        public void Init()
        {
            Input.OnMovementEvent += OnMoveInput;
            Input.OnFireEvent     += OnFireInput;
            Input.OnTakeGun       += TakeNewGun;
            Input.OnTakeExp       += AddExp;

            Input.GunObject.sprite = _data.CurrentGun.Sprite;
        }

        public void Dispose()
        {
            Input.OnMovementEvent -= OnMoveInput;
            Input.OnFireEvent     -= OnFireInput;
            Input.OnTakeGun       -= TakeNewGun;
            Input.OnTakeExp       -= AddExp;

            foreach (var pool in _bulletPoolMap.Values)
            {
                pool.Clear();
            }
            _bulletPoolMap.Clear();
        }

        #endregion


        #region Methods

        public void Execute()
        {
            _move = _moveInput * _data.CurrentSpeed;

            Vector2 direction = CursorPosition - (Vector2)Input.GunObject.transform.position;
            _angleRotaitGun = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        }

        public void ExecuteLater()
        {
            Input.Rigidbody.velocity = Vector2.SmoothDamp(Input.Rigidbody.velocity, _move, ref m_Velocity, _data.CurrentMovementSmoothing);
            Input.GunObject.transform.rotation = Quaternion.AngleAxis(_angleRotaitGun - 90f, Vector3.forward);

            OnFire();
        }

        public void TakeNewGun(GunConfig gun)
        {
            _data.CurrentGun = gun;
            Input.GunObject.sprite = _data.CurrentGun.Sprite;

            if (!_bulletPoolMap.ContainsKey(gun))
            {
                _bulletPoolMap.Add(gun, new(_bulletParent));
            }
        }

        public void AddExp(int count)
        {
            _data.XP += count;
            ChekLevel();
        }

        private void OnMoveInput(Vector2 input)
        {
            _moveInput = input;
        }

        private void OnFireInput() => _pressFlag = !_pressFlag;

        private void OnFire()
        {
            if (_data.IsGunReload || !_pressFlag) return;
            _data.IsGunReload = true;

            var bullet = _bulletPoolMap[_data.CurrentGun].GetObjectFromPool(_data.CurrentGun.Bullet.GetComponent<Rigidbody2D>(), _data.CurrentGun.BulletLifeTime);
            ResetBullet(bullet);

            Vector2 direction = CursorPosition - (Vector2)Input.GunObject.transform.position;
            bullet.transform.rotation = Quaternion.AngleAxis(_angleRotaitGun - 90f, Vector3.forward);

            bullet.AddForce(direction.normalized * _data.CurrentGun.FireForse, ForceMode2D.Impulse);

            TimersPool.GetInstance().StartTimer(() => { _data.IsGunReload = false; Input.ReloadBar.fillAmount = 0f; },
                                                (float progress) => Input.ReloadBar.fillAmount = progress,
                                                _data.CurrentGun.AttackDelay);
        }

        private void ResetBullet(Rigidbody2D bullet)
        {
            bullet.transform.position = Input.GunObject.transform.position;
            bullet.velocity = Vector2.zero;
            bullet.angularVelocity = 0f;
        }

        private int ChekLevel()
        {
            if (_data.LVL >= _data.LVLCup) return _data.LVL;

            int totalRequiredExp = 0;
            int index = 0;
            int lvl = 0;

            do
            {
                totalRequiredExp += _data.GradeMap[index];
                index = index < _data.GradeMap.Count ? index++ : index;

                if (_data.XP >= totalRequiredExp)
                {
                    lvl++;
                }

                if (_data.LVL < lvl)
                {
                    _data.LVL++;
                    Input.OnLVLUp?.Invoke();
                }

            } while (_data.XP >= totalRequiredExp);

            return _data.LVL;
        }

        #endregion

    }
}
