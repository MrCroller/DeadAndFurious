namespace DF.UI
{
    using DF.Controller;
    using System;
    using UnityEngine;
    using UnityEngine.UI;

    public class Score : MonoBehaviour
    {
        [SerializeField]
        private Text _scoreText = default;

        private int _score = 0;

        private void Start()
        {
            _score = 0;
            EnemyController.OnDeath += SetScore;
        }

        public void SetScore(int expPoint)
        {
            _score += expPoint;
            _scoreText.text = _score.ToString();
        }

        private void OnDestroy()
        {
            EnemyController.OnDeath -= SetScore;            
        }
    }
}
