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
    public GameObject canvas;
    public GameObject eventSystem;
    public GameObject dialogBox;
    public GameObject startbutton;
    public GameObject howtobutton;
    public GameObject creditbutton;


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

    void clearcanvas(){
        dialogBox.SetActive(false);
        startbutton.SetActive(false);
        howtobutton.SetActive(false);
        creditbutton.SetActive(false);
    }

    public void StartGame(){
        clearcanvas();
        StartCoroutine(LoadAsyncScene("main"));
        Samplescene.SetActive(false);
    }

    public void HowToPlay(){
        clearcanvas();
        StartCoroutine(LoadAsyncScene("howtoplay"));
        Samplescene.SetActive(false);
    }
    public void Credits(){
        clearcanvas();
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
