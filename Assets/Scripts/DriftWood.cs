using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriftWood : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;

    void Start()
    {
        playerManager = GameObject.FindWithTag("Player").GetComponent<PlayerManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        playerManager.AddHealth(5);
        Destroy(gameObject);
    }
}
