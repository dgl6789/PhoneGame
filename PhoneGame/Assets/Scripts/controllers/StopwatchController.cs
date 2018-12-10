using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopwatchController : MonoBehaviour {

    [SerializeField] Text TimerText;
    [SerializeField] GameObject Tray;

    float time;
    bool running;

    public static StopwatchController Instance;

    private void Awake() {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }

    private void Update() {
        if(running) {
            time += Time.deltaTime;
            UpdateTimerText();
        }
    }

    public void ToggleTrayVisibility() {
        Tray.SetActive(!Tray.activeSelf);
    }

    public void StartTimer() {
        running = true;
    }

    public void StopTimer() {
        running = false;
        time = 0;

        UpdateTimerText();
    }

    private void UpdateTimerText() {
        int seconds = Mathf.FloorToInt(time) % 60;
        int minutes = Mathf.FloorToInt(time) / 60;

        TimerText.text = minutes + ":" + seconds.ToString("00");

    }
}
