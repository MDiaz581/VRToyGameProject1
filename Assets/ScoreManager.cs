using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshPro ScoreText;
    public float score;


    public void Update()
    {
        ScoreText.text = "Score: " + score.ToString("F0");
    }

}
