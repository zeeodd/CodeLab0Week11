using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject textBox;
    public ZiyadController ziyad;

    public bool secondText = false;
    public bool readyForInput = false;

    // Start is called before the first frame update
    void Start()
    {
        textBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ziyad.inPlace)
        {
            textBox.SetActive(true);
            Invoke("SecondText", 1.5f);
        }

        if (secondText)
        {
            textBox.GetComponentInChildren<Text>().text = "Quick, use a spell!";
        }
    }

    void SecondText()
    {
        secondText = true;
    }
}
