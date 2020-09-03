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
    
    RaycastHit hit;
    Camera cam;
    int layerMask = 1 << LayerMask.NameToLayer("Interactable");
    public float rayLenght = 100f;
    GameObject gm;
    IInteractable iI;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
            
    }

    // Update is called once per frame
    void Update()
    {
          if (Input.GetKeyDown(KeyCode.Escape))
        {
           menu.SetActive(!menu.activeSelf);
        }
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, rayLenght, layerMask))
        {
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
