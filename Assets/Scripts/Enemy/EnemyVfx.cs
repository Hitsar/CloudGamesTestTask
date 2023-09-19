using UnityEngine;

namespace Enemy
{
    public class EnemyVfx
    {
        private readonly Animator _animator;

        public EnemyVfx(Animator animator) => _animator = animator;

        public void Attack() => _animator.SetTrigger("Attack");
    }
}