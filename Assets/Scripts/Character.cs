using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

    public Animator MyAnimator { get; set; }

    [SerializeField]
    protected Transform bulletSpawn;

    [SerializeField]
    protected float movementSpeed;

    protected bool isShooting = false;

    protected bool facingRight;

    [SerializeField]
    private GameObject bulletPrefab;

    public bool Attack { get; set; }

	// Use this for initialization
	public virtual void Start () {

        facingRight = true;

        MyAnimator = GetComponent<Animator>();

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void changeDirection()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
        
    }

    public virtual void fireBullet(int value)
    {
        isShooting = true;
        MyAnimator.SetBool("Shoot", isShooting);
        //Creates bullet from prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        if (facingRight)
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * 20;
        else
        {
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * -20;
            bullet.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
