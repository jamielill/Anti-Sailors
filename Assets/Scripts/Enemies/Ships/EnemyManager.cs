using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyManager : MonoBehaviour
{  
    // movement stuff
    protected Animator animator;
    protected Rigidbody2D rb;
    protected float vertDirection, horizDirection;
    protected float speed;

    // attacking
    protected float projectileSpeed = 6f;
    protected float reloadTime;
    protected bool readyToFire = true;
    protected bool playerInRange = false;
    protected Rigidbody2D activeProjectile;
    [SerializeField] protected Rigidbody2D cannonBall, flamingCannonBall, coconut, bone, handCuffs, parrot1, parrot2;

    protected int currentHealth;
    [SerializeField] protected int maxHealth;
    [SerializeField] protected GameObject driftWood;
    protected Gate gate;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        gate = GameObject.Find("Gate").GetComponent<Gate>();
    }

    protected void Update()
    {
        if(horizDirection != 0 || vertDirection != 0)
        {
            animator.SetFloat("Horizontal", horizDirection);
            animator.SetFloat("Vertical", vertDirection);
        }

        if(playerInRange && readyToFire)
        {
            FireWeapon();
        }
    }

    public virtual void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if(currentHealth <= 0)
        {
            Destroy(gameObject);
            gate.RemovePirate();
        }
    }

    // movement
    public void ControlEnemy(float hInput, float vInput)
    {
        horizDirection = hInput;
        vertDirection = vInput;
    }

    protected void FixedUpdate() 
    {
        rb.velocity = new Vector2(horizDirection * speed, vertDirection * speed);
    }

    // attacking
    public virtual void SelectProjectile()
    {
    }

    public void SetPlayerInRange(bool range)
    {
        playerInRange = range;
    }

    protected void FireWeapon()
    {
        SelectProjectile();
        Rigidbody2D shot;
        shot = Instantiate(activeProjectile, transform.position + new Vector3(0.5f*horizDirection, 0.5f*vertDirection, 0f), transform.rotation);
        shot.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        shot.velocity = new Vector3(horizDirection, vertDirection, 0f) * projectileSpeed;
        readyToFire = false;
        StartCoroutine(Reload());
    }

    protected IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        readyToFire = true;
    }

}

