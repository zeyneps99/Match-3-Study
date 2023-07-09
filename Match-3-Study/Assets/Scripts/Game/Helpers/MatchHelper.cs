using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchHelper : MonoBehaviour
{
    private List<Cube> _matchList;
    private bool[,] _visited;
    private Board _board;
    public void Init()
    {
    }
    public void SetBoard(Board board)
    {
        _board = board;
    }
    public void CheckForMatches(Cube cube)
    {
        _visited = new bool[_board.Width, _board.Height];
        _matchList = new List<Cube>();
        DFS(cube.Position.x, cube.Position.y, (int) cube.Type);
        if (_matchList.Count >= 2)
        {
            PerformMatch();
        }

    }
    private void DFS(int row, int column, int cubeType)
    {
        if (row < 0 || row >= _board.Width|| column < 0 || column >= _board.Height)
        {
            return;
        }

        if (_visited[row, column] || (_board.Cubes[row, column] != null && _board.Cubes[row, column].Type != (CubeTypes)cubeType))
        {
            return;
        }

        _visited[row, column] = true;
        _matchList.Add(_board.Cubes[row, column]);

        DFS(row - 1, column, cubeType);
        DFS(row + 1, column, cubeType);
        DFS(row, column - 1, cubeType);
        DFS(row, column + 1, cubeType);

    }

    private void PerformMatch()
    {
        GameManager.Instance?.DeactivateBoard();
        _board.HandleMatch(_matchList);
        Events.GameEvents.OnMatchFound?.Invoke();
        //  _board.HandleMatch(_matchList);

    }
}

    
