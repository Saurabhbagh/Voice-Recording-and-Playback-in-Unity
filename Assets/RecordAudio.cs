using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.IO;
using System;
using TMPro;

public class RecordAudio : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public string path;
 
    public bool Onclick;
    public TextMeshProUGUI Text;
    public int counter=0;
    public AudioSource myrecording;
    string newfilename = "Recording1.wav";
   /* public void SetPath(string pathfromViewpath)
    {
        path = pathfromViewpath;    

    }*/

    public void Start()
    {
        

        foreach (var device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
        }
        if (Application.HasUserAuthorization(UserAuthorization.Microphone))
        {
            Debug.Log("Microphone found with authorization ");

        }
        else
        {
            Debug.Log("Microphone not found");

        }


        myrecording.clip = Microphone.Start(null, true, 10, 44100);  // it takes  lenght and frquency 

        while (Microphone.GetPosition(null) > 0) //latency 
        { }

       
    }
    public void OnPointerDown(PointerEventData eventData)
    {

       

        Debug.Log("Recording  audio"); 
        
        Onclick = true;
        Debug.Log("Pressing the button");
        Text.text = "Recording";
    }

    

    public void OnPointerUp(PointerEventData eventData)
    {
        Onclick = false;
        myrecording.Play();
        //end recording
        
        myrecording.enabled = false;
        SaveFile();
        Microphone.End(null);
        Debug.Log("Stopped button pressing./ Recording stopped");
        Text.text = "Recording Completed"+ Application.persistentDataPath + "/VoiceRecording" + "/" + newfilename;
    }


    //using OpenWavParser from the Unity asset store. // You can make your own wav parser
    public void SaveFile()
    {
        string totalpath = Application.persistentDataPath + "/VoiceRecording" +  "/" + newfilename;
        
        byte[] wavFile = OpenWavParser.AudioClipToByteArray(myrecording.clip);
        try
        {
             

            File.WriteAllBytes(Application.persistentDataPath + "/VoiceRecording" + "/"+newfilename, wavFile);
            File.Exists("totalpath");
        }

        catch(Exception e)
        {

            Debug.Log("error writing" + e);
        }
        myrecording.enabled = true;
    }
    
    // Update is called once per frame
    void Lateupdate()
    {
      
            //record audio
            
        
    }
}
