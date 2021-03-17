using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : SteerableBehaviour, IShooter, IDamageable{


    public GameObject floatingTextPreFab;
    private GameObject floatingText;
    private int _lifes;
    public AudioClip explosionSFX;
    public GameObject tiro;
    private GameObject player;
    private float rotation;
    private float speed;

    GameManager gm;

    public void Start(){
        player = GameObject.Find("Player");
        gm = GameManager.GetInstance();
        _lifes = 3;
        rotation = Random.Range(10f,180f);
        speed = Random.Range(0.3f,3f);
        
    }

    public void Shoot(){
        Instantiate(tiro, transform.position, Quaternion.identity);
    }

    public void TakeDamage(){
        _lifes --;
        if(_lifes <= 0){
            ShowFloatingText();
            Die();
        }
    }

    public void ShowFloatingText(){
        floatingText = Instantiate(floatingTextPreFab, transform.position, Quaternion.identity, transform);
        floatingText.transform.parent = GameObject.Find("AsteroidePool").transform;
    }

    public void Die(){
        AudioManager.PlaySFX(explosionSFX);
        gm.pontos += 100;
        Destroy(gameObject);
    }

    public void Destruir(){
        if (gm.gameState == GameManager.GameState.MENU){
            Destroy(gameObject);
        }
    }

    

    private void FixedUpdate(){
        if (gm.gameState != GameManager.GameState.GAME) return;
        float step =  speed * Time.deltaTime; 
        if (player != null){
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        }
       
    }

    public void Update(){
        Destruir();
        transform.Rotate(new Vector3(0,0,rotation)*Time.deltaTime);
    }
}
