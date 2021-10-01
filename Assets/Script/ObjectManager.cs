using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public void DisActivity(GameObject obj)
    {
        obj.SetActive(false);
    }
    public void Activity(GameObject obj)
    {
        obj.SetActive(true);
    }
}
