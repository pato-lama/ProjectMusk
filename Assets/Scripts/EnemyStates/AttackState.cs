using System.Collections;
using UnityEngine;

public class AttackState : IEnemyState {

    private Enemy3 enemy;

	public void Enter(Enemy3 enemy){

        this.enemy = enemy;

}
    public void Execute(){
        
        if(enemy.Target != null)
        {
            enemy.Move();
        }
        else
        {
            enemy.changeState(new IdleState());
        }
              
}

    public void Exit(){

        
}

    public void OnTriggerEnter(Collider2D other){

       
}

       
}