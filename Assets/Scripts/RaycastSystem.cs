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

    // Update is called once per frame
    void Update()
    {
          if (Input.GetKeyDown(KeyCode.Escape))
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
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, rayLenght, layerMask))
        {
            //Debug.Log(hit.collider.gameObject.name);
            iI = hit.collider.gameObject.GetComponent<IInteractable>();
            menuAdvices.GetChild(iI.InInteract()).gameObject.SetActive(true);
            //iI.InInteract();
            if (Input.GetKeyDown(KeyCode.E)||Input.GetKeyDown(KeyCode.F))
            {
                iI.Interact();
            }
        }
        else
            if (iI!=null)
        {
            menuAdvices.GetChild(iI.InInteract()).gameObject.SetActive(false);
        }
    }
}
