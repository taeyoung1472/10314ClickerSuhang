using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private Animator anim;
    void Start()
    {
        int a = Random.Range(0, 4);
        if (a == 0)
            anim.Play("Car1");
        if (a == 1)
            anim.Play("Car2");
        if (a == 2)
            anim.Play("Car3");
        if (a == 3)
            anim.Play("Car4");
        Destroy(gameObject, 15f);
    }
}
