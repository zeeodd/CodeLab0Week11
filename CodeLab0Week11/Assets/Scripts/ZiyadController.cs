using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZiyadController : MonoBehaviour
{
    RectTransform rt;
    private Vector2 startPos = new Vector2(0f, -50f);
    public bool inPlace;

    void Awake()
    {
        rt = GetComponent<RectTransform>();
        inPlace = false;
    }

    void Update()
    {
        if (!inPlace)
        {
            Invoke("PopUp", 1.0f);
        }
    }

    void PopUp()
    {
        rt.anchoredPosition = Vector2.MoveTowards(rt.anchoredPosition, startPos, 5f);
        if (rt.anchoredPosition == startPos)
        {
            inPlace = true;
        }
    }

}
