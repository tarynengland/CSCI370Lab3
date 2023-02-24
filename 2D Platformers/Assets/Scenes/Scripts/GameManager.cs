using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{


    public static GameManager Instance {get; private set;}
    public GameObject Samplescene;
    public GameObject curtain;
    private bool raiseLower = false;
    public GameObject canvas;
    public GameObject eventSystem;


    void Awake(){
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(canvas);
            DontDestroyOnLoad(eventSystem);
        } else {
            Destroy(gameObject);
        }
    }

    IEnumerator ColorLerp(bool fadeouts, float duration){
        float time = 0;
        raiseLower = true;
        Image curtainImg = curtain.GetComponent<Image>();
        Color startValue;
        Color endValue;
        if (fadeouts) {
            startValue = new Color(0,0,0,0);
            endValue = new Color(0,0,0,1);
        } else {
            startValue = new Color(0,0,0,1);
            endValue = new Color(0,0,0,0);
        }
        while (time < duration){
            curtainImg.color = Color.Lerp(startValue,endValue, time/duration);
            time += Time.deltaTime;
            yield return null;
        }
        curtainImg.color = endValue;
        raiseLower = false;
    }

    IEnumerator LoadAsyncScene(string scene){
        StartCoroutine(ColorLerp(true, 1));
        while (raiseLower){
            yield return null;
        }
        AsyncOperation asyncload = SceneManager.LoadSceneAsync(scene);
        while (!asyncload.isDone){
            yield return null;
        }
        StartCoroutine(ColorLerp(false, 1));
    }

    public void StartGame(){
        StartCoroutine(LoadAsyncScene("main"));
        Samplescene.SetActive(false);
    }

    public void HowToPlay(){
        StartCoroutine(LoadAsyncScene("howtoplay"));
        Samplescene.SetActive(false);
    }
    public void Credits(){
        StartCoroutine(LoadAsyncScene("credit"));
        Samplescene.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
