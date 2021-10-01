using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextScript : MonoBehaviour
{
    [SerializeField] private Text textCur;
    [SerializeField] private Camera camera;
    [SerializeField] private RectTransform rect;
    [SerializeField] private GameObject poolObj;
    [SerializeField] private Animator animator;
    private void Start()
    {
        poolObj = FindObjectOfType<PoolManager>().gameObject;
    }
    public void OnEnable()
    {
            if (camera == null)
            {
                camera = FindObjectOfType<Camera>().GetComponent<Camera>();
            }
            animator.Play("TextAnim");
            rect.transform.position = camera.ScreenToWorldPoint(Input.mousePosition);
            rect.transform.position = new Vector3(rect.transform.position.x, rect.transform.position.y, 0f);
            textCur.text = string.Format("+{0}", GameManager.Instance.CurrentUser.ePc);
            Invoke("Despawn", 3f);
    }
    public void Despawn()
    {
        transform.SetParent(poolObj.transform);
        gameObject.SetActive(false);
    }
}
