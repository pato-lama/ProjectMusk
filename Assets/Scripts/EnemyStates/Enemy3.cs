using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : Character{

    private IEnemyState currentState;
    
    public GameObject Target { get; set; }

	// Use this for initialization
	public override void Start () {

        base.Start();
        changeState(new IdleState());
	}
	
	// Update is called once per frame
	void Update () {

        currentState.Execute();
		
	}

    public void changeState(IEnemyState newState){

        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;

        currentState.Enter(this);

    }

    public void Move()
    {
        MyAnimator.SetFloat("speed", 1);

        transform.Translate(GetDirection() * (movementSpeed * Time.deltaTime));

        if (facingRight)
        {
            Vector3 scale = transform.localScale;
            scale.x = 1;
            transform.localScale = scale;
        }
        if (!facingRight)
        {
            Vector3 scale = transform.localScale;
            scale.x = -1;
            transform.localScale = scale;
        }
    }

    public Vector2 GetDirection()
    {
        return facingRight ? Vector2.right : Vector2.left;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        currentState.OnTriggerEnter(other);
    }


}
