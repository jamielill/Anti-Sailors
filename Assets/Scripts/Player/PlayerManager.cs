using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // movement stuff
    [SerializeField] private Rigidbody2D rb;
	private Vector2 currentDirection, savedDirection;
    [SerializeField] private float speed = 5f;
    [SerializeField] private int maxHealth = 30, currentHealth;
	
    // UI/Visual stuff
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private MenuUI menuUI;
    [SerializeField] private Animator animator;

    // Weapon stuff
    [SerializeField] private Rigidbody2D cannonBall;
    [SerializeField] private float cannonBallSpeed = 6f;

    void Start() 
    {
        currentHealth = maxHealth;
        healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(maxHealth);
        menuUI = GameObject.Find("Canvas").GetComponent<MenuUI>();
    }

    void Update()
    {
        currentDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		if(currentDirection.x != 0 || currentDirection.y != 0)
		{
			savedDirection = new Vector2(currentDirection.x, currentDirection.y);
		}
		animator.SetFloat("Horizontal", savedDirection.x);
		animator.SetFloat("Vertical", savedDirection.y);
        
        if(Input.GetButtonDown("Fire1"))
        {
            FireWeapon();
        }
    }

    private void FixedUpdate() 
    {
		Vector2 movementVector = new Vector2(currentDirection.x, currentDirection.y).normalized;
        rb.velocity = movementVector * speed;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0)
        {
            menuUI.PlayerDied();
        }
    }

    public void AddHealth(int amount)
    {
        currentHealth += amount;
		currentHealth = Mathf.Min(currentHealth, maxHealth);
        healthBar.SetHealth(currentHealth);
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    public float GetVerticalVelocity()
    {
        return currentDirection.y;
    }

    public float GetHorizontalVelocity()
    {
        return currentDirection.x;
    }

    private void FireWeapon()
    {
        Rigidbody2D shot = Instantiate(cannonBall, transform.position + new Vector3(0.5f * savedDirection.x, 0.5f * savedDirection.y), transform.rotation);
        shot.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        shot.velocity = new Vector3(savedDirection.x, savedDirection.y, 0f) * cannonBallSpeed;
    }
}