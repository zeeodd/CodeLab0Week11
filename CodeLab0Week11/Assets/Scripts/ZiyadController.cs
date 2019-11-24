using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZiyadController : MonoBehaviour
{
    RectTransform rt;
    private Vector2 startPos = new Vector2(0f, -50f);
    public bool inPlace = false;
    public bool makeZiyadAttack = false;

    private float shakeSpeed = 1.0f;
    private float shakeAmount = 1.0f;

    void Awake()
    {
        rt = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (!inPlace)
        {
            Invoke("PopUp", 1.0f);
        }

        if(makeZiyadAttack)
        {
            Attack();
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

    void Attack()
    {
        var tempPos = rt.anchoredPosition;
        rt.anchoredPosition = tempPos * Mathf.Cos(Time.time * shakeSpeed) * shakeAmount;
    }

}
