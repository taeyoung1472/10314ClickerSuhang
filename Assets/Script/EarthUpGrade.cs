using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EarthUpGrade : MonoBehaviour
{
    [SerializeField] private int price;
    private Text text;
    private void Start()
    {
        text = GetComponent<Text>();
    }
    void Update()
    {
        if(price > GameManager.Instance.CurrentUser.electric)
        {
            text.color = Color.gray;
        }
        else
        {
            text.color = Color.black;
        }
    }
}
