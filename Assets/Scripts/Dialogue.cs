using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    //public TextMeshProUGUI textDisplay;
    public Image PlayerDialogueImage;
    public Image EnemyDialogueImage;
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
        if (sentences[sentenceIndex].ToLowerInvariant().Equals("sandef"))
        {
            PlayerDialogueImage.sprite = Resources.Load<Sprite>("Sandef/Sandef");
        }
        else if (sentences[sentenceIndex].ToLowerInvariant().Equals("stela"))
        {
            PlayerDialogueImage.sprite = Resources.Load<Sprite>("Stela/Stela");
        }
        else if (sentences[sentenceIndex].ToLowerInvariant().Equals("sandef_and_stela"))
        {
            PlayerDialogueImage.sprite = Resources.Load<Sprite>("Sandef/Sandef");
        }
        else if (sentences[sentenceIndex].ToLowerInvariant().Equals("party_maniac"))
        {
            EnemyDialogueImage.sprite = Resources.Load<Sprite>("Enemies/Elvis_Pixel");
        }
        else if (sentences[sentenceIndex].ToLowerInvariant().Equals("kids"))
        {
            EnemyDialogueImage.sprite = Resources.Load<Sprite>("Enemies/Elvis_Pixel");
        }
        //To not print the speaker we increase sentenceIndex
        sentenceIndex += 1;

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
