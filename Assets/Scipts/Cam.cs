using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    Vector3 touchStart;
    public float zoomOutMin = 13;
    public float zoomOutMax = 60;
    
    public Vector3 minPos;
    public Vector3 maxPos;

    // Update is called once per frame
    void Update()
    {
   
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.touchCount == 2)
        {
            //zoom
            Touch firTouch = Input.GetTouch(0);
            Touch secondTouch = Input.GetTouch(1);

            Vector2 firTouchPrevPos = firTouch.position - firTouch.deltaPosition;
            Vector2 secondTuochPrevPos = secondTouch.position - secondTouch.deltaPosition;

            float prevDis = (firTouchPrevPos - secondTuochPrevPos).magnitude;
            float currentDis = (firTouch.position - secondTouch.position).magnitude;

            float difference = currentDis - prevDis;

            zoom(difference * 0.03f);
            transform.position = Camera.main.transform.position;
        }
        else if (Input.GetMouseButton(0))
        {
            //move
            Vector3 dir = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.transform.position += dir;
            Vector3 viewPos = Camera.main.transform.position;
            viewPos.x = Mathf.Clamp(viewPos.x, minPos.x, maxPos.x);
            viewPos.z = Mathf.Clamp(viewPos.z, minPos.z, maxPos.z);
            viewPos.y = Mathf.Clamp(viewPos.y, minPos.y, maxPos.y);
            Camera.main.transform.position = viewPos;
        }
        zoom(Input.GetAxis("Mouse ScrollWheel"));
    }

    void zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }
}