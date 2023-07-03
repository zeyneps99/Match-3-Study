using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class GameManager : Singleton<GameManager>
{
    #region PATHS
    private string _levelDataPath = "LevelData";
    private string _prefabPath = "Prefabs/";
    private string _boardPath = "Board";
    #endregion

    private Canvas _canvas;


    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        Init();
    }


    private void Init()
    {
        _canvas = FindObjectOfType<Canvas>();
        var level = LoadLevelData();
        LoadGame(level, _canvas);
    }



    private void LoadGame(Level level, Canvas canvas)
    {
        var board = Resources.Load<GameObject>(_prefabPath + _boardPath);
        if (board != null && canvas != null)
        {
            //if (_currentBoard != null)
            //{
            //    Destroy(_currentBoard);
            //}
            var newBoard = Instantiate(board, canvas.transform);
            newBoard.GetComponent<Board>()?.Init(level);
            //_currentBoard = board.GetComponent<Board>();
            //_currentBoard.Init(level);
        }
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
