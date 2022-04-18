using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public static bool GameStarted=false;
    public static Transform StartPosition;
    public static GameObject Player;
    public static Ui UiManager;
    

    void Start () {
        if (instance == null) {
            instance = this; 
        } else if(instance == this){ 
            Destroy(gameObject); 
        }
        
        Initialization();
        DontDestroyOnLoad(gameObject);
    }

    public void Initialization()
    {
        Player = GameObject.FindWithTag("Player");
        StartPosition = GameObject.FindWithTag("StartPosition").transform;
        UiManager = GameObject.FindWithTag("UI").GetComponent<Ui>();
    }

    public static void Reload(bool win, float time, float distance)
    {
        GameStarted = false;
        Player.transform.position = StartPosition.position;
        UiManager.OpenResultsScreen(win,time,distance);
        Player.GetComponent<Movement>().Distance = 0f;
        Player.GetComponent<Movement>().Timer = 0f;
    }

    public static void StartGame()
    {
        GameStarted = true;
        UiManager.CloseScreens();
        Player.GetComponent<Movement>().InitializePlayerTracking();
    }
}
