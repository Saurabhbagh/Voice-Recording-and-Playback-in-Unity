using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class ViewPath : MonoBehaviour
{

    public string path;
    public Button view;
    public TextMeshProUGUI text;
    private string Displaytext;
    string newpath;
    private void Start()
    {
        view.onClick.AddListener(PathView);
         path = Application.persistentDataPath+ "/VoiceRecording";
         newpath = path;
         if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
            Displaytext = path + "SuccessFull creation ";
        }

        else
        {
            Displaytext = "Failed ";

        }   
            
    }

    private void PathView()
    {
       // path = Application.dataPath + "//i am here";
        text.text = Displaytext + Application.persistentDataPath;
        
    }
}
    
   

