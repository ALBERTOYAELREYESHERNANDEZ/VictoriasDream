using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueText : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] lines;
    public float textSpeed = 0.1f;
    int index;

    public void Start()
    {
        dialogueText.text = string.Empty;
        StartDialogue();
    }
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.V) || Input.GetMouseButtonDown(0))
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(dialogueText.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = lines[index];
            }
        }

        //if (Input.GetMouseButtonDown(0))
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LevelLoader.LoadLevel("Nivel");
        }
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(WriteLine());

        
    }


    IEnumerator WriteLine()
    {
        foreach (char letter in lines[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
    }


    public void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(WriteLine());
        }
        else
        {
            gameObject.SetActive(false);
            LevelLoader.LoadLevel("Nivel");
        }
    }
}
