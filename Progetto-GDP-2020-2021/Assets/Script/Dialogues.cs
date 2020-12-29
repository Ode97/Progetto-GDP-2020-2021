using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogues : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private List<string> dialogue;
    [SerializeField] private List<string> answers;
    [SerializeField] private Text text;

    [SerializeField] private Button[] buttons;

    [SerializeField] private List<GameObject> beasts;

    [SerializeField] private ScrollRect scrollRect;

    private LevelManagerChimaera levelManagerChimaera;
    private string correctAnswer;

    private void Start(){
        levelManagerChimaera = GetComponent<LevelManagerChimaera>();
    }
    public void ReadNextLine()
    {
        if(dialogue.Count == 0)
        {
            foreach (Button b in buttons)
            {
                b.gameObject.SetActive(false);
            }
            beasts[beasts.Count - 1].SetActive(true);
            return;
        }
        UpdateText(dialogue[0]);
        dialogue.RemoveAt(0);
        ScrollDown();
        Answers();
        
        switch(answers[0])
        {

            case "INT":
                SkillCheck(levelManagerChimaera.actualStats.intelligence, 16);
                break;

            case "DEX":
                SkillCheck(levelManagerChimaera.actualStats.dexterity, 16);
                break;

            case "WIS":
                SkillCheck(levelManagerChimaera.actualStats.wisdom, 16);
                break;
        }

        ScrollDown();
    }

    private void SkillCheck(int val, int threshold)
    {
            answers.RemoveAt(0);
            if(val >= threshold)
            {
                UpdateText(answers[0]);
            }
            answers.RemoveAt(0);
        
    }

    private void Answers(){
        correctAnswer = answers[0];
        answers.RemoveAt(0);
        foreach (Button b in buttons)
        {
            b.GetComponentInChildren<Text>().text = answers[0];
            answers.RemoveAt(0);
        }
        
    }

    public void CheckAnswer(string s)
    {
        UpdateText("<color=green><b>Minerva</b></color>: " + buttons[Convert.ToInt32(s) - 1].GetComponentInChildren<Text>().text);
        if(s == correctAnswer){
            UpdateText("<color=purple><b>Chimaera</b></color>: Correct Answer");
            beasts[0].SetActive(true);
            beasts.RemoveAt(0);
            beasts[0].SetActive(true);
            beasts.RemoveAt(0);
        }else
            UpdateText("<color=purple><b>Chimaera</b></color>: Wrong Answer");

        ReadNextLine();   
    }

    private void UpdateText(string s)
    {
        text.text += s + "\n\n";
    }
    
    private void ScrollDown()
    {
        Canvas.ForceUpdateCanvases();
        scrollRect.verticalNormalizedPosition = 0f;
        Canvas.ForceUpdateCanvases();
    }
}
