using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button[] Buttons;

    public GameObject Restarter;
    public bool[] ButtonNewPressed;
    
    public bool[] ButtonOldPressed;
    public Text NumberTypeText;
    
    public Text LivesLeftText;

    public Text ScoreText;
    public static string LivesLeft;
    public static string NumberType;

    public static string ScoreCount;
    public static int Score=0;
    public static int Lives = 3;

    bool LifeLost = false;

    bool gameover = false;

    void Restart()
    {
        Restarter.gameObject.SetActive(true);
        if(gameover)
        {
            Restart();
            
        }
    }

    public void Retry(){
        print("retrying");
        gameover = false;
        Lives = 3;
        Score = 0;
        UpdateNumbers();

    }
    public void quit(){
        print("Quiting");
        gameover = false;
        Application.Quit();
    }
    public void OnClick(int num ){
        print("in onclick \n");
        if(!LifeLost)
        {
            ButtonNewPressed[num]=true;
            for(int i=0; i < Buttons.Length; ++i)
            {
                if(ButtonNewPressed[i] && int.Parse(Buttons[i].GetComponentInChildren<Text>().text)%2==0 && NumberTypeText.text == "Even")
                {
                    if(!ButtonOldPressed[i])
                    {
                        Buttons[i].GetComponent<Image>().color = Color.green;
                        Score+=2;
                        ButtonOldPressed[i]=true;
                    }
                    ScoreCount = Score.ToString();
                    ScoreText.text = ScoreCount;

                }    
                else if(ButtonNewPressed[i] && !(int.Parse(Buttons[i].GetComponentInChildren<Text>().text)%2==0) && NumberTypeText.text == "Odd")
                {
                    if(!ButtonOldPressed[i])
                    {
                        Buttons[i].GetComponent<Image>().color = Color.green;
                        Score+=2;
                        ButtonOldPressed[i]=true;
                    }    
                    ScoreCount = Score.ToString();
                    ScoreText.text = ScoreCount;

                }           
                else if(!ButtonNewPressed[i])
                Buttons[i].GetComponent<Image>().color = Color.white;
                else
                {
                    Buttons[i].GetComponent<Image>().color = Color.red;
                    Lives-=1;
                    LivesLeft = Lives.ToString();
                    LivesLeftText.text = LivesLeft;
                    LifeLost = true;
                }
            

            }
        }
        if(Lives==0)
        {
            gameover = true;
            print("dead");
        }

    }
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
        bool blank = true;
        for(int i=0; i < Buttons.Length; ++i)
        {
             if(ButtonNewPressed[i])
             blank = false;           
        }

        if(blank)
        Lives--;
        LivesLeft = Lives.ToString();
        LivesLeftText.text = LivesLeft;
        if(Lives==0)
        {
            gameover = true;
            print("dead");
        }
        
        foreach(var button in Buttons)
        {
            button.GetComponent<Image>().color = Color.white;
            button.gameObject.SetActive(false);
        }

        NumberTypeText.text = "";
         for(int i=0; i < Buttons.Length; ++i)
         {
            ButtonNewPressed[i]=false;
            ButtonOldPressed[i]=false;
         }
        if(gameover)
            Restart();

        // UpdateNumbers method is called after 2 seconds
        Invoke("UpdateNumbers", 2f);
    }

    void UpdateNumbers()
    {
         if(gameover)
            Restart();

        Restarter.gameObject.SetActive(false);

        LifeLost = false;
        for(int i=0; i < Buttons.Length; ++i)
        {
            Buttons[i].GetComponentInChildren<Text>().text = (Random.Range(34, 333)*3).ToString();
            Buttons[i].gameObject.SetActive(true);
        }
       
        NumberType = Random.Range(0, 2) == 0 ? "Even" : "Odd";
        NumberTypeText.text = NumberType;

        LivesLeft = Lives.ToString();
        LivesLeftText.text = LivesLeft;

        ScoreCount = Score.ToString();
        ScoreText.text = ScoreCount;

         

        // Disable method is called after 3 seconds
        Invoke("Disable", 3f);
    }
    
    
    
}

