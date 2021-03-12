using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Pause : MonoBehaviour{

    GameManager gm;
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    private void OnEnable(){
        gm = GameManager.GetInstance();
    }

    public void Retornar(){
        gm.ChangeState(GameManager.GameState.GAME);
    }

    public void Inicio(){
      gm.ChangeState(GameManager.GameState.MENU);
    }
}
