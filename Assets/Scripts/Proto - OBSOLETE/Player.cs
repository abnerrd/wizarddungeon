using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PROTOTYPE
{

    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : KillableUnit
    {
        private Rigidbody2D _rigidbody;

        [SerializeField]
        private float _moveSpeed;

        private Vector2 _forwardDirection;

        [SerializeField]
        private Projectile _projectilePrefab;

        private void Awake()
        {
            _rigidbody = this.GetComponent<Rigidbody2D>();
            _forwardDirection = Vector2.down;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            UpdateInput();
        }

        private void UpdateInput()
        {
            Vector2 inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (inputVector != Vector2.zero)
            {
                _forwardDirection = inputVector;
                _rigidbody.velocity = inputVector * _moveSpeed;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                ShootFireball();
            }
        }

        private void ShootFireball()
        {
            if (_projectilePrefab == null)
            {
                return;
            }

            Vector3 fireballPosition = this.transform.position + (new Vector3(_forwardDirection.x * 1.5f, 0, _forwardDirection.y * 1.5f));
            var newFireball = Instantiate(_projectilePrefab);
            newFireball.transform.position = fireballPosition;
            newFireball.transform.LookAt(fireballPosition, Vector2.up);

            newFireball.Fire(_forwardDirection);
        }

    }
}