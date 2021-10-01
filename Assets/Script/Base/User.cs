using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class User
{
    #region 기록용 변수
    public int totalClick;
    public int totalCarClick;
    public long totalGetElectric;
    public long totalStilElectric;
    public int earthLevel;
    #endregion 
    public long preElectric;
    public string userName;
    public long electric;
    public long ePc;
    public List<Generator> generatorList = new List<Generator>();
}
