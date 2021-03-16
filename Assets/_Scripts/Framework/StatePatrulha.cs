using UnityEngine;

public class StatePatrulha: State{
    SteerableBehaviour steerable;
    GameManager gm;

    public override void Awake()   {
        base.Awake();

        // Criamos e populamos uma nova transição
        Transition ToAtacando = new Transition();
        ToAtacando.condition = new ConditionDistLT(transform,
            GameObject.FindWithTag("Player").transform,
            10.0f);
        ToAtacando.target = GetComponent<StateAtaque>();
        // Adicionamos a transição em nossa lista de transições
        transitions.Add(ToAtacando);

        steerable = GetComponent<SteerableBehaviour>();
    }
    public void Start(){
        gm = GameManager.GetInstance();
    }

       
    float angle = 0;
    public void Update(){
        if (gm.gameState != GameManager.GameState.GAME) return;
        angle += 0.1f * Time.deltaTime;
        Mathf.Clamp(angle, 0.0f, 2.0f * Mathf.PI);
        float x = Mathf.Sin(angle);
        float y = Mathf.Cos(angle);

        steerable.Thrust(y, y);
    }
}