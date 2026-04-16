using UnityEngine;
using UnityEngine.InputSystem;

public class RTSCamera : MonoBehaviour
{
    public InputAction moveAction;
    public InputAction zoomAction;

    public float speed = 20f;
    public float zoomSpeed = 200f;
    public float minY = 10f;
    public float maxY = 50f;

    void OnEnable()
    {
        moveAction.Enable();
        zoomAction.Enable();
    }

    void OnDisable()
    {
        moveAction.Disable();
        zoomAction.Disable();
    }

    void Update()
    {
        Vector3 pos = transform.position;

        // Movimiento WASD
        Vector2 move = moveAction.ReadValue<Vector2>();
        pos += new Vector3(move.x, 0, move.y) * speed * Time.deltaTime;

        // Zoom con scroll
        Vector2 scroll = zoomAction.ReadValue<Vector2>();
        float zoom = scroll.y;

        pos.y -= zoom * zoomSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }
}