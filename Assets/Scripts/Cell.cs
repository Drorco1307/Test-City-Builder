using UnityEngine;

public class Cell
{
    private GameObject _structureModel = null;
    private bool _isTaken = false;

    public bool IsTaken => _isTaken;

    public void SetConstruction(GameObject structureModel)
    {
        _structureModel = structureModel;
        _isTaken = true;
    }
}
