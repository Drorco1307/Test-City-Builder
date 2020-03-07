using System;
using UnityEngine;

public class GridStructure
{
    private int _cellSize;
    private Cell[,] _grid;
    private int _width, _length;

    public GridStructure(int cellSize, int width, int length)
    {
        _cellSize = cellSize;
        _width = width;
        _length = length;
        _grid = new Cell[width, length];
        for (int row = 0; row < _grid.GetLength(0); row++)
        {
            for (int col = 0; col < _grid.GetLength(1); col++)
            {
                _grid[row, col] = new Cell();
            }
        }
    }

    public Vector3 CalculateGridPosition(Vector3 inputPosition)
    {
        int x = Mathf.FloorToInt(inputPosition.x / _cellSize);
        int z = Mathf.FloorToInt(inputPosition.z / _cellSize);
        return new Vector3(x * _cellSize, 0, z * _cellSize);
    }

    private Vector2Int CalculateGridIndex(Vector3 gridPosition)
    {
        return new Vector2Int((int)(gridPosition.x / _cellSize), (int)(gridPosition.z / _cellSize));
    }

    public (bool isTaken, Vector2Int cellIndx) IsCellTaken(Vector3 gridPosition)
    {
        Vector2Int cellIndex = CalculateGridIndex(gridPosition);

        if (cellIndex.x >= 0 && cellIndex.x <= _grid.GetLength((1)) &&
            cellIndex.y >= 0 && cellIndex.y <= _grid.GetLength((0)))
        {
            return (_grid[cellIndex.y, cellIndex.x].IsTaken, cellIndex);
        }

        throw new IndexOutOfRangeException("No index:" + cellIndex + "in grid");
    }

    public void PlaceStructureOnGrid(GameObject structure, Vector3 gridPosition)
    {
        var res = IsCellTaken(gridPosition);
        _grid[res.cellIndx.y, res.cellIndx.x].SetConstruction(structure);
    }

    [Obsolete("Replaced with Tuple as return value of method 'IsCellTaken'")]
    private bool CheckCellValidity(Vector2Int cellIndex)
    {
        return (cellIndex.x >= 0 && cellIndex.x <= _grid.GetLength((1)) &&
                cellIndex.y >= 0 && cellIndex.y <= _grid.GetLength((0)));

    }
}
