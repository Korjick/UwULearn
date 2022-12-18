using System;
using UnityEngine;

public class CatLike : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    
    private void Update()
    {
        transform.LookAt(_camera.transform);
    }
}