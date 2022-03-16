using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInteraction : MonoBehaviour
{
    public Camera camera;
    RaycastHit hit;
    Ray ray;
    Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f); // center of the screen
    float rayLength = 500f;

    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            ray = Camera.main.ViewportPointToRay(rayOrigin);
            Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);
            GetInteraction();
        }
    }
    void GetInteraction()
    {

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Debug.Log("çalýþtý mý lan");
            GameObject interactedObject = hit.collider.gameObject;
            if (interactedObject.tag == "Interactable Object")
            {
                interactedObject.GetComponent<Interactable>().Interract();
            }
        }
    }
}
