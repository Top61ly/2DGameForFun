using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BulletsGenerator
{
    public class Boss : MonoBehaviour
    {
        public int health = 100;

        public Transform boss;

        public BulletsWave[] bulletsWaveCollected = new BulletsWave[0];

        private bool isCoroutineOver = false;

        private void Start()
        {
            for (int i = 0;i<bulletsWaveCollected.Length;i++)
            {
                bulletsWaveCollected[i].Init();
            }
            StartCoroutine(GenerateWaves());
       }

        private void Update()
        {
            while(health>0 && isCoroutineOver)
            {
                StartCoroutine(GenerateWaves());
            }           
        }

        IEnumerator GenerateWaves()
        {
            isCoroutineOver = false;
            int index = Random.Range(0, bulletsWaveCollected.Length);
            bulletsWaveCollected[index].Shoot(this, transform);
            yield return new WaitForSeconds(bulletsWaveCollected[index].time);
            isCoroutineOver = true;
        }

    }
}