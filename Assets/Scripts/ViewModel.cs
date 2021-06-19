using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;
using UnityEngine;
using System;

public class ViewModel : MonoBehaviour
{
    [SerializeField] GameObject _inputFieldObject;
    [SerializeField] GameObject _textFieldObject;

    private InputFieldView _inputFieldView;
    private TextField _textField;
    private DataWrapper _dataWrapper; 
    // Start is called before the first frame update
    void Start()
    {
        _inputFieldView = _inputFieldObject.GetComponent<InputFieldView>();
        _textField = _textFieldObject.GetComponent<TextField>();
        loadText();
    }
    public void onButtonClicked(){
        string text = _inputFieldView.getText();
        if(text != ""){
            saveText();
        }
        TextData textData = new TextData();
        textData.userText = text;
        textData.dateString = getDate();
        _dataWrapper.DataList.Add(textData);
        showText();
        saveText();
    }
    private void showText(){
        _textField.showText(_dataWrapper.DataList);
    }
    private void loadText(){
        _dataWrapper = Model.Load();
        showText();
    }
    private void saveText(){
        Model.Save(_dataWrapper);
    }
    private string getDate(){
        DateTime TodayNow = DateTime.Now;
        return TodayNow.Year.ToString() + TodayNow.Month.ToString() + TodayNow.Day.ToString();
    }
}
