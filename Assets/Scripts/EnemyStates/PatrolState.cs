﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IEnemyState {

    private Enemy3 enemy;
    private float patrolTimer;
    private float patrolDuration = 5;

	public void Enter(Enemy3 enemy){

        this.enemy = enemy;

}
    public void Execute(){

        Debug.Log("Patrolling");
        Patrol();

        enemy.Move();

        if (enemy.Target != null)
        {
            enemy.changeState(new AttackState());
        }
              
}

    public void Exit(){

        
}

    public void OnTriggerEnter(Collider2D other){

        if(other.tag == "Edge")
        {
            enemy.changeDirection();
        }
       
}

    private void Patrol()
    {

        patrolTimer += Time.deltaTime;
        if (patrolTimer >= patrolDuration)
        {
            enemy.changeState(new IdleState());

        }
    }

}
