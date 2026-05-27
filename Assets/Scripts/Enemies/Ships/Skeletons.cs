using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeletons : EnemyManager
{
    // patrols in a 5 unit horizontal line, when the player is in 5 unit range it attacks but doesn't follow
    // shoots cannon balls (50%) and bones (50%) - done
    // shoots every second - done
    // 6 health - done
    // 20% chance to drop drift wood on being destroyed - done

    protected override void Start()
    {
        maxHealth = 6;
        speed = 2f;
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
			activeProjectile = bone;
		} 
    }

    public override void TakeDamage(int amount)
    {
        currentHealth -= amount;
        
        if(currentHealth <= 0)
        {
            int driftWoodProb = Random.Range(1, 100);
            if(driftWoodProb < 20)
            {
                Instantiate(driftWood, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
            gate.RemovePirate();
        }
    }
}
