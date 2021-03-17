using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour{

    private float DestroyTime = 0.5f;
    private GameObject newObject;
    // Start is called before the first frame update
    void Start(){   
        Destroy(gameObject, DestroyTime);
    }

    // Update is called once per frame
    void Update(){
        
    }
}
