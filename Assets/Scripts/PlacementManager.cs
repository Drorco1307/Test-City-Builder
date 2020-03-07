using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    public GameObject BuildingPrefab;
    public Transform Ground;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateBuilding(Vector3 gridPosition, GridStructure grid)
    {
        var newStructure = Instantiate(BuildingPrefab, Ground.position + gridPosition, Quaternion.identity);
        grid.PlaceStructureOnGrid(newStructure, gridPosition);
    }
}
