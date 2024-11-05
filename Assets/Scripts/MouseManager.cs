using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseManager : MonoBehaviour
{
    [Header("Texture Pointer")]
    public Texture2D insideCircleTexture;
    public Texture2D outsideCircleTexture;
    public Texture2D defaultTexture;

    [Header("Boolean")]
    public bool asClicked = false;

    [Header("Parameters Radius Area")]
    public float min;
    public float max;

    private Vector2 mousePosition;
    public Vector2 mousePositionWorld;
    private GameObject objectToResize;
    private RaycastHit2D raycastHit;
    private GameObject memoryObject;

    void Update()
    {
        Pointer(mousePosition);
        if (asClicked && memoryObject != null)
        {
            if (memoryObject.CompareTag("OutsideCircle"))
            {
                print("Je detecte forceArea");
                CircleShape circleShape = memoryObject.GetComponent<CircleShape>();
                circleShape.Radius = Mathf.Clamp(Vector2.Distance(memoryObject.transform.position, mousePositionWorld), min, max);

                //Debug.Log(circleShape.Radius);
                AreaEffector2D areaEffector2D = memoryObject.GetComponent<AreaEffector2D>();
                areaEffector2D.forceMagnitude = circleShape.Radius * 10;
            }
            else if(memoryObject.CompareTag("InsideCircle"))
            {
                print("Je detecte ARROW");
                memoryObject.transform.parent.position = mousePositionWorld;
            }
        }
    }

    public void LookMouse(InputAction.CallbackContext context)
    {

        switch(context.phase)
        {
            case InputActionPhase.Disabled:
                break;
            case InputActionPhase.Waiting:
                break;
            case InputActionPhase.Started:
                break;
            case InputActionPhase.Performed:
                    mousePosition = context.ReadValue<Vector2>();
                    mousePositionWorld = Camera.main.ScreenToWorldPoint(mousePosition);

                break;
            case InputActionPhase.Canceled:

                break;
            default:
                break;
        }
    }

    public Transform Pointer(Vector2 mousePos)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);

        if (hit.collider == null)
        {
            Debug.Log("No Circle");
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            objectToResize = null;
            return null;
        }
        else
        {
            if (hit.collider.CompareTag("InsideCircle"))
            {
                Debug.Log("Inside Circle");
                Cursor.SetCursor(insideCircleTexture, new Vector2(insideCircleTexture.width/2, insideCircleTexture.height/2), CursorMode.Auto);
                objectToResize = hit.collider.gameObject;
                return hit.collider.transform;
            }
            else if (hit.collider.CompareTag("OutsideCircle"))
            {
                Debug.Log("Outside Circle");
                Cursor.SetCursor(outsideCircleTexture, new Vector2(outsideCircleTexture.width / 2, outsideCircleTexture.height / 2), CursorMode.Auto);
                objectToResize = hit.collider.gameObject;
                return hit.collider.transform;
            }
            return null;
        }
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Disabled:
                break;
            case InputActionPhase.Waiting:
                break;
            case InputActionPhase.Started:
                break;
            case InputActionPhase.Performed:

                asClicked = true;
                Ray ray = Camera.main.ScreenPointToRay(mousePosition);
                raycastHit = Physics2D.GetRayIntersection(ray);
                if(raycastHit.collider != null)
                {
                    memoryObject = raycastHit.collider.gameObject;
                }
                break;
            case InputActionPhase.Canceled:

                asClicked = false;
                memoryObject = null;
                break;
            default:
                break;
        }
    }
}
