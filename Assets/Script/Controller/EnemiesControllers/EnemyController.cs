namespace DF.Controller
{
    using DF.Input;
    using UnityEngine;

    public class EnemyController : MonoBehaviour
    {
        private const float ENEMY_SPEED = 0.1f;
        [SerializeField]
        private Enemy _enemy = default;
        protected bool isMove = true;

        private float _speed;

        private void Start()
        {
            _speed = ENEMY_SPEED;
        }

        protected void FixedUpdate()
        {
            _enemy.transform.position = new Vector3(_enemy.transform.position.x, _enemy.transform.position.y - _speed, 0);
        }
    }
}