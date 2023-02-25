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
    public GameObject resetbutton;
    public GameObject rules;


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
        menubutton.SetActive(false);
        resetbutton.SetActive(false);
        rules.SetActive(false);

    }
    void clearcanvas(){
        dialogBox.SetActive(false);
        startbutton.SetActive(false);
        howtobutton.SetActive(false);
        creditbutton.SetActive(false);

    }

    public void StartGame(){
        clearcanvas();
        resetbutton.SetActive(true);
        StartCoroutine(LoadAsyncScene("main"));
        scenes.SetActive(false);
    }

    public void HowToPlay(){
        clearcanvas();
        menubutton.SetActive(true);
        rules.SetActive(true);
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
        showcanvas();
        StartCoroutine(LoadAsyncScene("SampleScene"));
        scenes.SetActive(false);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        showcanvas();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
