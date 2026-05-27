using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police : EnemyManager
{
    // is idle until the player is in a 15 unit range, the ship follows the player 
    // same speed as player - done
    // ship maintains 1 unit space between player 
    // shoots cannon balls (50%), handcuffs (50%) - done
    // shoots every second - done
    // 20 health - done
    // 100% chance to drop drift wood on being destroyed - done 

    protected override void Start()
    {
        maxHealth = 20;
        speed = 5f;
        reloadTime = 1f;
        base.Start();
    }

    public override void SelectProjectile()
    {
		int projectileProb = Random.Range(1, 100);	
		if(projectileProb < 50) {
			activeProjectile = cannonBall;
		} 
        else{
			activeProjectile = handCuffs;
		}
    }

    public override void TakeDamage(int amount)
    {
        currentHealth -= amount;
        
        if(currentHealth <= 0)
        {
            Instantiate(driftWood, transform.position, Quaternion.identity);
            Destroy(gameObject);
            gate.RemovePirate();
        }
    }
}
