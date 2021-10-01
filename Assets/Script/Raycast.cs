using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private GameObject textObj;
    [SerializeField] private Transform canvasTemp;
    [SerializeField] private SoundManager sound;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector2 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, transform.forward, 100);
            if (hit)
            {
                if (hit.transform.tag == "Car")
                {
                    Instantiate(textObj, canvasTemp.transform);
                    sound.Car();
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }
}
