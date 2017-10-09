using System.Collections;
using UnityEngine;

public interface IEnemyState
{

    void Execute();
    void Enter(Enemy3 enemy);
    void Exit();
    void OnTriggerEnter(Collider2D other);

}
