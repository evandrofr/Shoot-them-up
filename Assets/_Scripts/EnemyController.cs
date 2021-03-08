using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : SteerableBehaviour, IShooter, IDamageable{

    private int _lifes;

    public void Start(){
        _lifes = 3;
    }

    public void Shoot(){
        throw new System.NotImplementedException();
    }

    public void TakeDamage(){
        _lifes --;
        if(_lifes <= 0){
            Die();
        }
    }

    public void Die(){
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
