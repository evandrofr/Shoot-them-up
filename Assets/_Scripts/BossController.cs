using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : SteerableBehaviour, IShooter, IDamageable{

    private int _lifes;
    public AudioClip explosionSFX;
    public GameObject tiro;

    public void Start(){
        _lifes = 15;
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
        Destroy(gameObject);
    }

    float angle = 0;

    private void FixedUpdate(){
        angle += 0.1f;
        Mathf.Clamp(angle, 0.0f, 2.0f * Mathf.PI);
        float x = Mathf.Sin(angle);
        float y = Mathf.Cos(angle);

        Thrust(x, y);
       
    }
}
