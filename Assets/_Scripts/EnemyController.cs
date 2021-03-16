using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : SteerableBehaviour, IShooter, IDamageable{

    private int _lifes;
    public AudioClip explosionSFX;
    public GameObject tiro;
    private GameObject player;

    GameManager gm;

    public void Start(){
        player = GameObject.Find("Player");
        gm = GameManager.GetInstance();
        _lifes = 3;
    }

    public void Shoot(){
        Instantiate(tiro, transform.position, Quaternion.identity);
    }

    public void TakeDamage(){
        _lifes --;
        if(_lifes <= 0){
            Die();
        }
    }

    public void Die(){
        AudioManager.PlaySFX(explosionSFX);
        gm.pontos += 100;
        Destroy(gameObject);
    }

    

    private void FixedUpdate(){
        if (gm.gameState != GameManager.GameState.GAME) return;
        transform.Rotate(0,0,transform.rotation.z+1f, Space.Self);
        float step =  1f * Time.deltaTime; 
        if (player != null){
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        }
       
    }
}
