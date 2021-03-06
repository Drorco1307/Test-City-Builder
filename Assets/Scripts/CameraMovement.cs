﻿using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3? _basePointerPosition = null;
    private int _cameraXMin, _cameraXMax, _cameraZMin, _cameraZMax;

    public float CameraMovementSpeed = .05f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveCamera(Vector3 pointerPosition)
    {
        if (!_basePointerPosition.HasValue)
            _basePointerPosition = pointerPosition;

        Vector3 newPosition = pointerPosition - _basePointerPosition.Value;
        newPosition = new Vector3(newPosition.x, 0, newPosition.y);
        transform.Translate(newPosition * CameraMovementSpeed);
        SetCameraBounds();

    }

    private void SetCameraBounds()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, _cameraXMin, _cameraXMax),
            0,
            Mathf.Clamp(transform.position.z, _cameraZMin, _cameraZMax));
    }

    public void StopCameraMovement()
    {
        _basePointerPosition = null;
    }

    public void InitCameraBound(int cameraXMin, int cameraXMax, int cameraZMin, int cameraZMax)
    {
        _cameraXMin = cameraXMin;
        _cameraXMax = cameraXMax;
        _cameraZMin = cameraZMin;
        _cameraZMax = cameraZMax;
    }

}
