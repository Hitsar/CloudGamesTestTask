using UnityEngine;

namespace HealthSystem
{
    public class Health : MonoBehaviour, IHealthSystem
    {
        [SerializeField] private int _maxHealth = 3;
        private int _currentHealth;
        private bool _isDied;

        private void Start()
        {
            _currentHealth = _maxHealth;
            _isDied = false;
        }

        public void ApplyDamage(int damage)
        {
            if (_isDied) return;
            
            _currentHealth -= damage;
            Debug.Log(gameObject + " Damaged " + damage);
            
            if (_currentHealth > 0) return;
            
            _isDied = true;
            gameObject.SetActive(false);
        }
    }
}