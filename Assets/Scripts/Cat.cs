using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cat : MonoBehaviour
{
    public NavMeshAgent nav;
    public int newWay;
    public GameObject cat;
    public Vector3 way;
    private float Timer;

    private void Start()
    {
        nav = gameObject.GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        Walking();
    }

    public void Walking()
    {
        Timer += Time.deltaTime;
        if(Timer>=newWay)
        {
            float MyX = gameObject.transform.position.x;
            float MyZ = gameObject.transform.position.z;

            float PosX = MyX + Random.Range(MyX - 100, MyX + 100);
            float PosZ = MyZ + Random.Range(MyZ - 100, MyZ + 100);

            way = new Vector3(PosX, gameObject.transform.position.y, PosZ);

            nav.SetDestination(way);

            Timer = 0;
        }
        cat.GetComponent<Animator>().SetTrigger("Walking");
    }

    //public void Moving()
    //{
    //    if (Input.GetAxis("Horizontal") * speed == 0 && Input.GetAxis("Vertical") * speed == 0)
    //    {
    //        cat.GetComponent<Animator>().SetTrigger("Sitting");
    //    }
    //    else
    //    {
    //        horizontal = Input.GetAxis("Horizontal") * speed;
    //        vertical = Input.GetAxis("Vertical") * speed;

    //        var moveDirection = new Vector3(0, 0, vertical);
    //        var rotateDirection = new Vector3(0, horizontal, 0);
    //        transform.Translate(moveDirection);
    //        transform.Rotate(rotateDirection);

    //        cat.GetComponent<Animator>().SetTrigger("Walking");
    //    }

    //}
}
