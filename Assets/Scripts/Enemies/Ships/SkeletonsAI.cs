using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonsAI : EnemyAI
{
    protected override void Patrol()
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
                case AIMoveDirection.East:
                    MoveEast();
                    break;
                case AIMoveDirection.West:
                    MoveWest();
                    break;
            }
		}
    }
}
