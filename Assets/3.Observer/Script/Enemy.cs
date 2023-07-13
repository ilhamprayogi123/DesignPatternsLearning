using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Observer
{
    public class Enemy : MonoBehaviour
    {
        public static event Action<Enemy> onAnyEnemyDie;

        public int enemyValue { get; private set; }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnDisable()
        {
            enemyValue = UnityEngine.Random.Range(0, 5);

            onAnyEnemyDie?.Invoke(this);
        }
    }
}


