using UnityEngine;

public interface IGameStatesPT
{
    void OnStateEnter(GameManagerScriptPT gameManager);
    void Execute(GameObject tower, int player);  
}
