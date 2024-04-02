using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI TextMeshProUGUI;
    public PlayerInput PlayerInput;
    public GameObject Objective;
    public string[] line;
    public float textSpeed;

    public bool ObjectiveActive = true;
    private int index;
    private InputAction activeAction;
    
    private void Awake()
    {
        activeAction = PlayerInput.actions["Fire"];
        TextMeshProUGUI.text = string.Empty;
        startDialogue();
        ObjectiveActive = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (activeAction.triggered)
        {
            if (TextMeshProUGUI.text == line[index])
            {                
                nextLines();
            }
            else
            {
                StopAllCoroutines();
                TextMeshProUGUI.text = line[index];
            }
        }
    }
    private void startDialogue()
    {
        index = 0;
        StartCoroutine(typeLine());
    }

    private void nextLines()
    {
        if (index < line.Length - 1)
        {
            index++;
            TextMeshProUGUI.text = string.Empty;
            StartCoroutine(typeLine());
        }
        else
        {
            TextMeshProUGUI.text = string.Empty;
            gameObject.SetActive(false);            
            Objective.SetActive(ObjectiveActive);
            
        }
    }
    IEnumerator typeLine()
    {
        foreach (char c in line[index].ToCharArray())
        {
            TextMeshProUGUI.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
