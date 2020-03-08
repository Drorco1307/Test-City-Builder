using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputManager
{
    void AddListenerOnPointerDownEvent(Action<Vector3> listener);
    void RemoveListenerOnPointerDownEvent(Action<Vector3> listener);
}
