public class GameManager : Singleton<GameManager>
{

    private bool _isGameRunning;
    private GameStateManager _gameStateManager;
    private BoardStateManager _boardStateManager;

    private void OnEnable()
    {
        Events.GameEvents.OnBoardGenerated += ActivateBoard;

    }

    private void OnDisable()
    {
        Events.GameEvents.OnBoardGenerated -= ActivateBoard;

    }

    private void Awake()
    {
        _gameStateManager = new GameStateManager();
        _boardStateManager = new BoardStateManager();
        DeactivateBoard();
        _gameStateManager.SwitchState(new InGameState());
        _isGameRunning = true;
        //while (_isGameRunning)
        //{
        //    _stateManager.Update();
        //}
    }

    private void EndGame()
    {
        _isGameRunning = false;
        _gameStateManager.SwitchState(new EndGameState());

    }

    public void ActivateBoard()
    {
        _boardStateManager.SwitchState(new EnabledState());
    }
    public void DeactivateBoard()
    {
        _boardStateManager.SwitchState(new DisabledState());
    }

}
