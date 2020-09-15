using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafeScript : MonoBehaviour,IInteractable,ISaveable
{
    [SerializeField]
    private Text textInput;
    [SerializeField]
    private int codeValue;
    Animator am;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Camera cam;
    private void Start()
    {
        SaveLoad.SubscribeSV(this.gameObject);
        am = GetComponent<Animator>();
        //cam = player.GetComponentInChildren<Camera>();
    }
    public bool Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            cam.gameObject.SetActive(true);
            player.GetComponentInChildren<Camera>().gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            return true;
        }
        return false;
    }

    public void OutInteract()
    {
        cam.gameObject.SetActive(false);
        player.GetComponentInChildren<Camera>().gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }
    public int InInteract()
    {
        return 0;
    }
    
    public void Save()
    {

    }

    public void Load()
    {

    }

    public void AddNum(int num)
    {
        textInput.text += num;
    }
    public void RemoveNum()
    {
        textInput.text.Remove(textInput.text.Length);
    }
    public void RemoveAll()
    {
        textInput.text = "";
    }
    public void CheckCode()
    {
        if (int.Parse(textInput.text) == codeValue)
        {
            am.SetTrigger("Open");

        }
    }
}
