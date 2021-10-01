using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Earth : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private int[] Epc;
    [SerializeField] private long[] price;
    [SerializeField] private Text[] text;
    [SerializeField] private Image image;
    [SerializeField] private Button[] button;
    int index = 0;
    private void Start()
    {
        image.sprite = sprites[GameManager.Instance.CurrentUser.earthLevel];
        index = GameManager.Instance.CurrentUser.earthLevel;
    }
    private void Update()
    {
        for(int i = 0; i < Epc.Length; i++)
        {
            if(GameManager.Instance.CurrentUser.electric < price[i])
            {
                text[i].color = Color.gray;
                button[i].interactable = false;
            }
            else
            {
                text[i].color = Color.black;
                button[i].interactable = true;
            }
        }
    }
    public void BuyEarthPart(int i)
    {
        if(i >= index && price[i] < GameManager.Instance.CurrentUser.electric)
        {
            image.sprite = sprites[i];
            GameManager.Instance.CurrentUser.electric -= price[i];  
            GameManager.Instance.CurrentUser.ePc = Epc[i];
            index = i;
            GameManager.Instance.CurrentUser.earthLevel = index;
        }
    }
    public void ResetEarth()
    {
        index = 0;
        GameManager.Instance.CurrentUser.earthLevel = 0;
        image.sprite = sprites[0];
        GameManager.Instance.CurrentUser.ePc = 10;
    }
}