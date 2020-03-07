using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    public LayerMask MouseInputMask;

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    public void GetInput()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit hit, Mathf.Infinity, MouseInputMask))
            {
                Vector3 position = hit.point - transform.position;

            }
        }
    }

    //private void CreateBuilding(Vector3 gridPosition)
    //{
    //    Instantiate(BuildingPrefab, gridPosition, Quaternion.identity);
    //}
}
