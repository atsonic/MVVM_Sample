using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextField : MonoBehaviour
{
    // Start is called before the first frame update
    private Text _text;
    void Start(){
        _text = this.GetComponent<Text>();
    }
    public void showText(List<TextData> dataList){
        string textString = "";
        foreach (TextData paperData in dataList){
            textString += paperData.userText + "\n";
        }
        _text.text = textString;
    }
}
