using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.DefaultInputActions;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject ObjectsStatsScreen ,OnPlayUI  , menuScreen,chracterScreen ,creatureScreen;
    GameObject player;
    List<GameObject> gameObjects;
 
   public  enum actions
    {
        escape ,
        clickCreature ,
        clickCharacter
    }

    public enum UI_states
    {
        characterMenu ,
        creatureMenu ,
        MainMenu ,
        NoUI
    }
    static List<actions>InputActions = new List<actions>() {actions.escape ,actions.clickCharacter ,actions.clickCreature };

    static public UI_states currentState;
    static public UI_states nextState;

    static Dictionary<UI_states,List<UI_states>> TransitionTable = new Dictionary<UI_states,List<UI_states>> {

        {UI_states.characterMenu ,new List<UI_states>{ UI_states.MainMenu } },
        {UI_states.creatureMenu ,new List<UI_states>{ UI_states.MainMenu } },
        {UI_states.MainMenu ,new List<UI_states>{ UI_states.NoUI,UI_states.characterMenu ,UI_states.creatureMenu } },
        {UI_states.NoUI ,new List<UI_states>{ UI_states.MainMenu } }
    };

    void Start()
    {


        UiBehavior.menuAction = UIActivity;
       
        OnPlayUI.SetActive(true);

        currentState= UI_states.NoUI;
    }


    public static UI_states NextState(UI_states currentState, actions Input)
    {
        return TransitionTable[currentState][InputActions.IndexOf(Input)];
    }

    private void UIActivity(List<GameObject> arg1, GameObject arg2)
    {
        player = arg2;
        gameObjects = arg1;


        Debug.Log("pressed escape");
        nextState = NextState(currentState, actions.escape);
        currentState = PerformActions(currentState, nextState ,arg1 ,arg2);

    }




    public UI_states PerformActions(UI_states currentState, UI_states nextState, List<GameObject> arg1, GameObject arg2)
    {


        if (currentState == UI_states.NoUI)
        {
            Time.timeScale = 0f;
        }

        if (currentState == UI_states.MainMenu)
        {
            Debug.Log("HELLO");
            menuScreen.SetActive(false);   
        }

        if (currentState == UI_states.creatureMenu)
        {
            creatureScreen
                .SetActive(false);
        }

        if (currentState == UI_states.characterMenu)
        {

            chracterScreen.GetComponent<CharacterTeamScreen>().setScreenActvity(false);
        }

        if (nextState == UI_states.characterMenu)
        {
            Debug.Log("HELLO2");
            chracterScreen.GetComponent<CharacterTeamScreen>().setScreenActvity(true);
        }


        if (nextState == UI_states.creatureMenu)
        {
            chracterScreen
               .SetActive(true);
        }


        if (nextState == UI_states.NoUI)
        {
            Time.timeScale = 1f;
        }

        if (nextState == UI_states.MainMenu)
        {
            

            menuScreen.SetActive(true);

            menuScreen.GetComponent<menu>().enableui(arg1, arg2);
        }

      return nextState;
    }


    public UI_states PerformActions(UI_states currentState, UI_states nextState, GameObject arg2)
    {


        if (currentState == UI_states.NoUI)
        {
            Time.timeScale = 0f;
        }

        if (currentState == UI_states.MainMenu)
        {
            Debug.Log("HELLO");
            menuScreen.SetActive(false);
        }

        if (currentState == UI_states.creatureMenu)
        {
            creatureScreen
                .SetActive(false);
        }

        if (currentState == UI_states.characterMenu)
        {

            chracterScreen.GetComponent<CharacterTeamScreen>().setScreenActvity(false);
            
        }

        if (nextState == UI_states.characterMenu)
        {
            Debug.Log("HELLO2");
            chracterScreen.GetComponent<CharacterTeamScreen>().setScreenActvity(true);
            chracterScreen.GetComponent<CharacterTeamScreen>().GetPLayerGameObject(arg2);


        }


        if (nextState == UI_states.creatureMenu)
        {
            creatureScreen
               .SetActive(true);

            creatureScreen.GetComponent<CreatureMenuScreen>().GetObject(arg2);

        }


        if (nextState == UI_states.NoUI)
        {
            Time.timeScale = 1f;
        }

        if (nextState == UI_states.MainMenu)
        {


            menuScreen.SetActive(true);

            menuScreen.GetComponent<menu>().enableui(gameObjects, player);
        }

        return nextState;
    }

}
