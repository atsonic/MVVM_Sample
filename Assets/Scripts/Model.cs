using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

public class Model : MonoBehaviour
{
    private static string getFilePath () { return Application.persistentDataPath + "/TextData" + ".json"; }
    // Start is called before the first frame update
    public static void Save(DataWrapper paperDataWrapper)
    {
        //シリアライズ実行
        string jsonSerializedData = JsonUtility.ToJson(paperDataWrapper);
        Debug.Log(jsonSerializedData);

        //実際にファイル作って書き込む
        using (var sw = new StreamWriter (getFilePath(), false)) 
        {
            try
            {
                //ファイルに書き込む
                sw.Write (jsonSerializedData);
            }
            catch (Exception e) //失敗した時の処理
            {
                Debug.Log (e);
            }
        }
    }

    /// <summary>
    /// 読み込み機能
    /// </summary>
    /// <returns>デシリアライズした構造体</returns>
    public static DataWrapper Load()
    {
        DataWrapper jsonDeserializedData = new DataWrapper();

        try 
        {
            //ファイルを読み込む
            using (FileStream fs = new FileStream (getFilePath(), FileMode.Open))
            using (StreamReader sr = new StreamReader (fs)) 
            {
                string result = sr.ReadToEnd ();
                Debug.Log(result);

                //読み込んだJsonを構造体にぶちこむ
                jsonDeserializedData = JsonUtility.FromJson<DataWrapper>(result);
            }
        }
        catch (Exception e) //失敗した時の処理
        {
            Debug.Log (e);
        }

        //デシリアライズした構造体を返す
        return jsonDeserializedData;
    }
}
