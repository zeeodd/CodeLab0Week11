using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject textBox;
    public ZiyadController ziyad;
    public GameObject spellInput;
    private InputController inputController;

    private string secondTextString = "Quick, use a spell!";
    private string spellUseTextSring = "Nice! Use ";
    private string emptyTextString = "";
    private float textDelay = 1.5f;

    public bool secondText = false;
    public bool readyForInput = false;
    public bool ziyadAttack = false;

    void Start()
    {
        textBox.SetActive(false);
        spellInput.SetActive(false);
        inputController = spellInput.GetComponent<InputController>();
    }

    void Update()
    {
        if (ziyad.inPlace)
        {
            textBox.SetActive(true);
            Invoke("SecondText", textDelay);
        }

        if (secondText)
        {
            textBox.GetComponentInChildren<Text>().text = secondTextString;
            Invoke("InputSpellNow", textDelay);
        }

        if(readyForInput)
        {
            textBox.GetComponentInChildren<Text>().text = emptyTextString;
            spellInput.SetActive(true);
        }

        if(inputController.gotSpell)
        {
            spellInput.SetActive(false);
            textBox.GetComponentInChildren<Text>().text = spellUseTextSring + inputController.spellName.Substring(0, 2) + "-";
            Invoke("ZiyadAttack", textDelay - 0.5f);
        }

        if(ziyadAttack)
        {
            textBox.SetActive(false);
            ziyad.makeZiyadAttack = true;
        }
    }

    void SecondText()
    {
        secondText = true;
    }

    void InputSpellNow()
    {
        readyForInput = true;
    }

    void ZiyadAttack()
    {
        ziyadAttack = true;
    }
}
