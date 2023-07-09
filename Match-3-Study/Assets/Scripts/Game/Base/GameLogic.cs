using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : Singleton<GameLogic>
{
    #region Helpers
    private MatchHelper _matchHelper;
    private LevelHelper _levelHelper;

    #endregion

    public void StartGame()
    {
        Init();
        var board = _levelHelper?.GenerateBoardForLevel();
        _matchHelper?.SetBoard(board);
    }

    
    public void Init()
    {
        CreateHelpers();
        _levelHelper?.Init();
        _matchHelper?.Init();
    }

    public void CheckForMatches(Cube cube)
    {
        _matchHelper?.CheckForMatches(cube);
    }

    private void CreateHelpers()
    {
        GameObject go = new GameObject();
        go.name = "Helpers";
        _levelHelper = go.AddComponent<LevelHelper>();
        _matchHelper = go.AddComponent<MatchHelper>();
    }

    public void EnableBoard(bool isEnabled)
    {
        _levelHelper?.EnableBoard(isEnabled);
    }


}
