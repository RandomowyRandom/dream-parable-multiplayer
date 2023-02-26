using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "EnemySettings", menuName = "SO/EnemySettings", order = 0)]
    public class EnemySettings: ScriptableObject
    {
        [SerializeField]
        private float _shootRange = 2f;
        
        [SerializeField]
        private float _speed = 2f;
        
        [SerializeField]
        private int _baseHealth = 3;
        
        [SerializeField]
        private int _baseDamage = 1;

        public float ShootRange => _shootRange;

        public float Speed => _speed;

        public int BaseHealth => _baseHealth;

        public int BaseDamage => _baseDamage;
    }
}