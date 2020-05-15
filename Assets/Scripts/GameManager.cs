using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button[] Buttons;
    public Text NumberTypeText;
    public static string NumberType;
    public static int Score;
    public static int Lives = 3;


    // Start is called before the first frame update
    void Start()
    {
        UpdateNumbers();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Disable()
    {
        for(var button in Buttons)
        {
            button.GetComponent<Image>().color = Color.white;
            button.gameObject.SetActive(false);
        }

        NumberTypeText.text = "";

        // UpdateNumbers method is called after 2 seconds
        Invoke("UpdateNumbers", 2f);
    }

    void UpdateNumbers()
    {
        foreach(int i=0;i<Buttons.Length;++i)
        {
            Buttons[i].GetComponentInChildren<Text>().text = Random.Range(0, 1000).ToString();
            Buttons[i].gameObject.SetActive(true);
        }

        NumberType = Random.Range(0, 2) == 0 ? "Even" : "Odd";
        NumberTypeText.text = NumberType;

        // Disable method is called after 3 seconds
        Invoke("Disable", 3f);
    }
}
