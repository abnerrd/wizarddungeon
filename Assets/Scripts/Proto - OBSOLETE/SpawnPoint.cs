using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PROTOTYPE
{

    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField]
        private GameObject _spawnPrefab;

        [SerializeField]
        private float _spawnFrequency;
        [SerializeField]
        private int _spawnAmount;
        [SerializeField]
        private float _spawnCounter = 0;

        [SerializeField]
        private Collider2D _spawnArea;


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (_spawnCounter <= 0)
            {
                _spawnCounter = _spawnFrequency;
                Spawn(_spawnAmount);
            }

            _spawnCounter -= Time.deltaTime;
        }

        private void Spawn(int amount)
        {
            if (_spawnPrefab == null)
            {
                Debug.LogWarning($"No prefab to spawn for {this}");
                return;
            }

            for (int i = 0; i < amount; ++i)
            {
                var spawnPosition = this.transform.position;
                if (_spawnArea != null)
                {
                    spawnPosition.x += Random.Range(0, _spawnArea.bounds.extents.x);
                    spawnPosition.y += Random.Range(0, _spawnArea.bounds.extents.y);
                }

                var newObject = Instantiate(_spawnPrefab);
                newObject.transform.position = spawnPosition;
            }
        }
    }
}