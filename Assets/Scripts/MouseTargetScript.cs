using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTargetScript : MonoBehaviour
{
    private Camera _camera;
    private Vector3 _cameraPosition;
    
    private GameObject _currentSelectedObject;
    private GameObject _currentDragObject;

    private bool _isMouseDown;
    [SerializeField] private GameObject _mouseHolder;
    private void Start()
    {
        _camera = Camera.main;
        if (_camera is not null) _cameraPosition = _camera.transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isMouseDown = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            _isMouseDown = false;
            if (_currentDragObject)
            {
                _currentSelectedObject = null;
                _currentDragObject.GetComponent<BoxCollider2D>().enabled = true;
                _currentDragObject.transform.SetParent(null);
                _currentDragObject = null;
            }
        }

        if (!_currentDragObject)
        {
            MouseHitObject();
        }
        DragObject();

    }
    

    private void MouseHitObject()
    {
        Vector3 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        Collider2D hit;
        hit = Physics2D.OverlapPoint(mousePosition, 1 << 7);
        if (hit != null)
        {
            _currentSelectedObject = hit.gameObject;
        }
        else
        {
            _currentSelectedObject = null;
        }
    }

    private void DragObject()
    {
        if (_isMouseDown && !_currentDragObject && _currentSelectedObject)
        {
            _currentDragObject = _currentSelectedObject;
            _currentDragObject.transform.SetParent(_mouseHolder.transform);
            _currentDragObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
