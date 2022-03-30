using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInteraction : MonoBehaviour
{
    public Camera camera;
    RaycastHit hit;
    Ray ray;
    Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f); // center of the screen

    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            ray = Camera.main.ViewportPointToRay(rayOrigin);
            GetInteraction();
        }
    }
    void GetInteraction()
    {

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            GameObject interactedObject = hit.collider.gameObject;
            if (interactedObject.tag == "Interactable Object")
            {
                interactedObject.GetComponent<Interactable>().Interract();
            }
        }
    }
}
