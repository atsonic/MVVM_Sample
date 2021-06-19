using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldView : MonoBehaviour
{
    private InputField _inputField;

    private void Start() {
        _inputField = this.GetComponent<InputField>();
    }
    public string getText(){
        return _inputField.text;
    }
}
