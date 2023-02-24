using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{


    public static GameManager Instance {get; private set;}
    public GameObject scenes;
    public GameObject canvas;
    public GameObject eventSystem;
    public GameObject dialogBox;
    public GameObject startbutton;
    public GameObject howtobutton;
    public GameObject creditbutton;
    public GameObject menubutton;


    void Awake(){
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(canvas);
           // DontDestroyOnLoad(eventSystem);
        } else {
            Destroy(gameObject);
        }
    }

    IEnumerator LoadAsyncScene(string scene){
        AsyncOperation asyncload = SceneManager.LoadSceneAsync(scene);
        while (!asyncload.isDone){
            yield return null;
        }
    }
    void showcanvas(){
        dialogBox.SetActive(true);
        startbutton.SetActive(true);
        howtobutton.SetActive(true);
        creditbutton.SetActive(true);

    }
    void clearcanvas(){
        dialogBox.SetActive(false);
        startbutton.SetActive(false);
        howtobutton.SetActive(false);
        creditbutton.SetActive(false);

    }

    public void StartGame(){
        clearcanvas();
        StartCoroutine(LoadAsyncScene("main"));
        scenes.SetActive(false);
    }

    public void HowToPlay(){
        clearcanvas();
        menubutton.SetActive(true);
        StartCoroutine(LoadAsyncScene("howtoplay"));
        scenes.SetActive(false);
    }

    public void Credits(){
        clearcanvas();
        menubutton.SetActive(true);
        StartCoroutine(LoadAsyncScene("credit"));
        scenes.SetActive(false);
    }

    public void creditmenu(){
        StartCoroutine(LoadAsyncScene("SampleScene"));
        scenes.SetActive(false);
        showcanvas();
        
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
