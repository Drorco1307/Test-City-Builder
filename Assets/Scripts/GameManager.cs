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
    public CameraMovement CameraMovement;

    // Start is called before the first frame update
    void Start()
    {
        CameraMovement.InitCameraBound(0, Width, 0, Length);
        _grid = new GridStructure(_cellSize, Width, Length);
        InputManager = FindObjectsOfType<MonoBehaviour>().OfType<IInputManager>().FirstOrDefault();   
        InputManager.AddListenerOnPointerDownEvent(HandlePoint);
        InputManager.AddOnPointerSecondDownEvent(HandleInputCameraPan);
        InputManager.AddOnPointerSecondUpEvent(HandleInputCameraPanStop);
        UIController.AddOnBuildAreaEvent(StartPlacementMode);
        UIController.AddOnCancelActionEvent(CancelAction);
    }

    private void HandleInputCameraPanStop()
    {
        CameraMovement.StopCameraMovement();
    }

    private void HandleInputCameraPan(Vector3 position)
    {
        if (!BuildingModeActive)
        {
            CameraMovement.MoveCamera(position);
        }
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
