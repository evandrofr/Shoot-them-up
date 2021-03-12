using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SteerableBehaviour, IShooter, IDamageable{
  
    Animator animator;
    public GameObject bullet;
    public Transform arma01;

    public AudioClip shootSFX;

    public float wall_right, wall_left, wall_up, wall_down;

    private int _lifes;

    public float shootDelay = 1.0f;
    private float _lastShootTimestamp = 0.0f;

    public void Start(){
        animator = gameObject.GetComponent<Animator>();
        _lifes = 5;
    }


    public void Shoot(){
        if (Time.time - _lastShootTimestamp < shootDelay) return;
        AudioManager.PlaySFX(shootSFX);
        _lastShootTimestamp = Time.time;
        Instantiate(bullet, arma01.position, Quaternion.identity);
    }

    public void TakeDamage(){
        _lifes--;
        if (_lifes <= 0){
            Die();  
        } 
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
        if (collision.gameObject.name == "Wall_up"){
            transform.position = new Vector2(transform.position.x, wall_down);
        } else if (collision.gameObject.name == "Wall_down"){
            transform.position = new Vector2(transform.position.x, wall_up);
        } else if (collision.gameObject.name == "Wall_left"){
            transform.position = new Vector2(wall_right, transform.position.y);
        } else if (collision.gameObject.name == "Wall_right"){
            transform.position = new Vector2(wall_left, transform.position.y);
        }
        
}

    
}
