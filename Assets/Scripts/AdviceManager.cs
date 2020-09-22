using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AdviceTypes {Usial,Window };
public class AdviceManager : MonoBehaviour
{
    [SerializeField]
    private GameObject adviceUsial;
    [SerializeField]
    private GameObject adviceWindow;


    public void DisableAll()
    {
        adviceUsial.SetActive(false);
        adviceWindow.SetActive(false);
    }
    public void SetActive(AdviceTypes type,bool state)
    {
        switch (type)
        {
            case AdviceTypes.Usial:
                adviceUsial.SetActive(state);
                break;
            case AdviceTypes.Window:
                adviceWindow.SetActive(state);
                break;
        }
    }

}
