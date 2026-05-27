using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : Projectile
{
    protected override void RegisterCollision(Collider2D collision)
    {
        EnemyManager enemyManager = collision.GetComponent<EnemyManager>();
        PlayerManager playerManager = collision.GetComponent<PlayerManager>();
        if(enemyManager != null)
        {
            enemyManager.TakeDamage(damageAmount);
            Destroy(gameObject);
        }
        else if(playerManager = null)
        {
            Destroy(gameObject);
        }
    }
}
