using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class GameManager : MonoSingleton<GameManager>
{
    private string SAVE_PATH = "";
    private string SAVE_FILENAME = "/SaveFile.txt";
    [SerializeField] private User user = null;
    [SerializeField] private GameObject car;
    public long[] defaultGeneratorPrice;
    public User CurrentUser { get { return user; } }
    private UIManager uiManager = null;
    public UIManager UI { get { return uiManager; } }
    [SerializeField] private GameObject SettingPanel;
    private void Awake()
    {
        SAVE_PATH = Application.persistentDataPath + "/Save";
        if (Directory.Exists(SAVE_PATH) == false)
        {
            Directory.CreateDirectory(SAVE_PATH);
        }
        InvokeRepeating("Save", 1f, 5f);
        InvokeRepeating("Generation", 0f, 1f);
        InvokeRepeating("SpawnCar",0f,2);
        Load();
        uiManager = FindObjectOfType<UIManager>();
    }
    public void SpawnCar()
    {
        Instantiate(car);
    }
    public void Load()
    {
        string json = "";
        if (File.Exists(SAVE_PATH + SAVE_FILENAME) == true)
        {
            json = File.ReadAllText(SAVE_PATH + SAVE_FILENAME);
            user = JsonUtility.FromJson<User>(json);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SettingPanel.SetActive(true);
        }
    }
    void Generation()
    {
        CurrentUser.preElectric = CurrentUser.electric;
        foreach (Generator generator in user.generatorList)
        {
            CurrentUser.electric += generator.ePs * generator.amount;
            CurrentUser.totalGetElectric += generator.ePs * generator.amount;
        }
        UI.ResetTime();
        UI.UIUpdate();
    }
    public void Save()
    {
        Debug.Log("ภ๚ภๅตส");
        string json = JsonUtility.ToJson(user, true);
        File.WriteAllText(SAVE_PATH + SAVE_FILENAME, json, System.Text.Encoding.UTF8);
    }
    public void ResetAll()
    {
        CurrentUser.electric = 0;
        uiManager.UIUpdate();
        Save();
    }
    private void OnApplicationQuit()
    {
        Save();
    }
}