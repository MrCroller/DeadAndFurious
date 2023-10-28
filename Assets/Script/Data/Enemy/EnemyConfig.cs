namespace DF.Data
{
    using UnityEngine;

    /// <summary>
    /// ������ ��� ������
    /// </summary>
    [CreateAssetMenu(fileName = nameof(EnemyConfig), menuName = "DF/Configs/Enemy/Enemy")]
    public class EnemyConfig : ScriptableObject
    {
        [SerializeField, Min(0)]
        private float _enemySpeed = default;
        [SerializeField, Min(0), Header("�������� ����� ���������� ����� (� ��������)")]
        private float _enemyShootInterval = default;

        public float EnemySpeed => _enemySpeed;
        public float EnemyShootInterval => _enemyShootInterval;
    }
}
