using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    public Action<Vector3> OnPointerDownHandler { get; set; }

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
                OnPointerDownHandler?.Invoke(position);
            }
        }
    }

    //public void AddListenerOnPointerDownEvent(Action<Vector3> listener)
    //{
    //    OnPointerDownHandler += listener;

    //}

    //public void RemoveListenerOnPointerDownEvent(Action<Vector3> listener)
    //{
    //    OnPointerDownHandler -= listener;

    //}
}
