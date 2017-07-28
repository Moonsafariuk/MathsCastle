using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
//using Assets.scripts;
using System.Collections.Generic;

public class TextController : MonoBehaviour
{


	// Use this for initialization


    private static string myType = "";


    public Text QuestText; 

    public Text Title;
    private static string gameName = "Maths Castle";

    public Text AnswerOne;
    public Text AnswerTwo;
    public Text AnswerThree;

    public GameObject AnswerButtonPanel;

    public int CorrectAnswer;

    public GameObject optionPanel;

    // enum for quest text states
    private enum States { Wake, Dungeon, Brick, Safe, SafePuzzleWin, SafePuzzleLose, FirstGiveUp, SecondGiveUp };

    private States CurrentState;

	// end initialization

    void Start()
    {

        Title.text = gameName;
       
      //  TogglePanel(AnswerButtonPanel);
      //  TogglePanel(optionPanel);
        
        //call start state
        CurrentState = States.Wake;
        optionPanel.GetComponent<Renderer>().enabled = false;
		checkState();



    } // end void start

    // Update is called once per frame
    void Update()
    {
        
        checkState();
	 } //update function

    #region state functions

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
            case States.SafePuzzleLose:
                break;
            case States.FirstGiveUp:
                break;
            case States.SecondGiveUp:
                break;
		default: QuestText.text ="Switch Default state text" ;
                break;
        }

	}

  
    private void State_Wake()
    {

        QuestText.text = "Waking up in the cell you have to PRESS S";

        if (Input.GetKeyDown(KeyCode.S))
        {
            CurrentState = States.Dungeon;

        }

    }


    private void State_Dungeon()
    {

        QuestText.text = "NOW YOU ARE AWAKE PRESS B TO GO TO THE BRICK OR PRESS D TO DIEEEEE";

        if (Input.GetKeyDown(KeyCode.B))
        {
            CurrentState = States.Brick;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            CurrentState = States.FirstGiveUp;
        }

    }

   // private MyClasses.MyQuestion makeQuesAndAnsList()
   // {

       // MyClasses.MyQuestion retVal = new MyClasses.MyQuestion();

       // MyClasses.MyAnswerList possAnsList = new MyClasses.MyAnswerList();

       // List<MyClasses.MyAnswer> ansList = new List<MyClasses.MyAnswer>();

     //   for (int i = 0; i < 2; i++)
      //  {
      //      MyClasses.MyAnswer z = new MyClasses.MyAnswer("2");
      //      if (i==1)
     //       {
     //           z.IsCorrectQ = true;
      //      }
      //      ansList.Add(z);
      //  }
    //    possAnsList.AnswersPoss = ansList;

//        return (retVal);
 //   }

    //private MyClasses.MyQuestion makeMyQuestion(string qType)
    //{
    //    MyClasses.MyQuestion retVal = makeQuesAndAnsList();

    //    switch (qType)
    //    {
    //        case ("brick"):
    //            QuestText.text = "You walk over to the brick. The floor is slimey and cold on your bear feet. The brick could eaisly be pulled " +
    //        "out. \n \n Removing the brick you see a small safe with some numbers on the front. This my be the only chance " +
    //        "escape. \n \n Press E to examine the safe or press G to give up and accept your fate.";
    //            retVal.QuestionText = QuestText.text;
    //            if (Input.GetKeyDown(KeyCode.E))
    //            {
    //                CurrentState = States.Safe;
    //            }
    //            else if (Input.GetKeyDown(KeyCode.G))
    //            {
    //                CurrentState = States.SecondGiveUp;
    //            }
    //            break;
    //        case ("safe"):
    //            int RandomNo1 = 2;
    //            int RandomNo2 = 5;
    //            string CharOperator = "+";
    //            MyClasses.MyQuestion mQ = new MyClasses.MyQuestion();
    //            mQ.QuestionText = "The safe has a simple keypad numbered 0 to 9 \n Above the number pad is a simple question. Prehaps the " +
    //            "answer to the question will open the safe? \n\n The questions is: " + RandomNo1 + " " + CharOperator + " " + RandomNo2;
    //            //StateText.text

    //            //CorrectAnswer = MathSum(RandomNo1, RandomNo2, CharOperator);
    //            //mQ.AnsCorrect = MathSum(RandomNo1, RandomNo2, CharOperator);

    //            //StateText.text = "The safe has a simple keypad numbered 0 to 9 \n Above the number pad is a simple question. Prehaps the " +
    //            //"answer to the question will open the safe? \n\n The questions is: " + RandomNo1 + " " + CharOperator + " " + RandomNo2;

    //            AnswerOne.text = CorrectAnswer.ToString();
    //            AnswerTwo.text = 213.ToString();
    //            AnswerThree.text = "234";

    //            if (!AnswerButtonPanel.activeInHierarchy)
    //            {
    //                TogglePanel(AnswerButtonPanel);
    //            }

    //            break;
    //        case ("wake"):
    //            retVal.QuestionText = "\n You awake..... \n The room is dark and cold.....  \n After a few moments you realise you are inside " +
    //                    "the castle - in what seems to be the dungeon. There are chains hanging from the wall and bars on the " +
    //                    " small windows. \n To the side of the room there is a large wooden door. \n Press the s key to stand up....";


    //            break;
    //        case ("dung"):
    //            retVal.QuestionText = QuestText.text = "You stand up... touching the back of your heard hurts. You must have been knocked out. \n" +
    //    "Looking around the room you see only instruments of torture and pain. Is this what lies " +
    //    "in store for you? \n A brick protruding from the wall catches your eye. \n\n" +
    //    " Press B to check out the brick.\n Press D to lie back down on the floor and accept you fate. ";



    //            break;
    //        default:
    //            break;
    //    }

    //    return (retVal);
    //}

    private void State_Brick()
    {
    
        QuestText.text = "You walk over to the brick. The floor is slimey and cold on your bear feet. The brick could eaisly be pulled " +
                    "out. \n \n Removing the brick you see a small safe with some numbers on the front. This my be the only chance " +
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



    private void State_Safe()
    {

  //      MyClasses.MyQuestion mQ = makeMyQuestion("safe");
        //int RandomNo1 = 2;
        //int RandomNo2 = 5;
        //string CharOperator = "+";
        //MyQuestion mQ = new MyQuestion();
        //mQ.QuestionText = "The safe has a simple keypad numbered 0 to 9 \n Above the number pad is a simple question. Prehaps the " +
        //"answer to the question will open the safe? \n\n The questions is: " + RandomNo1 + " " + CharOperator + " " + RandomNo2;
        ////StateText.text

        ////CorrectAnswer = MathSum(RandomNo1, RandomNo2, CharOperator);
        //mQ.AnsCorrect = MathSum(RandomNo1, RandomNo2, CharOperator);

        ////StateText.text = "The safe has a simple keypad numbered 0 to 9 \n Above the number pad is a simple question. Prehaps the " +
        ////"answer to the question will open the safe? \n\n The questions is: " + RandomNo1 + " " + CharOperator + " " + RandomNo2;

        //AnswerOne.text = CorrectAnswer.ToString();
        //AnswerTwo.text = 213.ToString();
        //AnswerThree.text = "234";

        //if (!AnswerButtonPanel.activeInHierarchy)
        //{
        //    TogglePanel(AnswerButtonPanel);
        //}

    }



    private void State_SafePuzzleWin()
    {

        QuestText.text = "Well that was easy you think to yourself. Opening the safe you find a small rusty key \n";

        if (AnswerButtonPanel.activeInHierarchy)
        {
            TogglePanel(AnswerButtonPanel);
        }

    }



    private void State_FirstGiveUp()
    {

        QuestText.text = "State_FirstGiveUp";

    }



    private void State_SecondGiveUp()
    {

        QuestText.text = " State_SecondGiveU";

    }


    //	private void State_SafePuzzleLose () {

    //		SceneManager.LoadScene(2);
    //		StateText.text =" The safe explodes... You die.. Lol" ;

    //	}

    #endregion

    public int MathSum(int n1, int n2, string MathsOperator)
    {
        if (MathsOperator == "+")
        {
            return n1 + n2;
        }
        else if (MathsOperator == "x")
        {
            return n1 * n2;
        }
        else
        {
            return n1 - n2;
        }



    }


    public void TogglePanel(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);

    }


    public void OptionsPanelToggle(GameObject panelToShow, GameObject panelToHide)
    {

        panelToShow.SetActive(!panelToShow.activeSelf);

        panelToHide.SetActive(!panelToHide.activeSelf);
    }

    public void CheckAnwser1()
    {

        if (AnswerOne.text == CorrectAnswer.ToString())
        {
            QuestText.text = "correct!";
            Debug.Log("Button pressed: AnswerOne. AnswerOne.text= " + AnswerOne.text);
            CurrentState = States.SafePuzzleWin;
        }
        else
        {

            Debug.Log(AnswerOne.text);
            CurrentState = States.SafePuzzleLose;
            Application.LoadLevel("Lose");

        }

    }


    public void CheckAnwser2()
    {

        if (AnswerTwo.text == CorrectAnswer.ToString())
        {
            QuestText.text = "correct!";
            Debug.Log("Button pressed: AnswerTwo. AnswerTwo.text= " + AnswerTwo.text);
            CurrentState = States.SafePuzzleWin;
        }
        else
        {

            Debug.Log("Lose");
            //		CurrentState = States.SafePuzzleLose;
            Application.LoadLevel("Lose");

        }

    }


    public void CheckAnwser3()
    {

        if (AnswerThree.text == CorrectAnswer.ToString())
        {
            QuestText.text = "correct!";
            Debug.Log("Button pressed: AnswerThree. AnswerThree.text= " + AnswerThree.text);
            CurrentState = States.SafePuzzleWin;
        }
        else
        {

            Debug.Log("Lose");
            //		CurrentState = States.SafePuzzleLose;
            Application.LoadLevel("Lose");

        }

    }







} // end of -  public class TextController : MonoBehaviour

