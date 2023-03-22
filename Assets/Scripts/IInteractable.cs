using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    //Code we want to run when the player interacts with the object
    public void Interact();
    
    //These are prompts shown in game that indicate the object can be interacted with; in our case, it appears on a mouseover
    public void ShowPrompt();
    public void HidePrompt();
}
