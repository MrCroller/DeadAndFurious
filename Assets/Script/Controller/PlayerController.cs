using System;
using DF.Data;
using DF.Input;
using DF.Interface;
using DF.Model;
using UnityEngine;

namespace DF.Controller
{
    public sealed class PlayerController : IExecuteLater, IDisposable
    {
        public readonly PlayerInput Input;
        private readonly PlayerModel _data;

        private Vector2 _moveInput;
        private Vector2 m_Velocity = Vector2.zero;

        public PlayerController(PlayerInput input, PlayerConfig config) 
        {
            Input = input;
            _data = new PlayerModel(config);

            Input.OnMovementEvent += OnMoveInput;
        }

        public void Dispose()
        {
            Input.OnMovementEvent -= OnMoveInput;
        }

        public void ExecuteLater()
        {
            var move = _moveInput * _data.Speed;
            Input.Rigidbody.velocity = Vector2.SmoothDamp(Input.Rigidbody.velocity, move, ref m_Velocity, _data.MovementSmoothing);
        }

        private void OnMoveInput(Vector2 input)
        {
            _moveInput = input;
        }
    }
}
