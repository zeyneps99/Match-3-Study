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
    private Level _currentLevel;
    private Board _board;
    private void OnEnable()
    {
        Events.GameEvents.OnMatchFound += HandleMatch;
    }

    private void OnDisable()
    {
        Events.GameEvents.OnMatchFound -= HandleMatch;
    }
    public void Init()
    {
        _canvas = FindObjectOfType<Canvas>();
    }
    public Board GenerateBoardForLevel()
    {
        _currentLevel = LoadLevelData();
        var board = Resources.Load<GameObject>(_prefabPath + _boardPath);
        if (board != null && _canvas != null)
        {
            var newBoard = Instantiate(board, _canvas.transform);
            newBoard.TryGetComponent(out _board);
            _board?.Set(_currentLevel);
            Events.GameEvents.OnBoardGenerated?.Invoke();
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

    private void HandleMatch()
    {
        UpdateMoveCount(false);
    }

    private void UpdateMoveCount(bool isIncrease)
    {
        _currentLevel.MoveCount += isIncrease ? 1 : -1;
    }

    public void EnableBoard(bool isEnable)
    {
        _board.Enable(isEnable);
    }
}
