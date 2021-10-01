using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpGradePanel : MonoBehaviour
{
    [SerializeField] private Text soldierNameText = null;
    [SerializeField] private Text amountText = null;
    [SerializeField] private Text priceText = null;
    [SerializeField] private Text ePsText;
    [SerializeField] private Image image = null;
    [SerializeField] private BackGround backGround;
    [SerializeField] private SoundManager sound;
    [SerializeField] private Image backGroundImage, buttonImage;
    int num;
    private Generator generator = null;
    bool isUnlock;
    public Generator Sold { get { return generator; } }
    public void SetValue(Generator generator)
    {
        this.generator = generator;
        UpdateUI();
    }
    private void FixedUpdate()
    {
        if (generator.amount >= 1 && isUnlock == false)
        {
            isUnlock = true;
            backGround.SetSprite(num);
        }
        if (generator.price > GameManager.Instance.CurrentUser.electric)
        {
            backGroundImage.color = Color.gray;
            buttonImage.color = Color.gray;
            image.color = Color.gray;
        }
        else
        {
            backGroundImage.color = Color.white;
            buttonImage.color = Color.white;
            image.color = Color.white;
        }
    }
    public void UpdateUI()
    {
        soldierNameText.text = generator.name;
        priceText.text = string.Format("{0} W", generator.price);
        amountText.text = string.Format("{0} 게 보유중", generator.amount);
        ePsText.text = string.Format("초당 {0}W", generator.ePs * generator.amount);

    }
    public void SetImage(Sprite sprite)
    {
        image.sprite = sprite;
    }
    public void OnClickPurchase()
    {
        if (GameManager.Instance.CurrentUser.electric < generator.price)
        {
            return;
        }
        GameManager.Instance.CurrentUser.electric -= generator.price;
        generator.price = (long)(generator.price * 1.25f);
        generator.amount++;
        sound.UpGrade();
        UpdateUI();
        GameManager.Instance.UI.UIUpdate();
    }
    public void ResetAll()
    {
        generator.price = GameManager.Instance.defaultGeneratorPrice[generator.index];
        generator.amount = 0;
        UpdateUI();
    }
    public void Purchase()
    {
        generator.amount++;
        if(GameManager.Instance.CurrentUser.electric - generator.price > 0)
        {
            GameManager.Instance.CurrentUser.electric -= generator.price;
        }
        UpdateUI();
    }
    public void SetNum(int temp)
    {
        num = temp;
    }
}
