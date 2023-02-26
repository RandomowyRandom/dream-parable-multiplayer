using System;
using Mirror;
using UnityEngine;

namespace DefaultNamespace
{
    public class EnemySpawnerManager: NetworkBehaviour
    {
        [SerializeField]
        private GameObject _enemyPrefab;
        
        [SerializeField]
        private float _spawnInterval = 5f;
        
        [SerializeField]
        private int _maxEnemies = 10;
        
        [SerializeField]
        private EnemySettings _enemySettings;
        
        [SerializeField]
        private Transform _firstSpawnCorner;
        
        [SerializeField]
        private Transform _secondSpawnCorner;

        private void Start()
        {
            if(!isServer)
                return;
            
            InvokeRepeating(nameof(SpawnEnemy), 0f, _spawnInterval);
        }

        private void OnDrawGizmos()
        {
            if(_firstSpawnCorner == null || _secondSpawnCorner == null)
                return;
            
            Gizmos.color = Color.red;
            
            Gizmos.DrawWireCube((_firstSpawnCorner.position + _secondSpawnCorner.position) / 2f, 
                new Vector3(Mathf.Abs(_firstSpawnCorner.position.x - _secondSpawnCorner.position.x), 
                    Mathf.Abs(_firstSpawnCorner.position.y - _secondSpawnCorner.position.y), 0f));
        }

        private void SpawnEnemy()
        {
            var enemy = Instantiate(_enemyPrefab, GetPointInSpawnArea(), Quaternion.identity);
            NetworkServer.Spawn(enemy);
        }
        
        private Vector2 GetPointInSpawnArea()
        {
            var x = UnityEngine.Random.Range(_firstSpawnCorner.position.x, _secondSpawnCorner.position.x);
            var y = UnityEngine.Random.Range(_firstSpawnCorner.position.y, _secondSpawnCorner.position.y);
            
            return new Vector2(x, y);
        }
    }
}