using UnityEngine;

public class BtnManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LevelPlus()
    {
        int playerLevel = ScoreManager.GetPlayerLevel();
        playerLevel++;
        ScoreManager.SetPlayerLevel(playerLevel);
    }


    void ExpPlus()
    {

    }
}
