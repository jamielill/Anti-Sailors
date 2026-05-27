using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBeard : EnemyManager
{
    // is idle until the player is in a 15 unit range, the ship follows the player 
    // same speed as player - done
    // ship maintains 1 unit space between player 
    // shoots cannon balls (80%), flaming cannon balls (10%) and parrots (10%) - done
    // shoots every 0.5 seconds - done
    // 50 health - done
    // 100% chance to drop drift wood on being destroyed - done

    protected override void Start()
    {
        maxHealth = 50;
        speed = 5f;
        reloadTime = 0.5f;
        base.Start();
    }

    public override void SelectProjectile()
    {
        int projectileProb = Random.Range(1, 100);	
		if(projectileProb <= 80)
        {
            activeProjectile = cannonBall;
        }
        else if (projectileProb <= 90)
        {
            activeProjectile = flamingCannonBall;
        }
        else
        {
			activeProjectile = Random.Range(0f, 100f) < 50 ? parrot1 : parrot2;
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
