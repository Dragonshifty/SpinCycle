using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationHead : MonoBehaviour
{
    private int combosUnlocked;
    private bool fullCombinationUnlocked;
    private void OnEnable() 
    {
        EventOverseer.CombinationUnlocked += HandleCombination;   
    }

    private void HandleCombination()
    {
        fullCombinationUnlocked = (++combosUnlocked == 3);
        if (fullCombinationUnlocked)
        {
            DoSomethingWhenUnlocked();
            combosUnlocked = 0;
            fullCombinationUnlocked = false;
        }
    }

    private void DoSomethingWhenUnlocked()
    {

    }
}
