public class InGameState : IGameState
{
 
    public void Enter()
    {
        GameLogic.Instance?.StartGame();
        UIManager.Instance?.ShowGameScreen();
        // Set up the game board, initialize the level
    }

    public void Update()
    {

        // Update game logic, handle player input, check for matches
    }

    public void Exit()
    {
        // Clean up resources, save game progress if necessary
    }

    
}