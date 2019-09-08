using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    //public TextMeshProUGUI textDisplay;
    public Text displayText;
    public string[] sentences;
    private int sentenceIndex;
    public float typingSpeed;
    public Button continueButton;

    public void TypeDialogueMessage()
    {
        if (sentenceIndex != sentences.Length - 1
            && continueButton.gameObject.activeInHierarchy == false)
        {
            continueButton.gameObject.SetActive(true);
            StartCoroutine(Type());
        }
    }

    public IEnumerator Type()
    {
        foreach (char letter in sentences[sentenceIndex].ToCharArray())
        {
            displayText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    //Called when the dialogue is clicked
    public void NextSentence()
    {
        //If the player has clicked the dialogue and the text is not yet populated increase the typing speed
        if (displayText.text != sentences[sentenceIndex])
        {
            typingSpeed = 0;
            print("HEY");
        }
        //If we have text left to display start typing the next one
        else if (sentenceIndex < sentences.Length - 1 &&
            displayText.text == sentences[sentenceIndex])
        {
            typingSpeed = 0.05f;
            sentenceIndex++;
            displayText.text = "";
            StartCoroutine(Type());
        }
        //We don't have any more sentences to display so close the dialogue window and clear the text element
        else
        {
            displayText.text = "";
            continueButton.gameObject.SetActive(false);
        }
    }
}
