public class GameManager : Singleton<GameManager>
{

    private bool _isGameRunning;
    private GameStateManager _stateManager;
    private void Start()
    {
        _stateManager = new GameStateManager();
        _stateManager.SwitchState(new InGameState());
        _isGameRunning = true;

        //while (_isGameRunning)
        //{
        //    _stateManager.Update();
        //}
    }

    private void EndGame()
    {
        _isGameRunning = false;
        _stateManager.SwitchState(new GameEndState());

    }


}
