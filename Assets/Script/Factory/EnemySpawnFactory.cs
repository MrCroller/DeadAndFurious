namespace DF.Factory
{
    using DF.Input;
    using UnityEngine;

    public sealed class EnemySpawnFactory
    {
        /// <summary>
        /// Фабричный метод для спавна врагов
        /// </summary>
        /// <param name="enemyPrefab"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public void SpawnEnemy(Enemy enemyPrefab, Vector3 position)
        {
            GameObject enemy = GameObject.Instantiate(enemyPrefab.gameObject, position, Quaternion.identity);
            //enemy.GetComponent<Enemy>().InitController();
        }
    }
}
