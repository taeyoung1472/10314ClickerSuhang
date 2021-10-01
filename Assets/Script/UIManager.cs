using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    //[SerializeField] private GameObject scrrolView;
    [SerializeField] private Animator scrrolViewAnimtor;
    [SerializeField] private GameObject content;
    [SerializeField] private Text electricText;
    [SerializeField] private Text totalClickText;
    [SerializeField] private Text totalCarClickText;
    [SerializeField] private Text totalGetElectricText;
    [SerializeField] private Text totalStillElectricText;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private GameObject textCur;
    [SerializeField] private GameObject canvasTemp;
    [SerializeField] private GameObject poolManager;
    [SerializeField] private GameObject poolTemp;
    [SerializeField] private SoundManager sound;
    [SerializeField] private GameObject[] button;
    private List<UpGradePanel> upGradePanels = new List<UpGradePanel>();
    bool isViewToggle;
    public float time;
    public float speed;
    public long scoreTemp;
    public float score;
    private void Start()
    {
        UIUpdate();
        CreatePanels();
    }
    private void Update()
    {
        time += Time.deltaTime * speed;
        score = Mathf.Lerp(GameManager.Instance.CurrentUser.preElectric, GameManager.Instance.CurrentUser.electric, time);
    }
    private void FixedUpdate()
    {
        scoreTemp = (long)score;
        UIUpdate();
    }
    private void CreatePanels()
    {
        int i = 0;
        GameObject newPanel = null;
        UpGradePanel newPanelComponent = null;
        foreach (Generator generator in GameManager.Instance.CurrentUser.generatorList)
        {
            newPanel = Instantiate(content, content.transform.parent);
            newPanelComponent = newPanel.GetComponent<UpGradePanel>();
            newPanelComponent.SetImage(sprites[i]);
            newPanelComponent.SetValue(generator);
            newPanelComponent.SetNum(i);
            newPanel.SetActive(true);
            upGradePanels.Add(newPanelComponent);
            i++;
        }
    }
    public void ToggleView(int index)
    {
        if (button[index].GetComponent<Bool>().Get())
        {
            for (int i = 0; i < 3; i++)
            {
                button[i].SetActive(true);
            }
            button[index].GetComponent<Animator>().Play("Close");
            button[index].GetComponent<Bool>().TurnFalse();
            sound.Close();
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                button[i].SetActive(false);
            }
            button[index].SetActive(true);
            button[index].GetComponent<Animator>().Play("Open");
            button[index].GetComponent<Bool>().TurnTrue();
            sound.Open();
        }
    }
    public void Click()
    {
        GameManager.Instance.CurrentUser.electric += GameManager.Instance.CurrentUser.ePc;
        GameManager.Instance.CurrentUser.totalClick++;
        GameManager.Instance.CurrentUser.totalGetElectric += GameManager.Instance.CurrentUser.ePc;
        if(poolManager.transform.childCount > 0)
        {
            GameObject temp = poolManager.transform.GetChild(0).gameObject;
            temp.SetActive(true);
            temp.transform.SetParent(poolTemp.transform);
        }
        else
        {
            Instantiate(textCur, canvasTemp.transform);
        }
        UIUpdate();
    }
    public void CarClick()
    {
        GameManager.Instance.CurrentUser.totalCarClick++;
        if (poolManager.transform.childCount > 0)
        {
            GameObject temp = poolManager.transform.GetChild(0).gameObject;
            temp.SetActive(true);
            temp.transform.SetParent(poolTemp.transform);
        }
        else
        {
            Instantiate(textCur, canvasTemp.transform);
        }
        UIUpdate();
    }
    public void UIUpdate()
    {
        electricText.text = string.Format("{0}W", scoreTemp);
        totalClickText.text = string.Format("총 클릭 수 : {0}",GameManager.Instance.CurrentUser.totalClick);
        totalCarClickText.text = string.Format("에너지를 뺏긴 자동차수 : {0}",GameManager.Instance.CurrentUser.totalCarClick);
        totalGetElectricText.text = string.Format("전력을 생산함 : {0}", GameManager.Instance.CurrentUser.totalGetElectric);
        totalStillElectricText.text = string.Format("전력을 약탈함 : {0}", GameManager.Instance.CurrentUser.totalStilElectric);
    }
    public void ResetTime()
    {
        time = 0;
    }
}