namespace DF.Controller
{
    using System;
    using DF.Data;
    using DF.Input;
    using DF.Interface;
    using DF.Model;
    using UnityEngine;
    using UnityEngine.InputSystem;
    using static UnityEngine.RuleTile.TilingRuleOutput;
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

        public PlayerController(PlayerInput input, PlayerConfig config) 
        {
            Input = input;
            _data = new PlayerModel(config);

            Input.OnMovementEvent += OnMoveInput;
            Input.OnFireEvent     += OnFireInput;
        }

        public void Dispose()
        {
            Input.OnMovementEvent -= OnMoveInput;
            Input.OnFireEvent     -= OnFireInput;
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
        }

        private void OnMoveInput(Vector2 input)
        {
            _moveInput = input;
        }

        private void OnFireInput()
        {


            //Input.GunObject.transform.rotation
        }

        private void TakeNewGun(GunConfig gun)
        {
            _data.CurrentGun = gun;
        }

        #endregion

    }
}
