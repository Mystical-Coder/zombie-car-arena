using UnityEngine;

public class SwipeInput : MonoBehaviour
{
    public static float swipeX;

    Vector2 startPos;
    bool touching;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            touching = true;
        }

        if (Input.GetMouseButton(0) && touching)
        {
            Vector2 current = Input.mousePosition;
            swipeX = (current.x - startPos.x) / Screen.width;
        }

        if (Input.GetMouseButtonUp(0))
        {
            swipeX = 0;
            touching = false;
        }
    }
}