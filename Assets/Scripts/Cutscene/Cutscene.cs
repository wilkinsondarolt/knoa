using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CutsceneScene
{
    public AudioClip Voice;
    public Sprite CutsceneImage; 
    public float Duration = 1.0f;
}
	
public class Cutscene : MonoBehaviour
{
    private byte CurrentScene;
    private AudioSource audioControl;
    private Image imageRenderer;

    public CutsceneScene[] Config;
    public Object SceneToLoad;

	void Start ()
    {
        audioControl = GetComponent<AudioSource>();
        imageRenderer = GetComponent<Image>();
        ChangeScene();
    }


    void ChangeScene()
    {
        CutsceneScene sceneToPlay = Config[CurrentScene];

        if (sceneToPlay.Voice)
        {
            audioControl.Stop();
            audioControl.clip = sceneToPlay.Voice;
            audioControl.Play();
        }        

        imageRenderer.sprite = sceneToPlay.CutsceneImage;
        CurrentScene++;
        if (CurrentScene >= Config.Length)
            Invoke("ChangeToNextScene", sceneToPlay.Duration); 
        else
            Invoke("ChangeScene", sceneToPlay.Duration);

	    }

    void ChangeToNextScene()

    {
        Scenes.LoadScene(SceneToLoad.name);
    }

}
