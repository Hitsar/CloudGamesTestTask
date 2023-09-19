using HealthSystem;
using UnityEngine;

namespace Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _attackDistance;
        private EnemyVfx _vfx;

        private void Start() => _vfx = new EnemyVfx(GetComponentInChildren<Animator>());

        private void OnTriggerEnter(Collider other)
        {
            Vector3 direction = (other.gameObject.transform.position - transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            _vfx.Attack();
        }

        private void Attack()
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, _attackDistance) && hit.collider.gameObject.TryGetComponent(out IHealthSystem healthSystem)) healthSystem.ApplyDamage(_damage);
        }
    }
}