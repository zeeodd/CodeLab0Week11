using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZiyadController : MonoBehaviour
{
    RectTransform rt;
    private Vector2 startPos = new Vector2(0f, -50f);
    private Vector2 deathPos = new Vector2(0f, -500f);
    public bool inPlace = false;
    public bool attackZiyad = false;
    public bool isDead = false;

    private float shakeSpeed = 1.0f;
    private float shakeAmount = 1.0f;
    private float moveSpeed = 5.0f;

    void Awake()
    {
        rt = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (!inPlace && rt.anchoredPosition != startPos && !attackZiyad && !isDead)
        {
            Invoke("PopUp", 1.0f);
        }

        if (attackZiyad)
        {
            GetComponent<CameraShake>().enabled = true;
            Invoke("Die", 2.0f);
        }
    }

    void PopUp()
    {
        rt.anchoredPosition = Vector2.MoveTowards(rt.anchoredPosition, startPos, moveSpeed);
        if (rt.anchoredPosition == startPos)
        {
            inPlace = true;
        }
    }

    void Die()
    {
        attackZiyad = false;
        GetComponent<CameraShake>().enabled = false;
        rt.anchoredPosition = Vector2.MoveTowards(rt.anchoredPosition, deathPos, moveSpeed*1.5f);
        if (rt.anchoredPosition == deathPos)
        {
            isDead = true;
        }
    }

}
