using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogues : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private List<string> dialogue;
    [SerializeField]private List<string> answers;
    [SerializeField]private Text text;

    [SerializeField]private Button[] buttons;

    [SerializeField]private List<GameObject> beasts;

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
            beasts[0].SetActive(true);
            return;
        }
        text.text += dialogue[0] + "\n\n";
        dialogue.RemoveAt(0);
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
            
    }

    private void SkillCheck(int val, int threshold)
    {
            answers.RemoveAt(0);
            if(val >= threshold)
            {
                text.text += answers[0] + "\n\n";
            }
            answers.RemoveAt(0);
        
    }

    public void Answers(){
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
        if(s == correctAnswer){
            text.text += "Chimaera: Correct Answer\n\n";
            beasts[0].SetActive(true);
            beasts.RemoveAt(0);
            beasts[0].SetActive(true);
            beasts.RemoveAt(0);
        }else
            text.text += "Chimaera: Wrong Answer\n\n";

        ReadNextLine();   
    }
}
