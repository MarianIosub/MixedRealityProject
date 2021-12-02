using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SaveDropdown : MonoBehaviour
{
    public Dropdown dropdown;

    void Start()
    {
        dropdown.onValueChanged.AddListener(delegate
        {
            dropdownValueChangedHappened(dropdown);
        });
    }

    public void dropdownValueChangedHappened(Dropdown option)
    {
        Debug.Log("You have selected this: " + option.value);
    }
}
