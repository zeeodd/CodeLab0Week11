using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    // Set up bool and string for spell grabbing
    public bool gotSpell = false;
    public string spellName;

    // This function is called when the player hits "Enter" after inputting a spell
    public void GetInput()
    {
        // Grab the spell name and flip the gotSpell bool
        spellName = GetComponent<InputField>().text;
        gotSpell = true;
    }
}
