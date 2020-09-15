using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;

    [SerializeField]
    private Transform menuAdvices;

    private MouseLook ml;
    private bool interacting = false;
    RaycastHit hit;
    Camera cam;
    int layerMask;
    public float rayLenght = 100f;
    GameObject gm;
    IInteractable iI;
    // Start is called before the first frame update
    void Start()
    {
        ml = GetComponent<MouseLook>();
        cam = GetComponentInChildren<Camera>();
        layerMask = 1 << LayerMask.NameToLayer("Interactable");
    }
    void ChangeMenu()
    {
        menu.SetActive(!menu.activeSelf);
        if (menu.activeSelf)
        {
            ml.enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            ml.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    // Update is called once per frame
    void Update()
    {
          if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangeMenu();
        }
        if (!interacting)
        {
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, rayLenght, layerMask))
            {
                
                iI = hit.collider.gameObject.GetComponent<IInteractable>();
                menuAdvices.GetChild(iI.InInteract()).gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.F))
                {
                    interacting = iI.Interact();
                    menuAdvices.GetChild(iI.InInteract()).gameObject.SetActive(!interacting);
                }
            }
            else
            {
                if (iI != null)
                {
                    menuAdvices.GetChild(iI.InInteract()).gameObject.SetActive(false);
                }
            }
        }
        else
        {
            if (iI != null)
            {
                menuAdvices.GetChild(iI.InInteract()).gameObject.SetActive(false);
            }
            
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("Pressed");
                if (iI != null)
                {
                    
                    iI.OutInteract();
                    interacting = false;
                }
            }
        }
    }
}
