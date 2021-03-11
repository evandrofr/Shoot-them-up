using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBehaviour : SteerableBehaviour{

    public GameObject _original;
    private GameObject arma;
    private Vector2 vetor_arma;
    // Start is called before the first frame update
    void Start(){
        arma = GameObject.Find("Arma01");
        vetor_arma = arma.transform.up;
    }

    // Update is called once per frame
    void Update(){
        Thrust(vetor_arma.x, vetor_arma.y);
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
