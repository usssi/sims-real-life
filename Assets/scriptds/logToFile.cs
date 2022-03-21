using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class logToFile : MonoBehaviour
{
    string filename = "";

    void OnEnable()
    {
        Application.logMessageReceived += Log;
    }

    void OnDisable()
    {
        Application.logMessageReceived -= Log;

    }

    private void Start()
    {
        filename = Application.dataPath + "/LogFile_SimsIrl.txt";
    }

    public void Log(string logString, string stackTrace, LogType type)
    {
        TextWriter tw = new StreamWriter(filename, true);

        tw.WriteLine("[" + System.DateTime.Now + "]"  + logString);

        tw.Close();
    }
}
