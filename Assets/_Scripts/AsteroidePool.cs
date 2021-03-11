using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidePool : MonoBehaviour{

    public GameObject ObjectToPool;
    public int PoolSize;
    public int x_max, y_max;
    System.Random rnd = new System.Random();

    private List<GameObject> PooledObjects;

    private void Awake(){
        PooledObjects = new List<GameObject>();
        for(int poolCount = 0; poolCount < PoolSize; poolCount++){
            int x, y;
            x = rnd.Next(-x_max,x_max);
            y = rnd.Next(-y_max,y_max);
            Vector3 posicao = new Vector3(x, y);
            GameObject pooled = Instantiate(ObjectToPool, posicao, Quaternion.identity, transform);
            pooled.SetActive(true);
            PooledObjects.Add(pooled);
        }
    }


    // Start is called before the first frame update
    void Start(){
        // Construir();
    }

    // Update is called once per frame
    void Update(){
        
    }

    // void Construir(){
    //     for(int i = 0; i < 3; i++){
    //         for(int j = 0; j < 3; j++){
    //             Vector3 posicao = new Vector3(2.0f * i, 1.0f * j);
    //             Instantiate(ObjectToPool, posicao, Quaternion.identity, transform);
    //         }
    //     }
    // }
}
