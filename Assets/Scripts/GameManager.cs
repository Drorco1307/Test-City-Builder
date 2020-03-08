using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GridStructure _grid;
    private int _cellSize = 3;
    private bool BuildingModeActive = false;

    public int Width, Length;
    public PlacementManager PlacementManager;
    public IInputManager InputManager;
    public UIController UIController;

    // Start is called before the first frame update
    void Start()
    {
        _grid = new GridStructure(_cellSize, Width, Length);
        InputManager = FindObjectsOfType<MonoBehaviour>().OfType<IInputManager>().FirstOrDefault();   
        InputManager.AddListenerOnPointerDownEvent(HandlePoint);
        UIController.AddOnBuildAreaEvent(StartPlacementMode);
        UIController.AddOnCancelActionEvent(CancelAction);
    }

    private void HandlePoint(Vector3 position)
    {
        Vector3 gridPosition = _grid.CalculateGridPosition(position);
        if (BuildingModeActive && !_grid.IsCellTaken(gridPosition).isTaken)
        {
            PlacementManager.CreateBuilding(gridPosition, _grid);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void StartPlacementMode()
    {
        BuildingModeActive = true;
    }

    private void CancelAction()
    {
        BuildingModeActive = false;
    }
}
