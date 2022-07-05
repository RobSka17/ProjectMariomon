using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BattleHandler : MonoBehaviour
{
    public InputActionAsset inputConfig;

    public Sprite fightBar;
    public Sprite fightText;
    public Sprite itemBar;
    public Sprite itemText;
    public Sprite teamBar;
    public Sprite teamText;
    public Sprite runBar;
    public Sprite runText;

    private GameObject actionBar;
    private GameObject actionBarText;
    private GameObject inventoryMenu;

    public Battle battle;
    public ControlsHandler controlsHandler;

    public GameObject healthBar1;
    public GameObject healthBar2;

    private enum BattleAction
    {
        None,
        Fight,
        Item,
        Team,
        Run
    }

    private int actionHover;

    private bool updatingHover;

    private void Start()
    {
        actionBar = GameObject.FindGameObjectWithTag("ActionBar");
        actionBarText = GameObject.FindGameObjectWithTag("ActionBarText");
        inventoryMenu = GameObject.FindGameObjectWithTag("InventoryMenu");

        actionHover = 1;

        battle = new Battle();
        controlsHandler = new ControlsHandler(inputConfig);
        controlsHandler.PrimaryButtonAction.performed += OnPrimaryButtonPressed;
        controlsHandler.SecondaryButtonAction.performed += OnSecondaryButtonPressed;
        controlsHandler.LeftOnceAction.performed += OnLeftOnce;
        ExecuteEnterPhase(new Pokemon[] { new Psyduck(5), new Psyduck(3) });

        updatingHover = false;

        battle.EnterPokemon(new Psyduck(5), 0);
        battle.EnterPokemon(new Psyduck(5), 2);

        healthBar1.GetComponent<Slider>().minValue = 0;
        healthBar1.GetComponent<Slider>().maxValue = battle.enteredPokemon[0].MaxHP;
        healthBar1.GetComponent<Slider>().value = battle.enteredPokemon[0].CurrentHP;

        healthBar2.GetComponent<Slider>().minValue = 0;
        healthBar2.GetComponent<Slider>().maxValue = battle.enteredPokemon[2].MaxHP;
        healthBar2.GetComponent<Slider>().value = battle.enteredPokemon[2].CurrentHP;
    }

    private void OnLeftOnce(InputAction.CallbackContext obj)
    {
        if(battle.Phase == BattlePhase.ActionSelection)
        {
            if (!updatingHover)
            {
                if (actionHover == 1)
                {
                    updatingHover = true;
                    actionHover = 4;
                    UpdateBattleActionHover();
                }
                else
                {
                    updatingHover = true;
                    actionHover = actionHover - 1;
                    UpdateBattleActionHover();
                }
            }
        }
    }

    private void OnPrimaryButtonPressed(InputAction.CallbackContext obj)
    {
        if(battle.Phase == BattlePhase.ActionSelection)
        {
            SelectBattleAction(actionHover);
        }
    }

    private void OnSecondaryButtonPressed(InputAction.CallbackContext obj)
    {
        if (battle.Phase == BattlePhase.ItemSelection)
        {
            CloseInventory();
        }
    }

    private void Update()
    {
        var gamepad = Gamepad.current;

        if(gamepad != null)
        {
            if (battle.Phase == BattlePhase.ActionSelection)
            {
                if (gamepad.leftStick.left.isPressed || gamepad.dpad.left.isPressed)
                {
                    
                }
                else if (gamepad.leftStick.right.isPressed || gamepad.dpad.right.isPressed)
                {
                    if (!updatingHover)
                    {
                        if (actionHover == 4)
                        {
                            updatingHover = true;
                            actionHover = 1;
                            UpdateBattleActionHover();
                        }
                        else
                        {
                            updatingHover = true;
                            actionHover = actionHover + 1;
                            UpdateBattleActionHover();
                        }
                    }
                }
                else
                {
                    updatingHover = false;
                }
            }
        }        
    }

    public void BattleStart(Pokemon[] battlingPokemon)
    {
        ExecuteEnterPhase(battlingPokemon);
    }

    public void EnterPokemon(Pokemon pokemon)
    {
        print("Sent in " + pokemon.Name);
    }

    public void ExecuteEnterPhase(Pokemon[] enteringPokemon)
    {
        foreach (Pokemon pokemon in enteringPokemon)
        {
            EnterPokemon(pokemon);
        }

        OnEnterPhaseEnd(enteringPokemon);
    }

    private void OnEnterPhaseEnd(Pokemon[] enteredPokemon)
    {
        foreach (Pokemon pokemon in enteredPokemon)
        {
            if (pokemon.Ability.Trigger == AbilityTrigger.Enter)
            {
                pokemon.Ability.Activate(enteredPokemon, battle);
            }
        }

        battle.SetBattlePhase(BattlePhase.ActionSelection);
    }

    private void SelectBattleAction(int actionHover)
    {
        switch(actionHover)
        {
            case 1:
                battle.enteredPokemon[0].Moves[0].Use(battle.enteredPokemon[0], battle, new Pokemon[] { battle.enteredPokemon[2] });
                healthBar2.GetComponent<Slider>().value = battle.enteredPokemon[2].CurrentHP;
                break;
            case 2:
                OpenInventory();
                break;
        }
    }

    private void UpdateBattleActionHover()
    {
        switch(actionHover)
        {
            case 1:
                actionBar.GetComponent<Image>().sprite = fightBar;
                actionBarText.GetComponent<Image>().sprite = fightText;
                break;
            case 2:
                actionBar.GetComponent<Image>().sprite = itemBar;
                actionBarText.GetComponent<Image>().sprite = itemText;
                break;
            case 3:
                actionBar.GetComponent<Image>().sprite = teamBar;
                actionBarText.GetComponent<Image>().sprite = teamText;
                break;
            case 4:
                actionBar.GetComponent<Image>().sprite = runBar;
                actionBarText.GetComponent<Image>().sprite = runText;
                break;
        }
    }

    private void OpenInventory()
    {
        inventoryMenu.GetComponent<Image>().enabled = true;
        foreach(GameObject item in GameObject.FindGameObjectsWithTag("InventoryItem"))
        {
            item.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().enabled = true;
        }
        battle.SetBattlePhase(BattlePhase.ItemSelection);
    }

    private void CloseInventory()
    {
        inventoryMenu.GetComponent<Image>().enabled = false;
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("InventoryItem"))
        {
            item.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().enabled = false;
        }
        battle.SetBattlePhase(BattlePhase.ActionSelection);
    }
}
