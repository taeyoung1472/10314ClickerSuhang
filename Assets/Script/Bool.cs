using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bool : MonoBehaviour
{
    private bool isTrue;
    public bool Get()
    {
        return isTrue;
    }
    public void TurnTrue()
    {
        isTrue = true;
    }
    public void TurnFalse()
    {
        isTrue = false;
    }
}
