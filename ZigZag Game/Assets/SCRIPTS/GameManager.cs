using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;

    [SerializeField] TextMeshProUGUI scoreText;

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene(0);
        BallMovementController.isFloor = true;
    }

}
