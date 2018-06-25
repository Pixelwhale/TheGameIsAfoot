using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgr : Singleton<SceneMgr>
{
    private Texture2D blackTexture;
    private float fadeAlpha = 1;
    private float fadingSpeed = 1.0f;
    private bool isFading = false;

    void Awake()
    {
        //ここで黒テクスチャ作る
        blackTexture = new Texture2D(32, 32, TextureFormat.RGB24, false);
        blackTexture.ReadPixels(new Rect(0, 0, 32, 32), 0, 0, false);
        blackTexture.SetPixel(0, 0, Color.white);
        blackTexture.Apply();
    }

    public void OnGUI()
    {
        if (!isFading) return;

        //透明度を更新して黒テクスチャを描画
        GUI.color = new Color(0, 0, 0, fadeAlpha);
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), blackTexture);
    }

    public void ReturnTitle()
    {
        LoadScene("Title");
    }
    public void ReloadCurrent()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    #region LoadScene with fading
    private void LoadScene(int sceneNum)
    {
        StartCoroutine(TransScene(sceneNum));
    }
    private void LoadScene(string sceneName)
    {
        StartCoroutine(TransScene(sceneName));
    }
    private IEnumerator TransScene(int sceneNum)
    {
        //だんだん暗く
        isFading = true;
        float timer;
        for (timer = 0; timer <= 1; timer += fadingSpeed * Time.unscaledDeltaTime)
        {
            fadeAlpha = timer;
            yield return null;
        }

        //シーン切替
        SceneManager.LoadScene(sceneNum);

        //だんだん明るく
        for (timer = 1; timer >= 0; timer -= fadingSpeed * Time.unscaledDeltaTime)
        {
            fadeAlpha = timer;
            yield return null;
        }
        isFading = false;
    }
    private IEnumerator TransScene(string sceneName)
    {
        //だんだん暗く
        isFading = true;
        float timer;
        for (timer = 0; timer <= 1; timer += fadingSpeed * Time.unscaledDeltaTime)
        {
            fadeAlpha = timer;
            yield return null;
        }

        //シーン切替
        SceneManager.LoadScene(sceneName);

        //だんだん明るく
        for (timer = 1; timer >= 0; timer -= fadingSpeed * Time.unscaledDeltaTime)
        {
            fadeAlpha = timer;
            yield return null;
        }
        isFading = false;
    }
    #endregion

}
