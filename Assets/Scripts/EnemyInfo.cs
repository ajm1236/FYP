using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    [System.Serializable]
    public class EnemyStatus
    {
        public float health = 1f;

    }
    public EnemyStatus enemyStatus = new EnemyStatus();

    public void HitEnemy(float damage)
    {
        enemyStatus.health -= damage;
        if (enemyStatus.health <= 0)
        {
            GameStuff.DestroyEnemy(this);
        }
    }
}
