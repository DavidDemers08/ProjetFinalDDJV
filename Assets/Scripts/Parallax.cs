using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Source: https://www.youtube.com/watch?v=EGRDQY6dpdU (cliquer sur le lien Dropbox dans la descripton)
public class Parallax : MonoBehaviour
{
    [SerializeField] [Range(0f, 1f)] float _lagAmount = 0f;

    Vector3 _previousCameraPosition;
    Transform _camera;
    Vector3 _targetPosition;

    private float ParallaxAmount => 1f - _lagAmount;

    private void Awake()
    {
        _camera = Camera.main.transform;
        _previousCameraPosition = _camera.position;
    }

    private void LateUpdate()
    {
        Vector3 movement = CameraMovement;
        if (movement == Vector3.zero) return;
        _targetPosition = new Vector3(transform.position.x + movement.x * ParallaxAmount, transform.position.y, transform.position.z);
        transform.position = _targetPosition;
    }

    Vector3 CameraMovement
    {
        get
        {
            Vector3 movement = _camera.position - _previousCameraPosition;
            _previousCameraPosition = _camera.position;
            return movement;
        }
    }
}
