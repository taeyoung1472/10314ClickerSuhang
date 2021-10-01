using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BackGround : MonoBehaviour
{
    [SerializeField] private SpriteRenderer backGroundCur;
    [SerializeField] private Sprite[] backGround;
    public void SetSprite(int i)
    {
        backGroundCur.sprite = backGround[i];
    }
}
