using UnityEngine;
public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource clickAudio,upGradeAudio,carAudio,unLockAudio,closeAudio,openAudio,repairAudio;
    public void Click()
    {
        clickAudio.Play();
    }
    public void UpGrade()
    {
         upGradeAudio.Play();
    }
    public void Car()
    {
         carAudio.Play();
    }
    public void Unlock()
    {
        unLockAudio.Play();
    }
    public void Open()
    {
        openAudio.Play();
    }
    public void Close()
    {
        closeAudio.Play();
    }
    public void Repair()
    {
        repairAudio.Play();
    }
}