using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    bool Interact();
    AdviceTypes InInteract();
    void OutInteract();

}
