using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidePool : MonoBehaviour{

    public GameObject ObjectToPool;
    public int PoolSize;
    public int x_max, y_max;
    public float time_spawn;
    System.Random rnd = new System.Random();

    GameManager gm;

    private List<GameObject> PooledObjects;

    private void Construir(){
        if (gm.gameState == GameManager.GameState.GAME){
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
    }


    private IEnumerator Spawner(){
        yield return new WaitForSeconds(time_spawn);
        while(gm.gameState == GameManager.GameState.GAME){
            yield return new WaitForSeconds(time_spawn);
            int x, y;
            x = rnd.Next(-x_max,x_max);
            y = rnd.Next(-y_max,y_max);
            Vector3 posicao = new Vector3(x, y);
            GameObject pooled = Instantiate(ObjectToPool, posicao, Quaternion.identity, transform);
            pooled.SetActive(true);
            PooledObjects.Add(pooled);
            time_spawn -= 0.1f;
            if(time_spawn < 1f){
                time_spawn = 1f;
            }
        }
    }


    // Start is called before the first frame update
    void Start(){
        gm = GameManager.GetInstance();
        GameManager.changeStateDelegate += Construir;
        Construir();
        time_spawn = 5f;
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update(){
        
    }

}
