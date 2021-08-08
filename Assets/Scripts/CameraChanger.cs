using System;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
public class CameraChanger : MonoBehaviour
{
    [SerializeField] private List<CinemachineVirtualCamera> _virtualCameras;
    private Camera _camera;
    private CinemachineVirtualCamera _currentCamera=>_virtualCameras[_index];
    private int _index;
    private void Start()
    {
        _camera=Camera.main;
    }
    public void ChangeCamera()
    {
        if (_camera.orthographic) _camera.orthographic = false;
        _currentCamera.Priority = 0;
        _index++;
        if (_index >= _virtualCameras.Count) _index = 0;
        _currentCamera.Priority = 10;
    }
}
