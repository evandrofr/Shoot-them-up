using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBehaviour : SteerableBehaviour{

    public GameObject _original;
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        Thrust(0, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Player")) return;
        IDamageable damageable = collision.gameObject.GetComponent(typeof(IDamageable)) as IDamageable;
        if (!(damageable is null)){
            damageable.TakeDamage();
        }
        Destroy(gameObject);
   }
}
