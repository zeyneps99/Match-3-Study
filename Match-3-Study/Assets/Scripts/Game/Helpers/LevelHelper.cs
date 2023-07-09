using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;


public class LevelHelper : MonoBehaviour
{
    #region PATHS
    private string _levelDataPath = "LevelData";
    private string _prefabPath = "Prefabs/";
    private string _boardPath = "Board";
    #endregion

    private Canvas _canvas;

    public void Init()
    {
        _canvas = FindObjectOfType<Canvas>();
    }
    public Board LoadLevel()
    {
        Level level = LoadLevelData();
        var board = Resources.Load<GameObject>(_prefabPath + _boardPath);
        if (board != null && _canvas != null)
        {
            var newBoard = Instantiate(board, _canvas.transform);
            newBoard.TryGetComponent(out Board _board);
            _board?.Set(level);
            return _board;
            // Events.CoreEvents.OnLevelLoaded?.Invoke(level);
        }
        return null;
    }

    private Level LoadLevelData()
    {
        var levelData = Resources.Load<TextAsset>(_levelDataPath);
        if (levelData == null)
        {
            return new Level();
        }
        return JsonConvert.DeserializeObject<Level>(levelData.text);
    }

}
