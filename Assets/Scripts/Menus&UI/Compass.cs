using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private Animator animator;

    // Update is called once per frame
    void Update()
    {
        if(playerManager.GetHorizontalVelocity() != 0 || playerManager.GetVerticalVelocity() != 0) 
        {
            animator.SetFloat("Horizontal", playerManager.GetHorizontalVelocity());
            animator.SetFloat("Vertical", playerManager.GetVerticalVelocity());
        }
    }
}
