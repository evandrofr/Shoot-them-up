using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Menu : MonoBehaviour{

    GameManager gm;
    private void OnEnable(){
        gm = GameManager.GetInstance();
    }


    public void Comecar(){
        gm.ChangeState(GameManager.GameState.GAME);
    }
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }
}