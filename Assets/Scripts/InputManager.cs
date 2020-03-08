using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour, IInputManager
{
    private Action<Vector3> OnPointerDownHandler;
    private Action<Vector3> OnPointerSecondDownHandler;
    private Action OnPointerSecondUpHandler;

    public LayerMask MouseInputMask;

    // Update is called once per frame
    void Update()
    {
        GetPointerPosition();
        GetPanningPointer();
    }

    private void GetPointerPosition()
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

    private void GetPanningPointer()
    {
        if (Input.GetMouseButton(1))
        {
            var position = Input.mousePosition;
            OnPointerSecondDownHandler?.Invoke(position);
        }

        if (Input.GetMouseButtonUp(1))
        {
            OnPointerSecondUpHandler?.Invoke();
        }
    }

    public void AddListenerOnPointerDownEvent(Action<Vector3> listener)
    {
        OnPointerDownHandler += listener;
    }

    public void RemoveListenerOnPointerDownEvent(Action<Vector3> listener)
    {
        OnPointerDownHandler -= listener;
    }

    public void AddOnPointerSecondDownEvent(Action<Vector3> listener)
    {
        OnPointerSecondDownHandler += listener;
    }

    public void RemoveOnPointerSecondDownEvent(Action<Vector3> listener)
    {
        OnPointerSecondDownHandler -= listener;
    }

    public void AddOnPointerSecondUpEvent(Action listener)
    {
        OnPointerSecondUpHandler += listener;
    }

    public void RemoveOnPointerSecondUpEvent(Action listener)
    {
        OnPointerSecondUpHandler -= listener;
    }
}
