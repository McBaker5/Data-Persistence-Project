using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] InputField input;
    [SerializeField] Text hiScoreText;
    // Start is called before the first frame update
    void Start()
    {
        hiScoreText.text = "HI SCORE\n" + MemoryManager.Instance.hiScoreName + " : " + MemoryManager.Instance.hiScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeName()
    {
        string name = input.text;
        MemoryManager.Instance.name = name;
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // Original code to quit unity player
#endif
    }
}
