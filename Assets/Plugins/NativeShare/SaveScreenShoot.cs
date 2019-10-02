using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SaveScreenShoot : MonoBehaviour
{
    public bool isProcessing;

    public void ScreenShoot()
    {
        StartCoroutine(C_TakePhoto());

    }

    IEnumerator C_TakePhoto()
    {
        isProcessing = true;
        yield return new WaitForEndOfFrame();


        string file = "Screen_" + GetTimestamp(DateTime.Now) + ".png";
        ScreenCapture.CaptureScreenshot(file);

        file = Application.persistentDataPath + "/"+ file;
        int count = 0;
        while (!System.IO.File.Exists(file) || count>4)
        {
            yield return null;
        }

        if (count > 4)
        {
            Debug.Log("Error too much time taking photo");
        }
        else
        {
            NativeShare nativeShare = new NativeShare();
            nativeShare.AddFile(file);
            nativeShare.Share();
        }
        

        isProcessing = false;
    }

    public static String GetTimestamp(DateTime value)
    {
        return value.ToString("yyyyMMddHHmmssffff");
    }
}
