using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camcontrol : MonoBehaviour
{
    public Camera camera;
    protected Plane plane;
    [Header("Setting Position")]
    public float zoomOutMin = 13;
    public float zoomOutMax = 60;
    public Vector3 minPos;
    public Vector3 maxPos;
    [Header("")]
    public float speed = 40f;

    // Update is called once per frame
    private void Awake()
    {
        if (camera == null)
        {
            camera = Camera.main;
        }
    }
    void Update()
    {
        float camMove = speed * Time.deltaTime;
        //Update Plane

        var Delta1 = Vector3.zero;
        var Delta2 = Vector3.zero;
        if (Input.touchCount >= 1)
            plane.SetNormalAndPosition(transform.up, transform.position);
        if (Input.touchCount >= 1)
        {
            Delta1 = planePositionDistance(Input.GetTouch(0));
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                //camera.transform.Translate(Delta1 * camMove, Space.World);
                camera.transform.position += Delta1;
                Vector3 viewPos = camera.transform.position;
                viewPos.x = Mathf.Clamp(viewPos.x, minPos.x, maxPos.x);
                viewPos.z = Mathf.Clamp(viewPos.z, minPos.z, maxPos.z);
                viewPos.y = Mathf.Clamp(viewPos.y, minPos.y, maxPos.y);
                camera.transform.position = viewPos;
            }
 
        }
        if (Input.touchCount == 2)
        {
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
        zoom(Input.GetAxis("Mouse ScrollWheel"));
    }
    protected Vector3 planePositionDistance(Touch touch)
    {
        if (touch.phase != TouchPhase.Moved)
            return Vector3.zero;
        // cal Distance
        var rayBefore = camera.ScreenPointToRay(touch.position - touch.deltaPosition);
        var rayNow = camera.ScreenPointToRay(touch.position);
        if (plane.Raycast(rayBefore, out var enterBefore) && plane.Raycast(rayNow, out var enterNow))
            return rayBefore.GetPoint(enterBefore) - rayNow.GetPoint(enterNow);

        return Vector3.zero;

    }
    void zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }
}