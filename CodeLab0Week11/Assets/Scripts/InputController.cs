using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    public bool gotSpell;
    public string spellName;

    void Start()
    {
        gotSpell = false;
    }

    public void GetInput()
    {
        spellName = GetComponent<InputField>().text;
        print(spellName);
        gotSpell = true;
    }
}
