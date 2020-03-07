using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GridStructure _grid;
    private int _cellSize = 3;

    public int Width, Length;
    public PlacementManager PlacementManager;
    public InputManager InputManager;

    // Start is called before the first frame update
    void Start()
    {
        _grid = new GridStructure(_cellSize, Width, Length);
        InputManager.OnPointerDownHandler += HandlePoint;
    }

    private void HandlePoint(Vector3 position)
    {
        Vector3 gridPosition = _grid.CalculateGridPosition(position);
        if (!_grid.IsCellTaken(gridPosition).isTaken)
        {
            PlacementManager.CreateBuilding(gridPosition, _grid);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
