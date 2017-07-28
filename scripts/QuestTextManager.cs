using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class QuestTextManager: MonoBehaviour {


    public GameObject AnswerButtonPanel;
    public Text QuestText;
    public Text TitleText;
    public static int PlayerScore;
    public Text ShowPlayerScore;

    public static bool LevelTwoReached = false;

    public string LevelTitle = "Maths Castle";
    public string TextForQuestText = "Default - no state set...";

    public Text AnswerOne;
    public Text AnswerTwo;
    public Text AnswerThree;


    float playerChosenDifficulty = DifficultyScript.DifficultyLevel;


    // enum for quest text states
    private enum States { Wake, Dungeon, Brick, Safe, SafePuzzleWin, FirstGiveUp, SecondGiveUp,DungeonWithKey, KeyPuzzleWin,DoorWayPuzzleOne, DoorWayPuzzleOneSuccess, DoorWayPuzzleTwo, DoorWayPuzzleTwoSuccess };


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




    void Start () {


        AnswerOne.text = "Hello";
        AnswerTwo.text = "World";
        AnswerThree.text = "Let's Play";


        TitleText.text = LevelTitle ;
        QuestText.text = TextForQuestText;


        PlayerScore = 0;




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
            case States.Wake:
                State_Wake();
                break;               
            case States.Dungeon:
                State_Dungeon();
                break;
            case States.Brick:
                State_Brick();
                break;
            case States.Safe:
                State_Safe();
                break;
            case States.SafePuzzleWin:
                State_SafePuzzleWin();
                break;
            case States.FirstGiveUp:
                State_FirstGiveUp();
                break;
            case States.SecondGiveUp:
                State_SecondGiveUp();
                break;
            case States.DungeonWithKey:
                State_DungeonWithKey();
                break;
             case States.KeyPuzzleWin:
                 State_KeyPuzzleWin();
                break;
             case States.DoorWayPuzzleOne:
                State_DoorWayPuzzle();
                break;
            case States.DoorWayPuzzleOneSuccess:
                State_DoorWayPuzzleOneSuccess();
                break;
            case States.DoorWayPuzzleTwo:
                State_DoorWayPuzzleTwo();
                break;
            case States.DoorWayPuzzleTwoSuccess:
                State_DoorWayPuzzleTwoSuccess();
                break;
        default: QuestText.text ="Switch Default state text" ;
                break;


            
        }


    }








    private void State_Wake()
    {


        QuestText.text = "In the distance you hear laughing... \n\nYou knew you should never have trusted anyone who " +
                        "called themselves an evil maths genius! \n\n Your head hurts and you realise you are in the castle's dungeon"+
                        " It is cold, dark and windy. \n\n Press the S key to stand up....";


        if (Input.GetKeyDown(KeyCode.S))
        {
            CurrentState = States.Dungeon;


        }


    }




    private void State_Dungeon()
    {


        QuestText.text = "Standing up in the cell you have a look around. The door is shut and has a number of locks on it.\n\n"+
                        "You sport a brick poking out from the wall. Perhaps moving it will reveal a secret passage. \n\n"+
                        "Press B to have a closer look at the brick or press D to give up and accept your fate...";


        if (Input.GetKeyDown(KeyCode.B))
        {
            CurrentState = States.Brick;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            CurrentState = States.FirstGiveUp;
        }


    }


    private void State_Brick()
    {
    
        QuestText.text = "You walk over to the brick. The floor is slimy and cold on your bare feet. The brick could easily be pulled " +
                    "out. \n \n Removing the brick you see a small safe with some numbers on the front. This could be my only chance of " +
                    "escape. \n \n Press E to examine the safe or press G to give up and accept your fate.";


        if (Input.GetKeyDown(KeyCode.E))
        {
            CurrentState = States.Safe;
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            CurrentState = States.SecondGiveUp;
        }


    }






    private void State_Safe ()
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






    private void State_SafePuzzleWin()
    {


        QuestText.text = "Well that was easy you think to yourself. Opening the safe you find a small rusty key. \n\n" +
                         "You look to the prison cell door and see three locks. Approaching the locks you realise this is " +
            "another maths question. \n\n The key fits in only one lock. The incorrect lock means death. \n\n Press L to attempt the question";




        if (Input.GetKeyDown(KeyCode.L))
        {
            CurrentState = States.DungeonWithKey;
        }
      


    }




    private void State_DungeonWithKey()
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


    private void State_KeyPuzzleWin ()
    {
        QuestText.text = "Well that was easy you think to yourself. Opening the door to the cell.. you leave... \n\n " +
            "You now find yourself in the corridor. There are three open doorways in front of you. \n\n" +
            "Each doorway has number painted on the floor in front of it. Above the doorways there is a question.\n\n"+
            "Press T to step forward and try this evil puzzle. \n\n Choosing the wrong door leads to certain doom." ;


        if (Input.GetKeyDown(KeyCode.T))
        {
            CurrentState = States.DungeonWithKey;
        }


    }




    private void State_DoorWayPuzzle()
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


    }


    private void State_DoorWayPuzzleOneSuccess()
    {


        QuestText.text = "Walking though the correct door your breathe a short sigh of relief.. \n\n You quickly realise that there is another set of doors in front of you. " +
            "You must choose the correct door again or face certain doom! \n\n Press T to try the next fiendish question.";


        if (Input.GetKeyDown(KeyCode.T))
        {
            CurrentState = States.DungeonWithKey;
        }


    }


    private void State_DoorWayPuzzleTwo()
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


    }


    private void State_DoorWayPuzzleTwoSuccess()
    {


        QuestText.text = "Well done! You have escaped the prison cell...\n\n"+
                        "To leave the cell and venture forth press T";


        if (Input.GetKeyDown(KeyCode.T))
        {
            Application.LoadLevel("LevelTwo");;
        }
    }


    




    private void State_FirstGiveUp()
    {


        QuestText.text = "You lie back down on the floor unwilling to participate in this sick and cruel game... \n\n"+
        "After a few hours of quiet... a person appears.... you are too weak to defend yourself and die a horrific "+
            "maths related death.\n \n Press F to confirm you are dead.";
        if (Input.GetKeyDown(KeyCode.F))
        {
            Application.LoadLevel("Lose");
        }
    }






    private void State_SecondGiveUp()
    {


        QuestText.text = "Good choice... maths is quite hard anyway.. you wouldn't want to use your brain to survive. You sit back down on the floor.\n\n "+
        "After a few hours of quiet... a person appears.... you are too weak to defend yourself and die a horrific "+
            "maths related death. \n\n Press F to confirm you are dead.";
        if (Input.GetKeyDown(KeyCode.F))
        {
            Application.LoadLevel("Lose");
        }
    }






    #region Question maker


    public void MakeMathsQuestion (float playerChosenDifficulty)
    {


        SumNumberOne = 0.00f;
        SumNumberTwo = 0.00f;
        IncorrectOne = 0.00f;
        IncorrectTwo = 0.00f;


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




//    public void removeZero (float a, float b, int c, int d , int e , int f)
//    {
//
//        if (a == 0 || b == 0 || c == 0 || d == 0 || e == 0 || f == 0) {
//              a ++ ;
//              b ++ ;
//              c ++ ;
//            d ++ ;
//            e ++ ;
//            f ++ ;
//              
//          }
//
//    }




    #region check answer methods


    public void CheckAnwser1()
    {


        if (AnswerOne.text == CorrectAnswer.ToString())
        {


            PlayerScore ++ ;
            GetQuestion = false;


            switch (PlayerScore) {
            case 1:
                QuestText.text = "correct! - incorrect state set!";
                   Debug.Log("Button pressed: AnswerOne. AnswerOne.text= " + AnswerOne.text);
                CurrentState = States.SafePuzzleWin;
                break;
            case 2:
                QuestText.text = "correct! - incorrect state set!";
                   Debug.Log("Button pressed: AnswerOne. AnswerOne.text= " + AnswerOne.text);
                CurrentState = States.KeyPuzzleWin;
                break;
            case 3:
                QuestText.text = "correct! - incorrect state set!";
                   Debug.Log("Button pressed: AnswerOne. AnswerOne.text= " + AnswerOne.text);
                CurrentState = States.DoorWayPuzzleOneSuccess;
                break;
            case 4:
                QuestText.text = "correct! - incorrect state set!";
                   Debug.Log("Button pressed: AnswerOne. AnswerOne.text= " + AnswerOne.text);
                CurrentState = States.DoorWayPuzzleTwoSuccess;
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
            case 1:
                QuestText.text = "correct! - incorrect state set!";
                   Debug.Log("Button pressed: AnswerTwo. AnswerTwo.text= " + AnswerTwo.text);
                CurrentState = States.SafePuzzleWin;
                break;
            case 2:
                QuestText.text = "correct!  - incorrect state set!";
                Debug.Log("Button pressed: AnswerTwo. AnswerTwo.text= " + AnswerTwo.text);
                CurrentState = States.KeyPuzzleWin;
                break;
            case 3:
                QuestText.text = "correct! - incorrect state set!";
                   Debug.Log("Button pressed: AnswerOne. AnswerOne.text= " + AnswerOne.text);
                CurrentState = States.DoorWayPuzzleOneSuccess;
                break;
            case 4:
                QuestText.text = "correct! - incorrect state set!";
                   Debug.Log("Button pressed: AnswerOne. AnswerOne.text= " + AnswerOne.text);
                CurrentState = States.DoorWayPuzzleTwoSuccess;
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
            case 1:
                QuestText.text = "correct! - incorrect state set!";
                Debug.Log("Button pressed: AnswerThree. AnswerThree.text= " + AnswerThree.text);
                CurrentState = States.SafePuzzleWin;
                break;
            case 2:
                QuestText.text = "correct!  - incorrect state set!";
                Debug.Log("Button pressed: AnswerThree. AnswerThree.text= " + AnswerThree.text);
                CurrentState = States.KeyPuzzleWin;
                break;
            case 3:
                QuestText.text = "correct! - incorrect state set!";
                   Debug.Log("Button pressed: AnswerOne. AnswerOne.text= " + AnswerOne.text);
                CurrentState = States.DoorWayPuzzleOneSuccess;
                break;
            case 4:
                QuestText.text = "correct! - incorrect state set!";
                   Debug.Log("Button pressed: AnswerOne. AnswerOne.text= " + AnswerOne.text);
                CurrentState = States.DoorWayPuzzleTwoSuccess;
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


