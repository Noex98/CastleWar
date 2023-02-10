using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public int player1Hearts = 3;
    public int player2Hearts = 3;
    public int player3Hearts = 3;
    public int player4Hearts = 3;
    public int team1Hearts = 6;
    public int team2Hearts = 6;

    public Text player1HeartDisplay;
    public Text player2HeartDisplay;
    public Text player3HeartDisplay;
    public Text player4HeartDisplay;
    public Text team1HeartDisplay;
    public Text team2HeartDisplay;

    private void Start()
    {
        UpdateHeartDisplay();
    }

    public void RemoveHeart(int playerNumber)
    {
        switch (playerNumber)
        {
            case 1:
                player1Hearts--;
                team1Hearts--;
                break;
            case 2:
                player2Hearts--;
                team1Hearts--;
                break;
            case 3:
                player3Hearts--;
                team2Hearts--;
                break;
            case 4:
                player4Hearts--;
                team2Hearts--;
                break;
        }
        UpdateHeartDisplay();
    }

    private void UpdateHeartDisplay()
    {
        player1HeartDisplay.text = player1Hearts.ToString();
        player2HeartDisplay.text = player2Hearts.ToString();
        player3HeartDisplay.text = player3Hearts.ToString();
        player4HeartDisplay.text = player4Hearts.ToString();
        team1HeartDisplay.text = team1Hearts.ToString();
        team2HeartDisplay.text = team2Hearts.ToString();
    }
}