using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class VRRaycaster : MonoBehaviour
{
    public float maxRaycastDistance = 100f;
    public LayerMask ignoreLayers;

    private PointerEventData pointerEventData;
    private EventSystem eventSystem;

    void Start()
    {
        eventSystem = EventSystem.current;
        pointerEventData = new PointerEventData(eventSystem);
    }

    void Update()
    {
        RaycastHit raycastHit;
        if (Physics.Raycast(transform.position, transform.forward, out raycastHit, maxRaycastDistance, ~ignoreLayers))
        {
            pointerEventData.position = raycastHit.point;

            List<RaycastResult> results = new List<RaycastResult>();
            eventSystem.RaycastAll(pointerEventData, results);

            if (results.Count > 0)
            {
                RaycastHitToRaycastResultAdapter adapter = new RaycastHitToRaycastResultAdapter();
                adapter.SetTarget(raycastHit.collider.gameObject, raycastHit);
                results.Add(adapter.GetRaycastResult());
                pointerEventData.pointerCurrentRaycast = results[0];

                if (Input.GetButtonDown("Fire1"))
                {
                    results[0].gameObject.SendMessage("OnButtonClick", SendMessageOptions.RequireReceiver);
                }
            }
        }
    }
}

public class RaycastHitToRaycastResultAdapter
{
    private GameObject targetObject;
    private RaycastHit raycastHit;

    public void SetTarget(GameObject targetObject, RaycastHit raycastHit)
    {
        this.targetObject = targetObject;
        this.raycastHit = raycastHit;
    }

    public RaycastResult GetRaycastResult()
    {
        if (targetObject != null)
        {
            RaycastResult raycastResult = new RaycastResult();
            raycastResult.gameObject = targetObject;
            raycastResult.module = null;
            raycastResult.distance = raycastHit.distance;
            raycastResult.index = 0;
            raycastResult.depth = 1;
            raycastResult.sortingLayer = 0;
            raycastResult.sortingOrder = 0;
            raycastResult.worldPosition = raycastHit.point;
            raycastResult.worldNormal = raycastHit.normal;
            return raycastResult;
        }
        return new RaycastResult();
    }
}
