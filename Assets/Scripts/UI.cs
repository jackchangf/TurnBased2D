using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stateText;
    //[SerializeField] private StateController stateController;


    // Start is called before the first frame update
    void Start()
    {
        StateController.onStateChange += UpdateStateTextUI;
        StateController.onBattleOver += UpdateStateTextUIBattleOver;
    }

    private void OnDestroy()
    {
        StateController.onStateChange -= UpdateStateTextUI;
        StateController.onBattleOver -= UpdateStateTextUIBattleOver;

    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateStateTextUI()
    {
        stateText.text = StateController.currentState.GetType().Name;
    }

    private void UpdateStateTextUIBattleOver()
    {
        stateText.text = "Battle Over";
    }

}
