using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    protected enum AIState {Idle, Patrolling, Attacking};
    protected AIState aiState;
    protected enum AIMoveDirection {North, NorthEast, East, SouthEast, South, SouthWest, West, NorthWest, Stop}
    protected AIMoveDirection aiMoveDirection;

    protected EnemyManager enemyManager;
    protected GameObject player;
    protected float playerDistanceX, playerDistanceY, attackRange = 5f;
    protected float decisionTimer, decisionDelay = 0.25f;
	protected int currentMove;

    // Start is called before the first frame update
    protected void Start()
    {
        enemyManager = GetComponent<EnemyManager>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    protected void Update()
    {
        if(player != null)
        {
            CheckPlayerInRange();

            if(aiState == AIState.Patrolling)
            {
                Patrol();
                enemyManager.SetPlayerInRange(false);
            }
            else if(aiState == AIState.Attacking)
            {
                MoveTowardsPlayer();
                enemyManager.SetPlayerInRange(true);
            }
        }
    }

    protected void MoveNorth()
    {
        enemyManager.ControlEnemy(0, 1);
    }

    protected void MoveNorthEast()
    {
        enemyManager.ControlEnemy(1, 1);
    }
    protected void MoveEast()
    {
        enemyManager.ControlEnemy(1, 0);
    }

    protected void MoveSouthEast()
    {
        enemyManager.ControlEnemy(1, -1);
    }

    protected void MoveSouth()
    {
        enemyManager.ControlEnemy(0, -1);
    }

    protected void MoveSouthWest()
    {
        enemyManager.ControlEnemy(-1, -1);
    }

    protected void MoveWest()
    {
        enemyManager.ControlEnemy(-1, 0);
    }

    protected void MoveNorthWest()
    {
        enemyManager.ControlEnemy(-1, 1);
    }

    protected void StopMoving()
    {
        enemyManager.ControlEnemy(0, 0);
    }

    protected void CheckPlayerInRange()
    {
        playerDistanceX = player.transform.position.x - transform.position.x;
        playerDistanceY = player.transform.position.y - transform.position.y;

        if(Mathf.Abs(playerDistanceX) < attackRange && Mathf.Abs(playerDistanceY) < attackRange)
        {
            aiState = AIState.Attacking;
        }
        else
        {
            aiState = AIState.Patrolling;
        }
    }

    protected bool DecisionTimer()
    {
        decisionTimer += Time.deltaTime;
        if(decisionTimer >= decisionDelay)
        {
            decisionTimer = 0f;
            return true;
        }
        else
        {
            return false;
        }
    }

    protected void MoveTowardsPlayer()
    {
        if(DecisionTimer())
        {
            List<AIMoveDirection> possibleMove = new List<AIMoveDirection>();

            if(playerDistanceX <= -1)
            {
                possibleMove.Add(AIMoveDirection.West);
            }
            else if(playerDistanceX > 1)
            {
                possibleMove.Add(AIMoveDirection.East);
            }

            if(playerDistanceX <= -1 && playerDistanceY > 1) 
            {
                possibleMove.Add(AIMoveDirection.NorthWest);
            }
            else if(playerDistanceX > 1 && playerDistanceY > 1)
            {
                possibleMove.Add(AIMoveDirection.NorthEast);
            }

            if(playerDistanceY <= -1)
            {
                possibleMove.Add(AIMoveDirection.South);
            }
            else if(playerDistanceY > 1)
            {
                possibleMove.Add(AIMoveDirection.North);
            }

            if(playerDistanceX <= -1 && playerDistanceY <= -1) 
            {
                possibleMove.Add(AIMoveDirection.SouthWest);
            }
            else if(playerDistanceX > 1 && playerDistanceY <= -1)
            {
                possibleMove.Add(AIMoveDirection.SouthEast);
            }


            int randomMove = Random.Range(0, possibleMove.Count);
            aiMoveDirection = possibleMove[randomMove];

            switch(aiMoveDirection)
            {
                case AIMoveDirection.North:
                    MoveNorth();
                    break;
                case AIMoveDirection.NorthEast:
                    MoveNorthEast();
                    break;
                case AIMoveDirection.East:
                    MoveEast();
                    break;
                case AIMoveDirection.SouthEast:
                    MoveSouthEast();
                    break;
                case AIMoveDirection.South:
                    MoveSouth();
                    break;
                case AIMoveDirection.SouthWest:
                    MoveSouthWest();
                    break;
                case AIMoveDirection.West:
                    MoveWest();
                    break;
                case AIMoveDirection.NorthWest:
                    MoveNorthWest();
                    break;
                
            }
        }
    }

    protected virtual void Patrol()
    {
		
        if(DecisionTimer())
        {
			currentMove++;
			if(currentMove == (int)AIMoveDirection.Stop)
            {
				currentMove = 0;
            }
			AIMoveDirection aiMoveDirection = (AIMoveDirection)currentMove;
            switch(aiMoveDirection)
            {
                case AIMoveDirection.North:
                    MoveNorth();
                    break;
                case AIMoveDirection.NorthEast:
                    MoveNorthEast();
                    break;
                case AIMoveDirection.East:
                    MoveEast();
                    break;
                case AIMoveDirection.SouthEast:
                    MoveSouthEast();
                    break;
                case AIMoveDirection.South:
                    MoveSouth();
                    break;
                case AIMoveDirection.SouthWest:
                    MoveSouthWest();
                    break;
                case AIMoveDirection.West:
                    MoveWest();
                    break;
                case AIMoveDirection.NorthWest:
                    MoveNorthWest();
                    break;
                
            }
		}
    }
}
