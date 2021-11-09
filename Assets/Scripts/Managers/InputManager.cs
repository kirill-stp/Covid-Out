using UnityEngine;

public class InputManager : SingletonMonoBehaviour<InputManager>
{
    public static Vector3 TouchCoords { get; private set; }
    public static float XTouchScreeenCoord { get; private set; }

    private Vector3 ProjectOnPlane(Vector3 screenPosition)
    {
        var planePosition = new Vector3();
        
        Plane plane = new Plane(Vector3.up, 0);
        float distance;
        Vector3 offsetPosition = new Vector3(screenPosition.x, screenPosition.y, 1f);
        Ray ray = Camera.main.ScreenPointToRay(offsetPosition);
        if (plane.Raycast(ray, out distance))
        {
            planePosition = ray.GetPoint(distance);
        }

        return planePosition;
    }

    private void Start()
    {
        TouchCoords = new Vector2();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            TouchCoords = ProjectOnPlane(touch.position);
            XTouchScreeenCoord = touch.position.x - Screen.width / 2;
        } else if (Input.GetMouseButton(0))
        {
            TouchCoords = ProjectOnPlane(Input.mousePosition);
            XTouchScreeenCoord = Input.mousePosition.x - Screen.width / 2;
        }
        else
        {
            TouchCoords = Camera.main.transform.position;
            XTouchScreeenCoord = 0;
        }
        
    }
}
