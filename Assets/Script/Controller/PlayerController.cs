﻿namespace DF.Controller
{
    using System;
    using System.Collections.Generic;
    using DF.Data;
    using DF.Extension;
    using DF.Input;
    using DF.Interface;
    using DF.Model;
    using DF.ObjectPool;
    using TimersSystemUnity.Extension;
    using TMPro;
    using UnityEngine;
    using UnityEngine.InputSystem;
    using UnityEngineTimers;
    using PlayerInput = Input.PlayerInput;
    using Random = UnityEngine.Random;

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
        private bool _soundFlag = false;
        private bool _textFlag = false;
        private TimersPool _timers;

        private Dictionary<GunConfig, ObjectPool<BulletInput>> _bulletPoolMap;
        private Dictionary<Unit, string[]> _dialogs;
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
            _dialogs = new();
        }

        public void Init()
        {
            Input.OnMovementEvent   += OnMoveInput;
            Input.OnFireEvent       += OnFireInput;
            Input.OnTakeGun         += TakeNewGun;
            Input.OnTakeExp         += AddExp;
            EnemyController.OnDeath += AddExp;
            Input.OnTakeDamage      += TakeDamage;
            Input.OnTakeSkill       += TakeSkill;
            Input.OnTakeNPC         += TakeNPC;
            
            _timers = TimersPool.GetInstance();

            _data.LVL = 1;
            _dialogs.Add(Unit.Manager, Input.ManagerDialog.Texts);
            _dialogs.Add(Unit.Haron, Input.HaronDialog.Texts);

            Input.GunObject.sprite = _data.CurrentGun.Icon;
        }

        public void Dispose()
        {
            Input.OnMovementEvent   -= OnMoveInput;
            Input.OnFireEvent       -= OnFireInput;
            Input.OnTakeGun         -= TakeNewGun;
            Input.OnTakeExp         -= AddExp;
            EnemyController.OnDeath -= AddExp;
            Input.OnTakeDamage      -= TakeDamage;
            Input.OnTakeSkill       -= TakeSkill;
            Input.OnTakeNPC         -= TakeNPC;

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

            if (!_soundFlag && _moveInput != Vector2.zero)
            {
                _soundFlag = true;
                Input.PlaySound(Input.SwimSound.RandomElement());
                _timers.StartTimer(() => _soundFlag = false, Input.SwimDelay);
            }

            if (!_textFlag)
            {
                _textFlag = true;
                _timers.StartTimer(PlayText, Input.TextDelay + Random.Range(-2f, 2f));
            }
        }

        private void PlayText()
        {
            Unit randomUnit = Extension.GetRandomValue<Unit>();

            if (randomUnit == Unit.NPC & _data.CurrentNPC == null) return;

            var text = _dialogs[randomUnit].RandomElement();

            switch (randomUnit)
            {
                case Unit.Manager:
                    TextAnim(Input.ManagerText, text);
                        break;
                case Unit.Haron:
                    TextAnim(Input.HaronText, text);
                    break;
                case Unit.NPC:
                    TextAnim(Input.NPCText, text);
                    break;
            }

            _textFlag = false;
        }

        private void TextAnim(TMP_Text tmp, string str)
        {
            tmp.text = str;
            tmp.SetAplhaDynamic(1f, 3f, 1f, false);
        }

        private void TakeNewGun(GunConfig gun)
        {
            _data.CurrentGun = gun;

            Input.GunObject.sprite = _data.CurrentGun.Icon;
            Input.PlaySound(Input.SwapGunSound);

            if (!_bulletPoolMap.ContainsKey(gun))
            {
                _bulletPoolMap.Add(gun, new(_bulletParent));
            }
        }

        private void TakeSkill(PassiveGradePlayer skill)
        {
            _data.Grades.Add(skill);
        }

        private void TakeNPC(NPCConfig npc)
        {
            _data.CurrentNPC = npc;
            Input.NPC.sprite = npc.Icon;
            _dialogs[Unit.NPC] = _data.CurrentNPC.Dialog.Texts;
        }

        private void AddExp(int count)
        {
            _data.XP += count;
            ChekLevel();
        }

        private void TakeDamage(int value)
        {
            _data.HP -= value;

            if (_data.HP < 0)
            {
                Input.OnPlayerDeath.Invoke();
                Input.OnHPChange.Invoke(0f, _data.MAXHP);
            }
            else
            {
                Input.OnHPChange.Invoke(_data.HP, _data.MAXHP);
            }
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

            var bullet = _bulletPoolMap[_data.CurrentGun].GetObjectFromPool(_data.CurrentGun.Bullet, _data.CurrentGun.BulletLifeTime);        
            ResetBullet(bullet); 
            bullet.bulletPool = _bulletPoolMap[_data.CurrentGun];

            Vector2 direction = CursorPosition - (Vector2)Input.GunObject.transform.position;
            bullet.transform.rotation = Quaternion.AngleAxis(_angleRotaitGun - 90f, Vector3.forward);

            bullet.Rigidbody.AddForce(direction.normalized * _data.CurrentGun.FireForse, ForceMode2D.Impulse);

            TimersPool.GetInstance().StartTimer(() => { _data.IsGunReload = false; Input.ReloadBar.fillAmount = 0f; },
                                                (float progress) => Input.ReloadBar.fillAmount = progress,
                                                _data.CurrentGun.AttackDelay);
        }

        private void ResetBullet(BulletInput bullet)
        {
            bullet.transform.position = Input.GunObject.transform.position;
            bullet.Rigidbody.velocity = Vector2.zero;
            bullet.Rigidbody.angularVelocity = 0f;
        }

        private int ChekLevel()
        {
            if (_data.LVL >= _data.LVLCup) return _data.LVL;

            if (_data.XP >= _data.XPNeed)
            {
                _data.LVL++;
                _data.XP = _data.XPNeed - _data.XP;
                Input.OnLVLChange.Invoke(_data.LVL);
            }

            Input.OnExpChange.Invoke(_data.XP, _data.XPNeed);
            return _data.LVL;
        }

        #endregion

    }

    enum Unit
    {
        Manager,
        Haron,
        NPC
    }
}
