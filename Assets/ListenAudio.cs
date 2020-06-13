using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ListenAudio : MonoBehaviour
{
    public Button listen;
    public string path;
    public AudioSource ListentoAudio;
    public TextMeshProUGUI Text;
    private void Start()
    {
        path = Application.persistentDataPath + "/VoiceRecording" + "/" + "Recording1.wav";
        listen.onClick.AddListener(PlayAudio);
        ListentoAudio = GetComponent<AudioSource>();
    }

    private void PlayAudio()
    {
        Text.text = "PLaying";
        if (File.Exists(path))
        {
            byte[] wavFile = File.ReadAllBytes(path);
            ListentoAudio.clip = OpenWavParser.ByteArrayToAudioClip(wavFile);
            ListentoAudio.Play();
            Text.text = "playing over";
        }
        else
        {
            Debug.Log("File not found");
            Debug.Log(path);
            Text.text = "File not found";
        }

        
        //  StartCoroutine(AudioPLaying());
    }



    IEnumerator AudioPLaying()
    {

        yield return null;
    }
}
