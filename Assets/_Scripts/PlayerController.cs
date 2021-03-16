using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SteerableBehaviour, IShooter, IDamageable{
  
    Animator animator;
    public GameObject bullet;
    public Transform arma01;

    public AudioClip shootSFX;

    public float wall_right, wall_left, wall_up, wall_down;

    public float shootDelay = 1.0f;
    private float _lastShootTimestamp = 0.0f;

    GameManager gm;


    public void Start(){
        gm = GameManager.GetInstance();
        animator = gameObject.GetComponent<Animator>();
    }


    public void Shoot(){
        if (Time.time - _lastShootTimestamp < shootDelay) return;
        AudioManager.PlaySFX(shootSFX);
        _lastShootTimestamp = Time.time;
        Instantiate(bullet, arma01.position, Quaternion.identity);
    }

    public void TakeDamage(){
        gm.vidas--;
        if (gm.vidas <= 0){
            Die();  
        } 
    }

    public void Die(){
        gm.ChangeState(GameManager.GameState.ENDGAME);
    }

    void FixedUpdate(){
        if (gm.gameState != GameManager.GameState.GAME) return;

        if(Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME){
            gm.ChangeState(GameManager.GameState.PAUSE);
        }
        if(gm.pontos >= 2500){
            gm.ChangeState(GameManager.GameState.ENDGAME);
        }

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
