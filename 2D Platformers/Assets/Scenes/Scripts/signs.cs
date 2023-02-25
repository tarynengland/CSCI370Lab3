using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class signs : MonoBehaviour
{



    public GameObject dialogueBox;
    public TextMeshProUGUI dialogueText;
    public string text;
    // when player collides with signs will bring up dialogue
    public void OnTriggerEnter2D(Collider2D collider2D)
    {
        print("Entered..");
        if (collider2D.gameObject.CompareTag("Player"))
        {
            DialogueShow(text);
        }
    }
    //hides dialogue on exit
    public void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Player"))
        {
            DialogueHide();
        }
    }
    // method for showing dialogue, panel and image, and refers to type text which types the text out
    public void DialogueShow(string text)
    {
        dialogueBox.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(TypeText(text));
    }
    // method for hiding the dialogue/ dialogue panel and image
    public void DialogueHide()
    {
        dialogueBox.SetActive(false);
    }

    // types the text character by character
    IEnumerator TypeText(string text)
    {
        dialogueText.text = "";
        foreach (char c in text.ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(0.02f);
        }
        //DialogHide();
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
