using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : Singleton<GameLogic>
{
    #region PATHS
    private string _levelDataPath = "LevelData";
    private string _prefabPath = "Prefabs/";
    private string _boardPath = "Board";
    #endregion

    private Canvas _canvas;

    public void StartGame()
    {
        _canvas = FindObjectOfType<Canvas>();
        var level = LoadLevelData();
        LoadLevel(level, _canvas);
    }

    public void LoadLevel(Level level, Canvas canvas)
    {
        var board = Resources.Load<GameObject>(_prefabPath + _boardPath);
        if (board != null && canvas != null)
        {
            var newBoard = Instantiate(board, canvas.transform);
            newBoard.GetComponent<Board>()?.Set(level);
           // Events.CoreEvents.OnLevelLoaded?.Invoke(level);
        }
    }

    public Level LoadLevelData()
    {
        var levelData = Resources.Load<TextAsset>(_levelDataPath);
        if (levelData == null)
        {
            return new Level();
        }
        return JsonConvert.DeserializeObject<Level>(levelData.text);

    }


}
