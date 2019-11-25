using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZiyadController : MonoBehaviour
{
    // Get RectTransform of Image for movement
    RectTransform rt;

    // Start and death pos for Ziyad gameObject
    private Vector2 startPos = new Vector2(0f, -50f);
    private Vector2 deathPos = new Vector2(0f, -500f);

    // Story bools
    public bool inPlace = false;
    public bool attackZiyad = false;
    public bool isDead = false;

    // Private vars for shaking and movement
    private float shakeSpeed = 1.0f;
    private float shakeAmount = 1.0f;
    private float moveSpeed = 5.0f;

    // Hook up RectTransform upon waking up
    void Awake()
    {
        rt = GetComponent<RectTransform>();
    }

    void Update()
    {
        // Only move Ziyad to startPos in the beginning
        // Use story checks to make sure this happens only one
        if (!inPlace && rt.anchoredPosition != startPos && !attackZiyad && !isDead)
        {
            Invoke("PopUp", 1.0f);
        }

        // Called when player attacks Ziyad with their spell
        if (attackZiyad)
        {
            GetComponent<CameraShake>().enabled = true;
            Invoke("Die", 2.0f);
        }
    }

    // This method moves Ziyad to startPos
    void PopUp()
    {
        rt.anchoredPosition = Vector2.MoveTowards(rt.anchoredPosition, startPos, moveSpeed);
        // Only flip the bool when Ziyad is in position
        if (rt.anchoredPosition == startPos)
        {
            inPlace = true;
        }
    }

    // This method kills Ziyad and flips the last bool to end the game
    void Die()
    {
        attackZiyad = false;
        GetComponent<CameraShake>().enabled = false;
        rt.anchoredPosition = Vector2.MoveTowards(rt.anchoredPosition, deathPos, moveSpeed*1.75f);
        if (rt.anchoredPosition == deathPos)
        {
            isDead = true;
        }
    }

}
