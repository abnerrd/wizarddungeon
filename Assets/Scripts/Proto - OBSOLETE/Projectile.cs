using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PROTOTYPE
{

    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;

        public float _moveSpeed = 15;

        [SerializeField]
        private float _lifeTime = 15f;

        [SerializeField]
        private int _damage = 5;

        [SerializeField]
        private Vector2 _moveDirection;

        /// <summary>
        /// How many HITS can this projectile do?
        /// </summary>
        [SerializeField, Min(1)]
        private int _hitCount;

        private Coroutine _lifeCoroutine = null;

        /// <summary>
        /// List of Units that are immune to this projectile - use for Owners and multiple hits
        /// </summary>
        private List<KillableUnit> _immunityList;

        /// <summary>
        /// How many times have SPECIFIC unit been hit by this projectile?
        /// </summary>
        private Dictionary<KillableUnit, int> _victimHitCount;

        private void Awake()
        {
            _rigidbody = this.GetComponent<Rigidbody2D>();
            _immunityList = new List<KillableUnit>();
            _victimHitCount = new Dictionary<KillableUnit, int>();
        }

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            _rigidbody.velocity = _moveDirection * _moveSpeed;
        }

        public void Fire(Vector2 direction, KillableUnit immuneCaster = null)
        {
            if (_lifeCoroutine == null)
            {
                if (immuneCaster != null)
                {
                    _immunityList.Add(immuneCaster);
                }

                _moveDirection = direction;

                _lifeCoroutine = StartCoroutine(LifeCountdown());
            }
        }

        private IEnumerator LifeCountdown()
        {
            while (_lifeTime > 0)
            {
                _lifeTime -= Time.deltaTime;
                yield return null;
            }

            DestroyProjectile();
        }

        public void DestroyProjectile()
        {
            Destroy(this.gameObject);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            HandleCollision(collision);
        }
        private void OnCollisionStay2D(Collision2D collision)
        {
            // HandleCollision(collision);
        }

        private void HandleCollision(Collision2D collision)
        {
            var victim = collision.collider.GetComponent<KillableUnit>();
            if (victim == null || _immunityList.Contains(victim))
            {
                return;
            }

            DealDamageToKillable(victim);
            DestroyProjectile();
        }

        private void DealDamageToKillable(KillableUnit victim)
        {
            if (victim == null)
            {
                return;
            }

            if (!_victimHitCount.ContainsKey(victim))
            {
                _victimHitCount.Add(victim, 0);
            }

            victim.RecieveDamage(_damage);
            ++_victimHitCount[victim];

            if (!_immunityList.Contains(victim) && _victimHitCount[victim] >= _hitCount)
            {
                _immunityList.Add(victim);
                _victimHitCount.Remove(victim);
            }
        }
    }
}