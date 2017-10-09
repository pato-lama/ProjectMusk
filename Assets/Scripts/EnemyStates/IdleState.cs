using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IEnemyState {

    private Enemy3 enemy;

    private float idleTimer;

    private float idleDuration = 10;

	public void Enter(Enemy3 enemy){

        this.enemy = enemy;

}
    public void Execute(){

        Debug.Log("Idling");

        if (enemy.Target != null)
        {
            enemy.changeState(new PatrolState());
        }
        Idle();
              
}

    public void Exit(){

        
}

    public void OnTriggerEnter(Collider2D other){

       
}

    private void Idle()
    {
        enemy.MyAnimator.SetFloat("speed", 0);

        idleTimer += Time.deltaTime;
        if (idleTimer >= idleDuration)
        {
            enemy.changeState(new PatrolState());

        }
    }

}
