using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PROTOTYPE
{
    public class KillableUnit : MonoBehaviour
    {
        private bool _isDead = false;
        public bool IsDead => _isDead;

        public int StartingHp = 15;

        [SerializeField]
        private int _currentHp = 0;

        private void Awake()
        {
            _currentHp = _currentHp > 0 ? _currentHp : StartingHp;
        }

        public void RecieveDamage(int damage)
        {
            _currentHp -= damage;
            if (_currentHp <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            _isDead = true;
            OnDeath();
        }

        protected virtual void OnDeath()
        {

        }


    }
}