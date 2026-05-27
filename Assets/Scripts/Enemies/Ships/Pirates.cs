using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pirates : EnemyManager
{
    // patrols in a 5 unit circle, when the player is in 5 unit range, the ship follows the player 
    // 0.75x speed of player - done
    // ship attempts to maintains 1 unit space between player, when out of 5 unit range, patrols again 
    // shoots cannon balls (70%), coconuts (20%) and parrots (10%) - done
    // shoots every second - done
    // 10 health - done
    // 50% chance to drop drift wood on being destroyed - done

    protected override void Start()
    {
        maxHealth = 10;
        speed = 3.75f;
        reloadTime = 1f;
        base.Start();
    }

    public override void SelectProjectile()
    {
        int projectileProb = Random.Range(1, 100);
		if(projectileProb <= 70)
        {
            activeProjectile = cannonBall;
        }
        else if(projectileProb <= 90)
        {
            activeProjectile = coconut;
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
            int driftWoodProb = Random.Range(1, 100);
            if(driftWoodProb < 50)
            {
                Instantiate(driftWood, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
            gate.RemovePirate();
        }
    }
}
