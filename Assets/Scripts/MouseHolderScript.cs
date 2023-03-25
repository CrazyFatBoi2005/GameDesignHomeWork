using UnityEngine;

public class MouseHolderScript : MonoBehaviour
{

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }
    
    private void Update()
    {
        var _position = _camera.ScreenToWorldPoint(Input.mousePosition);
        gameObject.transform.position = new Vector3(_position.x, _position.y, 0f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(gameObject.transform.position, 0.1f);
    }
}
