using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui : MonoBehaviour
{
    [SerializeField]
    private GameObject _menuScreen;
    [SerializeField]
    private GameObject _resultsScreen;
    [SerializeField]
    private TMPro.TMP_Text _winLabel; 
    [SerializeField]
    private TMPro.TMP_Text _distanceLabel; 
    [SerializeField]
    private TMPro.TMP_Text _timeLabel;
    
    public void OpenMainScreen()
    {
        _menuScreen.SetActive(true);
        _resultsScreen.SetActive(false);
    }
    public void CloseScreens()
    {
        _menuScreen.SetActive(false);
        _resultsScreen.SetActive(false);
    }
    public void OpenResultsScreen(bool win, float time, float distance)
    {
        _menuScreen.SetActive(false);
        _resultsScreen.SetActive(true);
        _winLabel.gameObject.SetActive(true);
        _distanceLabel.text = distance.ToString();
        _timeLabel.text = time.ToString();
        if (win)
        {
            _winLabel.text = "You Win!";
        }
        else
        {
            _winLabel.text = "You Lose!";
        }
    }
}
