using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseManager : MonoBehaviour
{
    public EventEnviroment OnClickEnviroment;

    public LayerMask layerMask;

    public Texture2D target;
    public Texture2D arrow;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);

        if (Physics.Raycast(ray, out hit, 100, layerMask))
        {
            Cursor.SetCursor(target, new Vector2(16, 16), CursorMode.Auto);

            if (Input.GetMouseButtonDown(0))
            {
                EventEnviromentArgs args = new EventEnviromentArgs();
                args.destination = hit.point;

                OnClickEnviroment.Invoke(args);
            }
        }
        else
        {
            Cursor.SetCursor(arrow, new Vector2(0, 0), CursorMode.Auto);
        }
    }
}


[System.Serializable]
public class EventEnviroment : UnityEvent<EventEnviromentArgs>
{


}
public class EventEnviromentArgs
{
    public Vector3 destination;
}


