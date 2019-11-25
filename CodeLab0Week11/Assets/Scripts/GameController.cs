using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject textBox;
    public ZiyadController ziyad;
    public GameObject spellInput;
    public GameObject background;
    private InputController inputController;

    private string secondTextString = "Quick, use a spell!";
    private string spellUseTextSring = "Nice! Use ";
    private string finalAttackTextString = "Dodged! Now use ";
    private string endTextString = "You've slain the beast!";
    private string emptyTextString = "";
    private float textDelay = 1.5f;

    public bool secondText = false;
    public bool readyForInput = false;
    public bool ziyadAttack = false;
    public bool finalAttack = false;

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
            secondText = false;
        }

        if(readyForInput)
        {
            textBox.GetComponentInChildren<Text>().text = emptyTextString;
            spellInput.SetActive(true);
        }

        if(inputController.gotSpell && readyForInput)
        {
            spellInput.SetActive(false);
            textBox.GetComponentInChildren<Text>().text = spellUseTextSring + inputController.spellName.Substring(0, 2) + "-";
            Invoke("ZiyadAttack", textDelay - 0.5f);
        }

        if(ziyadAttack)
        {
            textBox.SetActive(false);
            background.GetComponent<CameraShake>().enabled = true;
            Invoke("FinalAttack", textDelay);
        }

        if(finalAttack)
        {
            background.GetComponent<CameraShake>().enabled = false;
            textBox.SetActive(false);
            textBox.GetComponentInChildren<Text>().text = finalAttackTextString + inputController.spellName + "!";
            Invoke("KillZiyad", textDelay);
        }

        if(ziyad.isDead)
        {
            Invoke("FinalTextDisplay", textDelay);
        }
    }

    void SecondText()
    {
        ziyad.inPlace = false;
        secondText = true;
    }

    void InputSpellNow()
    {
        secondText = false;
        readyForInput = true;
    }

    void ZiyadAttack()
    {
        readyForInput = false;
        ziyadAttack = true;
    }

    void FinalAttack()
    {
        ziyadAttack = false;
        finalAttack = true;
    }

    void KillZiyad()
    {
        finalAttack = false;
        ziyad.attackZiyad = true;
    }

    void FinalTextDisplay()
    {
        textBox.SetActive(true);
        textBox.GetComponentInChildren<Text>().text = endTextString;
    }
}
