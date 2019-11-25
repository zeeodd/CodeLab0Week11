using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Connect all important game objects to manage
    public GameObject textBox;
    public ZiyadController ziyad;
    public GameObject spellInput;
    public GameObject background;
    private InputController inputController;

    // Private variables -- mostly strings for the text box
    private string secondTextString = "Quick, use a spell!";
    private string spellUseTextSring = "Nice! Use ";
    private string finalAttackTextString = "Dodged! Now use ";
    private string endTextString = "You've slain the beast!";
    private string emptyTextString = "";
    private float textDelay = 1.5f;

    // Story bools
    public bool secondText = false;
    public bool readyForInput = false;
    public bool ziyadAttack = false;
    public bool finalAttack = false;

    void Start()
    {
        // Set text box and input bar inactive, but also hook up inputController
        textBox.SetActive(false);
        spellInput.SetActive(false);
        inputController = spellInput.GetComponent<InputController>();
    }

    void Update()
    {
        // All of these if-statements are triggered by the story bools and
        // utilize the Invoke method for slight delays
        if (ziyad.inPlace)
        {
            // Change text
            textBox.SetActive(true);
            Invoke("SecondText", textDelay);
        }

        if (secondText)
        {
            // Change text
            textBox.GetComponentInChildren<Text>().text = secondTextString;
            Invoke("InputSpellNow", textDelay);
        }

        if(readyForInput)
        {
            // Set text empty while player inputs a spell
            textBox.GetComponentInChildren<Text>().text = emptyTextString;
            spellInput.SetActive(true);
        }

        if(inputController.gotSpell && readyForInput)
        {
            // Set the input box inactive and utilize the player-inputted spell
            spellInput.SetActive(false);
            textBox.GetComponentInChildren<Text>().text = spellUseTextSring + inputController.spellName.Substring(0, 2) + "-";
            Invoke("ZiyadAttack", textDelay - 0.5f);
        }

        if(ziyadAttack)
        {
            // Set text box inactive and shake the background
            textBox.SetActive(false);
            background.GetComponent<CameraShake>().enabled = true;
            Invoke("FinalAttack", textDelay);
        }

        if(finalAttack)
        {
            // Awaken the text box again and finally use the player spell
            background.GetComponent<CameraShake>().enabled = false;
            textBox.SetActive(true);
            textBox.GetComponentInChildren<Text>().text = finalAttackTextString + inputController.spellName + "!";
            Invoke("KillZiyad", textDelay);
        }

        if(ziyad.isDead)
        {
            // Call final invoke method to end the game
            Invoke("FinalTextDisplay", textDelay);
        }
    }

    // All of these methods act as simple switches to progress the story
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
