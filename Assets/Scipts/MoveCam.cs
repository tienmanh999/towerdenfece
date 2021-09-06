using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    public Camera camera;
    protected Plane plane;
    public bool Rotate;
    public float speed = 10f;

    private void Awake()
    {
        if (camera == null)
        {
            camera = Camera.main;
        }
    }


    // Update is called once per frame
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
                camera.transform.Translate(Delta1 * camMove, Space.World);
        }
        if (Input.touchCount >= 2)
        {
            var pos1 = planePos(Input.GetTouch(0).position);
            var pos2 = planePos(Input.GetTouch(1).position);
            var pos1b = planePos(Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition);
            var pos2b = planePos(Input.GetTouch(1).position - Input.GetTouch(1).deltaPosition);

            //calc zoom
            var zoom = Vector3.Distance(pos1, pos2) / Vector3.Distance(pos1b, pos2b);
            camera.transform.position = Vector3.LerpUnclamped(pos1, camera.transform.position, 1 / zoom);

        }
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
    protected Vector3 planePos(Vector2 screenPos)
    {
        //pos
        var rayNow = camera.ScreenPointToRay(screenPos);
        if (plane.Raycast(rayNow, out var enterNow))
            return rayNow.GetPoint(enterNow);

        return Vector3.zero;
    }
}
    
