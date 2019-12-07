using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    //public TextMeshProUGUI textDisplay;
    public Image DialogueImage;
    public Text displayText;
    public string[] sentences;
    private int sentenceIndex;
    public float typingSpeed;
    public Button continueButton;
    private int currentSentenceCounter;

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
        //Swtich the image to whoever is speaking
        switch (sentences[sentenceIndex])
        {
            case "Sandef":
                DialogueImage.sprite = Resources.Load<Sprite>("Sandef/Sandef");
                sentenceIndex += 1;
                print("Sandef speaking");
                break;
            case "Stela":
                DialogueImage.sprite = Resources.Load<Sprite>("Stela/Stela");
                sentenceIndex += 1;
                print("Stela speaking");
                break;
            case "Party_Maniac":
                DialogueImage.sprite = Resources.Load<Sprite>("Enemies/Elvis_Pixel");
                sentenceIndex += 1;
                break;
            case "Kids":
                DialogueImage.sprite = Resources.Load<Sprite>("Enemies/Elvis_Pixel");
                sentenceIndex += 1;
                break;
            case "Sandef_And_Stela":
                DialogueImage.sprite = Resources.Load<Sprite>("Sandef/Sandef");
                sentenceIndex += 1;
                break;


            default:
                break;
        }

        //To not print the speaker we increase sentenceIndex
        
        foreach (char letter in sentences[sentenceIndex].ToCharArray())
        {        
            displayText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    //Called when the dialogue is clicked
    public void NextSentence()
    {
        currentSentenceCounter += 1;
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
