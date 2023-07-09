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

    private Board _board;

    public void StartGame()
    {
        Init();
        _board = _levelHelper?.LoadLevel();
        _matchHelper?.SetBoard(_board);
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

    


}
