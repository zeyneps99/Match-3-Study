public class InGameState : IGameState
{
    public void Enter()
    {
        GameLogic.Instance?.StartGame();
        UIManager.Instance?.ShowGameScreen();
    }

    public void Exit()
    {
    }

    public void Update()
    {
    }
}