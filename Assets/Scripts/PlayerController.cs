using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class PlayerController : MonoBehaviour,ISaveable
{
    
    private CharacterController cc;
    public float moveSpeed = 10f;
    private void Awake()
    {
        SaveLoad.SubscribeSV(this.gameObject);
    }
    private void Start()
    {
        Cursor.visible = false;
        
        cc = GetComponent<CharacterController>();
    }
    public void Save() 
    {
        JSONObject save = new JSONObject();
        JSONArray position = new JSONArray();
        position.Add(transform.position.x);
        position.Add(transform.position.y);
        position.Add(transform.position.z);
        save.Add("position",position);
        SaveLoad.saveFile.Add("Player", save);
    }
    public void Load()
    {
        JSONObject save = new JSONObject();
        save.Add(SaveLoad.saveFile["Player"]);
        transform.position = new Vector3(
            save["position"].AsArray[0],
            save["position"].AsArray[1],
            save["position"].AsArray[2]
            );
    }
    private void OnDestroy()
    {
        SaveLoad.SaveAll -= Save;
        SaveLoad.LoadAll -= Load;
    }
    public void Check() 
    {

    }
    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        move.Set(move.x, -1, move.z);
        cc.Move(move * moveSpeed * Time.deltaTime);
        
    }   
}   