using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastSystem : MonoBehaviour
{

    [SerializeField]
    private Transform menuAdvices;
    [SerializeField]
    private AdviceManager adviceM;

    private bool interacting = false;
    RaycastHit hit;
    Camera cam;
    int layerMask;
    public float rayLenght = 2f;
    IInteractable iI;
    void Start()
    {

        cam = GetComponentInChildren<Camera>();
        layerMask = 1 << LayerMask.NameToLayer("Interactable");
    }


    void Update()
    {


        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, rayLenght, layerMask))
        {

            iI = hit.collider.gameObject.GetComponent<IInteractable>();
            if (iI != null)
            {
                adviceM.SetActive(iI.InInteract(), true);

                if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.F))
                {
                    interacting = iI.Interact();
                    adviceM.SetActive(iI.InInteract(), !interacting);

                }
                else if (Input.GetKeyDown(KeyCode.Escape))
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
        else
        {
            adviceM.DisableAll();
            if (iI != null)
            {
                
                interacting = false;
            }
        }
    } 
     
            
          
      
}

