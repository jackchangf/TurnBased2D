using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stateText;
    [SerializeField] private StateController stateController;


    // Start is called before the first frame update
    void Start()
    {
        stateController.onStateChange += UpdateStateTextUI;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateStateTextUI()
    {
        stateText.text = stateController.currentState.GetType().Name;
    }

    private void OnDestroy()
    {
        stateController.onStateChange -= UpdateStateTextUI;

    }
}
