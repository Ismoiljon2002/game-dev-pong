using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Slider ballSpeedSlider;
    public Slider paddleSpeedSlider;
    public Text ballSpeedText;
    public Text paddleSpeedText;
    public Dropdown hardnessLevelDropdown;


    public static float ballSpeed;
    public static float paddleSpeed;
    public static int hardnessLevel;


    void Start () {
        ballSpeed = ballSpeedSlider.value;
        ballSpeedText.text = string.Format("{0:N1}", ballSpeedSlider.value);
        paddleSpeed = paddleSpeedSlider.value;
        paddleSpeedText.text = string.Format("{0:N1}", ballSpeedSlider.value);
        hardnessLevel = hardnessLevelDropdown.value;
    }

    public void PlaySingleMode () {
        SceneManager.LoadSceneAsync(2);
    }

    public void PlayMultiMode()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void UpdateBallSpeed(float newSpeed)
    {
        ballSpeed = newSpeed;
    }

    public void UpdatePaddleSpeed(float newSpeed)
    {
        paddleSpeed = newSpeed;
    }

    public void ChangeHardnessLevel () {
        hardnessLevel = hardnessLevelDropdown.value;
    }

    public void ChangeBallSpeedText() {
        ballSpeedText.text = string.Format("{0:N1}", ballSpeedSlider.value);
        UpdateBallSpeed(ballSpeedSlider.value);

    }
    public void ChangePaddleSpeedText()
    {
        paddleSpeedText.text = string.Format("{0:N1}", paddleSpeedSlider.value);
        UpdatePaddleSpeed(paddleSpeedSlider.value);
    }
}
