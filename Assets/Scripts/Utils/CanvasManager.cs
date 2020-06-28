using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public Text TopText;
    public Button TopButton;
    public Image TopImage;
    public int LevelsToDisplay;
    //
    private Animator animator;
    private int _levelToLoad;

    public void LevelStartFlow()
    {
        FadeOutEffect();

        // HotFix
        Invoke("DisableCanvas", 1);
        GameManager.Instance.StartLevel(_levelToLoad);
    }
    
    public void LevelEndFlow()
    {   
        EnableCanvas();
        FadeInEffect();
        TopText.text = String.Format("Level {0} Complete !!!    Press Start For Next level", _levelToLoad + 1);
        // increment level
        _levelToLoad++;

        // TODO - HotFix make this better
        if (_levelToLoad > LevelsToDisplay)
        {
            _levelToLoad = 0;
        } 
    }

    public void GameOverFlow()
    {
        EnableCanvas();
        FadeInEffect();
        TopText.text = "GameOver       Press Start for restarting";
        //Reset Level
        _levelToLoad = 0;
    }

    public void UpdateToptext(string text)
    {
        TopText.text = text;
    }

    private void FadeInEffect()
    {
        StartCoroutine(StartFadeIn(0.9f));     
    }

    IEnumerator StartFadeIn(float fadeoutTime)
    {
        Color tempColor = TopImage.color;

        while (tempColor.a < 1f)
        {
            tempColor.a += Time.deltaTime / fadeoutTime;
            TopImage.color = tempColor;

            yield return null;
        }
    }

    private void FadeOutEffect()
    {
        StartCoroutine(StartFadeOut(0.9f));     
    }

    IEnumerator StartFadeOut(float fadeoutTime)
    {
        Color tempColor = TopImage.color;

        while (tempColor.a > 0f)
        {
            tempColor.a -= Time.deltaTime / fadeoutTime;
            TopImage.color = tempColor;

            yield return null;
        }
    }

    private void DisableCanvas()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    private void EnableCanvas()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }


}
