using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZXing;
using ZXing.QrCode;

public class QR_Code : MonoBehaviour {

    private WebCamTexture camTexture;
    private Rect screenRect;
    public Text text;
    public GameObject qrScreen;
    public GameObject challengeScreen;
    public Transform qrLocation;
    private Vector2 size = new Vector2(1000, 1000);
    Vector2 pos = new Vector2(Screen.height * .25f, Screen.width * .25f);
    Vector2 pivot;
    public float angle = 90;

    void Start()
    {
        //screenRect = new Rect(0, 0, Screen.width, Screen.height);
        UpdateSettings();
        camTexture = new WebCamTexture();
        camTexture.requestedHeight = Screen.height;
        camTexture.requestedWidth = Screen.width;
        if (camTexture != null)
        {
            camTexture.Play();
        }

    }

    void UpdateSettings()
    {
        pos = qrLocation.position;
        screenRect = new Rect(pos.x - size.x * .5f, pos.y - size.y * .5f, size.x, size.y);
        pivot = new Vector2(screenRect.xMin + screenRect.width * 0.5f, screenRect.yMin + screenRect.height * 0.5f);
    }

    void OnGUI()
    {
        // draw4ing the camera on screen
        Matrix4x4 matrixBackup = GUI.matrix;
        GUIUtility.RotateAroundPivot(angle, pivot);
        GUI.DrawTexture(screenRect, camTexture);
        GUI.matrix = matrixBackup;
        // do the reading — you might want to attempt to read less often than you draw on the screen for performance sake
        try
        {
            IBarcodeReader barcodeReader = new BarcodeReader();
            // decode the current frame
            var result = barcodeReader.Decode(camTexture.GetPixels32(),
              camTexture.width, camTexture.height);
            if (result != null)
            {
                Debug.Log("DECODED TEXT FROM QR: " +result.Text);
                GameManager.instance.SelectGame(result.Text);
                text.text = result.Text;
                qrScreen.SetActive(false);
                challengeScreen.SetActive(true);
            }
        }
        catch (Exception ex) { Debug.LogWarning(ex.Message); }
    }
}
