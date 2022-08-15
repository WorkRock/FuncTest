using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnManager : MonoBehaviour
{
    public void ExpPlus()
    {
        int Exp = ScoreManager.GetExp();
        Exp += 1000;
        ScoreManager.SetExp(Exp);
    }

    public void CoinPlus()
    {
        int Coin = ScoreManager.GetCoin();
        Coin += 10000;
        ScoreManager.SetCoin(Coin);
    }

    public void goIngame()
    {
        SceneManager.LoadScene("Ingame");
    }

   
}
