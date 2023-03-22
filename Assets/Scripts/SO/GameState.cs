using UnityEngine;

public enum States { NORMAL,DIALOGUE, PAUSED}
[CreateAssetMenu(menuName = "Scriptable/States/GameState")]
public class GameState : TState<States>
{
    //GameState scriptable object is used to tell scripts in general which parts should or shouldn't be run according to the state of the game
    private void OnValidate()
    {
        Value = States.NORMAL;
    }
}

