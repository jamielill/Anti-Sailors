using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected int damageAmount;
    protected float timeSinceFired = 0;
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D collision) 
    {
        RegisterCollision(collision);
    }

    protected abstract void RegisterCollision(Collider2D collision);

    void Update() {
        timeSinceFired += Time.deltaTime;
        if(timeSinceFired >= 0.8f)
        {
            Destroy(gameObject);
        }

    }
}
