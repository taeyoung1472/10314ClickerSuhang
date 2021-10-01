using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Text2 : MonoBehaviour
{
    [SerializeField] private Text textCur;
    [SerializeField] private Camera camera;
    [SerializeField] private RectTransform rect;
    [SerializeField] private Animator animator;
    public void OnEnable()
    {
        if (camera == null)
        {
            camera = FindObjectOfType<Camera>().GetComponent<Camera>();
        }
        animator.Play("TextAnim");
        rect.transform.position = camera.ScreenToWorldPoint(Input.mousePosition);
        rect.transform.position = new Vector3(rect.transform.position.x, rect.transform.position.y, 0f);
        textCur.text = string.Format("+{0}", GameManager.Instance.CurrentUser.ePc * 3);
        GameManager.Instance.CurrentUser.totalStilElectric += GameManager.Instance.CurrentUser.ePc * 3;
        GameManager.Instance.CurrentUser.electric += GameManager.Instance.CurrentUser.ePc * 3;
        GameManager.Instance.CurrentUser.totalCarClick++;
        Destroy(gameObject, 4);
    }
}
