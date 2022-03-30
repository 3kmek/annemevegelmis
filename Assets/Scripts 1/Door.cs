using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float ySensitivity = 300f;
    public float frontOpenPosLimit = 45;
    public float backOpenPosLimit = 45;

    public GameObject frontDoorCollider;
    public GameObject backDoorCollider;

    bool moveDoor = false;
    DoorCollision doorCollision = DoorCollision.NONE;

    RaycastHit hit;
    Ray ray;
    Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f); // center of the screen


    // Use this for initialization
    void Start()
    {
        StartCoroutine(doorMover());
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            ray = Camera.main.ViewportPointToRay(rayOrigin);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                GameObject interactedObject = hit.collider.gameObject;
                if (interactedObject == frontDoorCollider)
                {
                    moveDoor = true;
                    doorCollision = DoorCollision.FRONT;
                }
                else if (interactedObject == backDoorCollider)
                {
                    moveDoor = true;
                    doorCollision = DoorCollision.BACK;
                }
                else
                {
                    doorCollision = DoorCollision.NONE;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            moveDoor = false;
        }
    }

    IEnumerator doorMover()
    {
        bool stoppedBefore = false;
        float yRot = 0;

        while (true)
        {
            if (moveDoor)
            {
                stoppedBefore = false;

                yRot += Input.GetAxis("Mouse Y") * ySensitivity * Time.deltaTime;


                //Check if this is front door or back
                if (doorCollision == DoorCollision.FRONT)
                {
                    yRot = Mathf.Clamp(yRot, -frontOpenPosLimit, 0);
                    transform.localEulerAngles = new Vector3(0, -yRot, 0);
                }
                else if (doorCollision == DoorCollision.BACK)
                {
                    yRot = Mathf.Clamp(yRot, 0, backOpenPosLimit);
                    transform.localEulerAngles = new Vector3(0, yRot, 0);
                }
            }
            else
            {
                if (!stoppedBefore)
                {
                    stoppedBefore = true;
                }
            }

            yield return null;
        }

    }


    enum DoorCollision
    {
        NONE, FRONT, BACK
    }
}
