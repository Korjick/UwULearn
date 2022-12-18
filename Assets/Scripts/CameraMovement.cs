using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _target;
    [SerializeField] private float _zoomMin;
    [SerializeField] private float _zoomMax;

    private Vector3 _prevPosition;

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _prevPosition = _camera.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 direction = _prevPosition - _camera.ScreenToViewportPoint(Input.mousePosition);

            _camera.transform.position = _target.position;
            
            _camera.transform.Rotate(Vector3.right, direction.y * 100);
            _camera.transform.Rotate(Vector3.up, -direction.x * 100, Space.World);
            _camera.transform.Translate(Vector3.back * 15);

            _prevPosition = _camera.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroLastPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOneLastPos = touchOne.position - touchOne.deltaPosition;

            float distTouch = (touchZeroLastPos - touchOneLastPos).magnitude;
            float currentDistTouch = (touchZero.position - touchOne.position).magnitude;

            float difference = currentDistTouch - distTouch;

            Zoom(difference * 0.01f);
        }
        
        Zoom(Input.GetAxis("Mouse ScrollWheel") * 10);
    }

    private void Zoom(float increment) 
        => _camera.fieldOfView = Mathf.Clamp(_camera.fieldOfView - increment, _zoomMin, _zoomMax);
}
