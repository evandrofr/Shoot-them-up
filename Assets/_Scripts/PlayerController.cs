using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SteerableBehaviour, IShooter, IDamageable{
  
    Animator animator;
    public GameObject bullet;
    public Transform arma01;

    private int _lifes;

    public float shootDelay = 1.0f;
    private float _lastShootTimestamp = 0.0f;

    public void Start(){
        animator = gameObject.GetComponent<Animator>();
        _lifes = 10;
    }


    public void Shoot(){
        if (Time.time - _lastShootTimestamp < shootDelay) return;
        _lastShootTimestamp = Time.time;
        Instantiate(bullet, arma01.position + new Vector3(0.0f, 1.0f, 0.0f), Quaternion.identity);
    }

    public void TakeDamage(){
        _lifes--;
        if (_lifes <= 0) Die();
    }

    public void Die(){
        Destroy(gameObject);
    }

    void FixedUpdate(){
        float yInput = Input.GetAxis("Vertical");
        float xInput = Input.GetAxis("Horizontal");
        Thrust(xInput, yInput);
        animator.SetFloat("VelocityX", xInput);
        animator.SetFloat("VelocityY", yInput);
        if(Input.GetAxisRaw("Jump") != 0){
           Shoot();
       }
        

    }    


    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Inimigo")){
            Destroy(collision.gameObject);
            TakeDamage();
        }
}

    
}
