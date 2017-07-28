using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class QuestTextManagerLevelTwo : MonoBehaviour {


    public GameObject AnswerButtonPanel;
    public Text QuestText;
    public Text TitleText;
    public static int PlayerScore = QuestTextManager.PlayerScore;
    public Text ShowPlayerScore;

    public static bool LevelTwoReached = true;

    public string LevelTitle = "Maths Castle - Courtyard Escape";
    public string TextForQuestText = "Default - no state set...";


    private bool cupboard = false; 


    public Text AnswerOne;
    public Text AnswerTwo;
    public Text AnswerThree;


    float playerChosenDifficulty = DifficultyScript.DifficultyLevel;


    // enum for quest text states
    private enum States { Basement , Cupboard , CupboardQuestion , Kitchen , Caught , CaughtQuestion, CaughtQuestionWrong , KitchenAfterCupboard , Hallway , HallwayQuestion , Courtyard , EvilMathsGenius , EvilMathsGeniusQuestionOne , EvilMathsGeniusQuestionTwo , EvilMathsGeniusQuestionThree , WinGame };


    private States CurrentState;


    // maths question vars


    public float SumNumberOne;
    public float SumNumberTwo;
    public float IncorrectOne;
    public float IncorrectTwo;
    public float CorrectAnswer;
    string SumOperator;




    public int incorrectSumNumber1;
    public int incorrectSumNumber2;
    public int incorrectSumNumber3;
    public int incorrectSumNumber4;


    public bool GetQuestion = false;


    public Button ButtonOne;
    public Button ButtonTwo;
    public Button ButtonThree;


    // Use this for initialization




    void Awake () {




        TitleText.text = LevelTitle ;
        QuestText.text = TextForQuestText;


        PlayerScore = QuestTextManager.PlayerScore;




    }
    
    // Update is called once per frame
    void Update () {
        
        checkState();
        ShowPlayerScore.text = PlayerScore.ToString();
    }






    private void checkState ()
    {


        switch (CurrentState)
        {
        case States.Basement:
            State_Basement();
                break;               
        case States.Cupboard:
            State_Cupboard();
                break;
        case States.CupboardQuestion:
            State_CupboardQuestion();
                break;
        case States.Kitchen:
            State_Kitchen();
                break;
        case States.Caught:
            State_Caught();
                break;
        case States.CaughtQuestion:
            State_CaughtQuestion();
                break;
        case States.CaughtQuestionWrong:
            State_CaughtQuestionWrong();
                break;
        case States.KitchenAfterCupboard:
            State_KitchenAfterCupboard();
                break;
        case States.Hallway:
            State_Hallway();
                break;
        case States.HallwayQuestion:
            State_HallwayQuestion();
                break;
        case States.Courtyard:
            State_Courtyard();
                break;
        case States.EvilMathsGenius:
            State_EvilMathsGenius();
                break;
        case States.EvilMathsGeniusQuestionOne:
            State_EvilMathsGeniusQuestionOne();
                break;
        case States.EvilMathsGeniusQuestionTwo:
            State_EvilMathsGeniusQuestionTwo();
                break;
        case States.EvilMathsGeniusQuestionThree:
            State_EvilMathsGeniusQuestionThree();
                break;
        case States.WinGame:
            State_WinGame();
                break;
        default: QuestText.text ="Switch Default state text" ;
                break;


            
        }


    }




        






    private void State_Basement()
    {


        QuestText.text = "Freedom! Or not... you emerge from the dungeon to find yourself in the basement. \n\n A large amount of wine bottles line the walls." +
                        "Ahead you can see some light coming from a doorway. You can hear footsteps coming your way. To your left is a small cupboard that you can just about fit inside."+
                        " \n\n Press the C key hide in the cupboard or press the K key to make a dash to the door....";


        if (Input.GetKeyDown(KeyCode.K))
        {
            CurrentState = States.Caught;


        } else if (Input.GetKeyDown(KeyCode.C)){


            CurrentState = States.Cupboard;


            cupboard = true; // reqired to get right state at answerchecker.... 


        }


    }




    private void State_Cupboard()
    {


        QuestText.text = "The cupboard is just big enough for you to fit in. Closing the door behind you try to not make any noise\n\n"+
                        "You hear someone walking past the cupboard. You hear the footsteps heading down to the dungeon. \n\n"+
                        "What if they find you are missing? You had better make a quick escape. Going to open the door you realise its " +
                        "locked. There is a lock on the inside with a number pad! You must answer the question to escape. \n\n" +
                         "Press T to try the question....";


        if (Input.GetKeyDown(KeyCode.T))
        {
            CurrentState = States.CupboardQuestion;
        }
       


    }


    private void State_CupboardQuestion()
    {




        if (!GetQuestion) {


            MakeMathsQuestion (playerChosenDifficulty);


        int buttonNumber = Random.Range(1,4);


            switch (buttonNumber) {
            case 1:
                AnswerOne.text = CorrectAnswer.ToString() ;
                AnswerTwo.text = IncorrectOne.ToString();
                AnswerThree.text = IncorrectTwo.ToString();
            break;
            case 2:
                AnswerOne.text = IncorrectOne.ToString()  ;
                AnswerTwo.text = CorrectAnswer.ToString();
                AnswerThree.text = IncorrectTwo.ToString() ;
            break;
            case 3:
                AnswerOne.text = IncorrectTwo.ToString() ;
                AnswerTwo.text = IncorrectOne.ToString();
                AnswerThree.text = CorrectAnswer.ToString();
            break;
            default:
                break;
            }




        GetQuestion = true;


        }




        if (!AnswerButtonPanel.activeInHierarchy) {
            AnswerButtonPanel.SetActive(true);
            Debug.Log ("AnswerButtonPanel is active");
        }


    


    }


    private void State_Kitchen()
    {
    
        QuestText.text = "That was lucky! You were sure he would kill you! You walk through the doorway and find yourself in a kitchen." +
                    "\n \n There doesn't seem to be much of use in here for you. You grab and apple and eat it quickly. You can't remember the last time you ate." +
                    "\n \n Press H to leave the kitchen and carry on moving forward....";


        if (Input.GetKeyDown(KeyCode.H))
        {
            CurrentState = States.Hallway;
        }
      


    }






    






    private void State_Caught()
    {


        QuestText.text = "As you make a dash for the doorway a guard walks though it. \"Halt!\" he shouts.. you freeze.\n\n" +
                         "The guard speaks to you: \n\n \"If you wish to pass you must answer a question given to me by the evil maths genius that has trapped you here...\"" +
                        "\n\n Press A to attempt the question";




        if (Input.GetKeyDown(KeyCode.A))
        {
            CurrentState = States.CaughtQuestion;
        }
      


    }




    private void State_CaughtQuestion()
    {


        if (!GetQuestion) {


            MakeMathsQuestion(playerChosenDifficulty);


        int buttonNumber = Random.Range(1,4);


            switch (buttonNumber) {
            case 1:
                AnswerOne.text = CorrectAnswer.ToString() ;
                AnswerTwo.text = IncorrectOne.ToString();
                AnswerThree.text = IncorrectTwo.ToString();
            break;
            case 2:
                AnswerOne.text = IncorrectOne.ToString()  ;
                AnswerTwo.text = CorrectAnswer.ToString();
                AnswerThree.text = IncorrectTwo.ToString() ;
            break;
            case 3:
                AnswerOne.text = IncorrectTwo.ToString() ;
                AnswerTwo.text = IncorrectOne.ToString();
                AnswerThree.text = CorrectAnswer.ToString();
            break;
            default:
                break;
            }




        GetQuestion = true;


        }




        if (!AnswerButtonPanel.activeInHierarchy) {
            AnswerButtonPanel.SetActive(true);
            Debug.Log ("AnswerButtonPanel is active");
        }
    }






    private void State_CaughtQuestionWrong()
    {
        QuestText.text = "The guard looks you in the face.. instantly you realise you were wrong... you didn't carry the 42! \n\n " +
            "As quick as a flash the guard kills you with a maths related weapon... \n\n" +
            "Press D to confirm you did not survive the barrage of numbers." ;


        if (Input.GetKeyDown(KeyCode.D))
        {
            Application.LoadLevel("Lose"); 
        }


    }




    private void State_KitchenAfterCupboard()
    {


        QuestText.text = "You unlock and leave the cupboard.  Slowly you make your way to the door and walk though to find yourself in a kitchen.\n\n" +
                        "You grab a piece of bread from the table and scoff it down. You cannot remember when you last ate. \n\n"+
                         "Press H to press on forward to find the way out.";


        if (Input.GetKeyDown(KeyCode.H))
        {
            CurrentState = States.Hallway;
        }


    }




    private void State_Hallway()
    {


        QuestText.text = "The floor in the hallway has three coloured strips of floor tiles. In front of you, at the start of each strip is a number.\n\n" +
                        "At the other end of the hallway you see a question on the wall. Choose the correct strip to walk down or face your doom! \n\n"+
                        "Press P to attempt this unnecessary puzzle.";


        if (Input.GetKeyDown(KeyCode.P))
        {
            CurrentState = States.HallwayQuestion;
        }


    }




    private void State_HallwayQuestion()
    {
        if (!GetQuestion) {


            MakeMathsQuestion (playerChosenDifficulty);


        int buttonNumber = Random.Range(1,4);


            switch (buttonNumber) {
            case 1:
                AnswerOne.text = CorrectAnswer.ToString() ;
                AnswerTwo.text = IncorrectOne.ToString();
                AnswerThree.text = IncorrectTwo.ToString();
            break;
            case 2:
                AnswerOne.text = IncorrectOne.ToString()  ;
                AnswerTwo.text = CorrectAnswer.ToString();
                AnswerThree.text = IncorrectTwo.ToString() ;
            break;
            case 3:
                AnswerOne.text = IncorrectTwo.ToString() ;
                AnswerTwo.text = IncorrectOne.ToString();
                AnswerThree.text = CorrectAnswer.ToString();
            break;
            default:
                break;
            }




        GetQuestion = true;


        }


        if (!AnswerButtonPanel.activeInHierarchy) {
            AnswerButtonPanel.SetActive(true);
            Debug.Log ("AnswerButtonPanel is active");
        }


    }




    private void State_Courtyard()
    {


        QuestText.text = "Running down the correct strip you leave though the door and find yourself in the castle courtyard. "+
                          "The cool and fresh breeze is a welcome change from the cold and damp feeling in the dungeon.\n\n" +
                        "The door slams shut behind you. In front of you is a shadowy figure and beyond the open gates of the castle..." +
                        "Press A to approach the figure....." ;


        if (Input.GetKeyDown(KeyCode.A))
        {
            CurrentState = States.EvilMathsGenius;
        }
    }




    private void State_EvilMathsGenius()
    {


        QuestText.text = "As you approach the shadowy figure you see that they are wearing a cloak covered in numbers... This must be the evil maths genius...\n\n" +
                         "Suddenly the figures hand rise towards you and you stop moving. The evil maths genius begins to speak: \"If you wish to leave alive you must " +
                         "answer three final questions, each more difficult and frustrating than the last.. fail and you will die. Succeed and be free..... \"" +
                          "\n\n C to start this final challenge..... ";


        if (Input.GetKeyDown(KeyCode.C))
        {
            CurrentState = States.EvilMathsGeniusQuestionOne;
        }
    }






    private void State_EvilMathsGeniusQuestionOne()
    {


        if (!GetQuestion) {


            MakeMathsQuestion (playerChosenDifficulty);


        int buttonNumber = Random.Range(1,4);


            switch (buttonNumber) {
            case 1:
                AnswerOne.text = CorrectAnswer.ToString() ;
                AnswerTwo.text = IncorrectOne.ToString();
                AnswerThree.text = IncorrectTwo.ToString();
            break;
            case 2:
                AnswerOne.text = IncorrectOne.ToString()  ;
                AnswerTwo.text = CorrectAnswer.ToString();
                AnswerThree.text = IncorrectTwo.ToString() ;
            break;
            case 3:
                AnswerOne.text = IncorrectTwo.ToString() ;
                AnswerTwo.text = IncorrectOne.ToString();
                AnswerThree.text = CorrectAnswer.ToString();
            break;
            default:
                break;
            }




        GetQuestion = true;


        }


        if (!AnswerButtonPanel.activeInHierarchy) {
            AnswerButtonPanel.SetActive(true);
            Debug.Log ("AnswerButtonPanel is active");
        }


    }


    private void State_EvilMathsGeniusQuestionTwo()
    {


        if (!GetQuestion) {


            MakeMathsQuestion (playerChosenDifficulty);


        int buttonNumber = Random.Range(1,4);


            switch (buttonNumber) {
            case 1:
                AnswerOne.text = CorrectAnswer.ToString() ;
                AnswerTwo.text = IncorrectOne.ToString();
                AnswerThree.text = IncorrectTwo.ToString();
            break;
            case 2:
                AnswerOne.text = IncorrectOne.ToString()  ;
                AnswerTwo.text = CorrectAnswer.ToString();
                AnswerThree.text = IncorrectTwo.ToString() ;
            break;
            case 3:
                AnswerOne.text = IncorrectTwo.ToString() ;
                AnswerTwo.text = IncorrectOne.ToString();
                AnswerThree.text = CorrectAnswer.ToString();
            break;
            default:
                break;
            }




        GetQuestion = true;


        }


        if (!AnswerButtonPanel.activeInHierarchy) {
            AnswerButtonPanel.SetActive(true);
            Debug.Log ("AnswerButtonPanel is active");
        }


    }


    private void State_EvilMathsGeniusQuestionThree()
    {


        if (!GetQuestion) {


            MakeMathsQuestion (playerChosenDifficulty);


        int buttonNumber = Random.Range(1,4);


            switch (buttonNumber) {
            case 1:
                AnswerOne.text = CorrectAnswer.ToString() ;
                AnswerTwo.text = IncorrectOne.ToString();
                AnswerThree.text = IncorrectTwo.ToString();
            break;
            case 2:
                AnswerOne.text = IncorrectOne.ToString()  ;
                AnswerTwo.text = CorrectAnswer.ToString();
                AnswerThree.text = IncorrectTwo.ToString() ;
            break;
            case 3:
                AnswerOne.text = IncorrectTwo.ToString() ;
                AnswerTwo.text = IncorrectOne.ToString();
                AnswerThree.text = CorrectAnswer.ToString();
            break;
            default:
                break;
            }




        GetQuestion = true;


        }


        if (!AnswerButtonPanel.activeInHierarchy) {
            AnswerButtonPanel.SetActive(true);
            Debug.Log ("AnswerButtonPanel is active");
        }


    }
    




    private void State_WinGame()
    {


        QuestText.text = "You look at the evil maths genius after giving your last answer... the figure nods and then steps aside, gesturing towards the open gate..  \n\n"+
                        "Hoping that is all, you start walking towards the gate. The figure laughs and then, in a flash of numbers, vanishes...\n\n"+
                        "Press W to leave this evil castle forever.... ";


        if (Input.GetKeyDown(KeyCode.W))
        {
            Application.LoadLevel("Win");
        }
    }












    #region Question maker


    public void MakeMathsQuestion (float playerChosenDifficulty)
    {


        SumNumberOne = 0.0f;
        SumNumberTwo = 0.0f;
        IncorrectOne = 0.0f;
        IncorrectTwo = 0.0f;


        int chooseOperator;




        switch ((int)playerChosenDifficulty) {
        case 1:
            SumNumberOne = Random.Range (1, 10);
            SumNumberTwo = Random.Range (1, 10);
            incorrectSumNumber1 = Random.Range (1, 10);
            incorrectSumNumber2 = Random.Range (1, 10);
            incorrectSumNumber3 = Random.Range (1, 10);
            incorrectSumNumber4 = Random.Range (1, 10);
            break;               
        case 2:
            SumNumberOne = Random.Range (1, 100);
            SumNumberTwo = Random.Range (1, 100);
            incorrectSumNumber1 = Random.Range (1, 100);
            incorrectSumNumber2 = Random.Range (1, 100);
            incorrectSumNumber3 = Random.Range (1, 100);
            incorrectSumNumber4 = Random.Range (1, 100);           
            break;
        case 3:
            SumNumberOne = Random.Range (1, 500);
            SumNumberTwo = Random.Range (1, 500);
            incorrectSumNumber1 = Random.Range (1, 500);
            incorrectSumNumber2 = Random.Range (1, 500);
            incorrectSumNumber3 = Random.Range (1, 500);
            incorrectSumNumber4 = Random.Range (1, 500);
            break;
        case 4:
            SumNumberOne = Random.Range (1, 1000);
            SumNumberTwo = Random.Range (1, 1000);
            incorrectSumNumber1 = Random.Range (1, 1000);
            incorrectSumNumber2 = Random.Range (1, 1000);
            incorrectSumNumber3 = Random.Range (1, 1000);
            incorrectSumNumber4 = Random.Range (1, 1000);
            break;
        default:
            QuestText.text = "Switch Default state text";
            break;
        }


        // choose random operator


        chooseOperator = Random.Range (1, 5);


        switch (chooseOperator) {
        case 1:


            CorrectAnswer = SumNumberOne + SumNumberTwo;
            IncorrectOne = incorrectSumNumber1 + incorrectSumNumber2;
            IncorrectTwo = incorrectSumNumber3 + incorrectSumNumber4;
            SumOperator = "Plus";
            QuestText.text = "The question is a simple one:\n\n " +SumNumberOne +" "+ SumOperator + " " + SumNumberTwo + " ? ";
            break;               
        case 2:


            CorrectAnswer = SumNumberOne - SumNumberTwo;
            IncorrectOne = incorrectSumNumber1 - incorrectSumNumber2;
            IncorrectTwo = incorrectSumNumber3 - incorrectSumNumber4;
            SumOperator = "Minus";    
            QuestText.text = "The question is a simple one:\n\n " +SumNumberOne +" "+ SumOperator + " " + SumNumberTwo + " ? ";       
            break;
        case 3:


            CorrectAnswer = SumNumberOne * SumNumberTwo;
            IncorrectOne = incorrectSumNumber1 * incorrectSumNumber2;
            IncorrectTwo = incorrectSumNumber3 * incorrectSumNumber4;
            SumOperator = "Times";
            QuestText.text = "The question is a simple one: \n\n" +SumNumberOne +" "+ SumOperator + " " + SumNumberTwo + " ? ";
            break;
        case 4:


            int a = (int) SumNumberOne ;
            int b = (int) SumNumberTwo;
            int c = (int)SumNumberOne * (int)SumNumberTwo;
    


            CorrectAnswer = b ;
            IncorrectOne = incorrectSumNumber2;
            IncorrectTwo = incorrectSumNumber4;
            SumOperator = "Divided by";
            QuestText.text = "The question is a simple one - but remember... round to the closest even number \n\n " + c  +" "+ SumOperator + " " +  a + " ? ";






                break;
        default: QuestText.text ="Switch Default state text" ;
                break;
        }




    }




    #endregion //Question maker






    #region check answer methods


    public void CheckAnwser1 ()
    {


        if (AnswerOne.text == CorrectAnswer.ToString ()) {


            PlayerScore++;
            GetQuestion = false;


            switch (PlayerScore) {
            case 5:
                QuestText.text = "correct! - incorrect state set!";
                Debug.Log ("Button pressed: AnswerOne. AnswerOne.text= " + AnswerOne.text);


                if (cupboard == true) {
                    CurrentState = States.KitchenAfterCupboard;
                } else {
                    CurrentState = States.Kitchen;
                }


                break;
            case 6:
                QuestText.text = "correct! - incorrect state set!";
                   Debug.Log("Button pressed: AnswerOne. AnswerOne.text= " + AnswerOne.text);
                CurrentState = States.Courtyard;
                break;
            case 7:
                QuestText.text = "correct! - incorrect state set!";
                   Debug.Log("Button pressed: AnswerOne. AnswerOne.text= " + AnswerOne.text);
                CurrentState = States.EvilMathsGeniusQuestionTwo;
                break;
            case 8:
                QuestText.text = "correct! - incorrect state set!";
                   Debug.Log("Button pressed: AnswerOne. AnswerOne.text= " + AnswerOne.text);
                CurrentState = States.EvilMathsGeniusQuestionThree;
                break;
            case 9:
                QuestText.text = "correct! - incorrect state set!";
                   Debug.Log("Button pressed: AnswerOne. AnswerOne.text= " + AnswerOne.text);
                CurrentState = States.WinGame;
                break;


            default:
                QuestText.text = "CheckAnswer switch statement failed!";
                break;
            }






            if (AnswerButtonPanel.activeInHierarchy) {
            AnswerButtonPanel.SetActive(false);
            Debug.Log ("AnswerButtonPanel hidden");
            }


        }
        else
        {


            Debug.Log("Lose, Player Score = " + PlayerScore);
            Application.LoadLevel("Lose");


        }


    }




    public void CheckAnwser2()
    {


        if (AnswerTwo.text == CorrectAnswer.ToString())
        {
            PlayerScore ++ ;
            GetQuestion = false;


            switch (PlayerScore) {
            case 5:
                QuestText.text = "correct! - incorrect state set!";
                Debug.Log ("Button pressed: AnswerTwo. AnswerTwo.text= " + AnswerTwo.text);


                if (cupboard == true) {
                    CurrentState = States.KitchenAfterCupboard;
                } else {
                    CurrentState = States.Kitchen;
                }


                break;
            case 6:
                QuestText.text = "correct! - incorrect state set!";
                Debug.Log("Button pressed: AnswerTwo. AnswerTwo.text= " + AnswerTwo.text);
                CurrentState = States.Courtyard;
                break;
            case 7:
                QuestText.text = "correct! - incorrect state set!";
                Debug.Log("Button pressed: AnswerTwo. AnswerTwo.text= " + AnswerTwo.text);
                CurrentState = States.EvilMathsGeniusQuestionTwo;
                break;
            case 8:
                QuestText.text = "correct! - incorrect state set!";
                Debug.Log("Button pressed: AnswerTwo. AnswerTwo.text= " + AnswerTwo.text);
                CurrentState = States.EvilMathsGeniusQuestionThree;
                break;
            case 9:
                QuestText.text = "correct! - incorrect state set!";
                Debug.Log("Button pressed: AnswerTwo. AnswerTwo.text= " + AnswerTwo.text);
                CurrentState = States.WinGame;
                break;


            default:
                QuestText.text = "CheckAnswer switch statement failed!";
                break;
            }


            if (AnswerButtonPanel.activeInHierarchy) {
            AnswerButtonPanel.SetActive(false);
            Debug.Log ("AnswerButtonPanel hidden");
            }


        }
        else
        {


            Debug.Log("Lose, Player Score = " + PlayerScore);
            Application.LoadLevel("Lose");


        }


    }




    public void CheckAnwser3()
    {


        if (AnswerThree.text == CorrectAnswer.ToString())
        {
            PlayerScore ++ ;
            GetQuestion = false;


            switch (PlayerScore) {
            case 5:
                QuestText.text = "correct! - incorrect state set!";
                Debug.Log ("Button pressed: AnswerThree. AnswerThree.text= " + AnswerThree.text);


                if (cupboard == true) {
                    CurrentState = States.KitchenAfterCupboard;
                } else {
                    CurrentState = States.Kitchen;
                }
                break;
            case 6:
                QuestText.text = "correct! - incorrect state set!";
                Debug.Log("Button pressed: AnswerThree. AnswerThree.text= " + AnswerThree.text);
                CurrentState = States.Courtyard;
                break;
            case 7:
                QuestText.text = "correct! - incorrect state set!";
                Debug.Log("Button pressed: AnswerThree. AnswerThree.text= " + AnswerThree.text);
                CurrentState = States.EvilMathsGeniusQuestionTwo;
                break;
            case 8:
                QuestText.text = "correct! - incorrect state set!";
                Debug.Log("Button pressed: AnswerThree. AnswerThree.text= " + AnswerThree.text);
                CurrentState = States.EvilMathsGeniusQuestionThree;
                break;
            case 9:
                QuestText.text = "correct! - incorrect state set!";
                Debug.Log("Button pressed: AnswerThree. AnswerThree.text= " + AnswerThree.text);
                CurrentState = States.WinGame;
                break;


            default:
                QuestText.text = "CheckAnswer switch statement failed!";
                break;
            }


            if (AnswerButtonPanel.activeInHierarchy) {
            AnswerButtonPanel.SetActive(false);
            Debug.Log ("AnswerButtonPanel hidden");
            }


        }
        else
        {


            Debug.Log("Lose , Player Score = " + PlayerScore);
            Application.LoadLevel("Lose");


        }


    }


    #endregion // answer checker methods




}


