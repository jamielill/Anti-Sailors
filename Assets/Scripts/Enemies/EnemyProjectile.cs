using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : Projectile
{
    protected override void RegisterCollision(Collider2D collision)
    {
        PlayerManager player = collision.GetComponent<PlayerManager>();
        if(player != null)
        {
            player.TakeDamage(damageAmount);
            Destroy(gameObject);
        }
    }
}
