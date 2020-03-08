using System;
using UnityEngine;

public interface IInputManager
{
    void AddListenerOnPointerDownEvent(Action<Vector3> listener);
    void RemoveListenerOnPointerDownEvent(Action<Vector3> listener);
    void AddOnPointerSecondDownEvent(Action<Vector3> listener);
    void RemoveOnPointerSecondDownEvent(Action<Vector3> listener);
    void AddOnPointerSecondUpEvent(Action listener);
    void RemoveOnPointerSecondUpEvent(Action listener);
}
