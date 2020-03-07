using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GridStructure _grid;
    private int _cellSize = 3;

    public PlacementManager PlacementManager;
    public InputManager InputManager;

    // Start is called before the first frame update
    void Start()
    {
        _grid = new GridStructure(_cellSize);
        InputManager.OnPointerDownHandler += HandlePoint;
    }

    private void HandlePoint(Vector3 position)
    {
        PlacementManager.CreateBuilding(_grid.CalculateGridPosition(position));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
