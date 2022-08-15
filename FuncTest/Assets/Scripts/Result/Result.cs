using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    [SerializeField] Text lastStage;
    [SerializeField] Text BestStage;
    [SerializeField] Text GetExp;
    [SerializeField] Text GetCoin;
    private int stage;
    private int BStage;

    [Header("Player_GetExp")]
    public int Player_GetExp_TotalExp;
    [Space(10f)]
    public int PlayerGetExp_BasicDef;
    public int PlayerGetExp_BasicPlus;
    [Space(10f)]
    public int PlayerGetExp_EditDef;
    public int PlayerGetExp_EditPlus;
    [Space(10f)]
    public int PlayerGetExp_BasicCor;
    public int PlayerGetExp_EditCor;
    [Space(10f)]
    public int Player_GetExp_Max;

    [Header("Player_GetCoin")]
    public int Player_GetCoin_TotalCoin;
    [Space(10f)]
    public int PlayerGetCoin_BasicDef;
    public int PlayerGetCoin_BasicPlus;
    [Space(10f)]
    public int PlayerGetCoin_EditDef;
    public int PlayerGetCoin_EditPlus;
    [Space(10f)]
    public int PlayerGetCoin_BasicCor;
    public int PlayerGetCoin_EditCor;
    [Space(10f)]
    public int Player_GetCoin_Max;

    // Start is called before the first frame update
    void Start()
    {
        stage = ScoreManager.GetStage();
        
        bStageCal();

        BStage = ScoreManager.GetBStage();

        Player_GetExp_TotalExp = PlayerGetExp_BasicDef;
        Player_GetCoin_TotalCoin = PlayerGetCoin_BasicDef;
        
        for(int i = 1; i <= stage; i++)
        {
            totalGetExpCal(i);
            totalGetCoinCal(i);
        }
        
        lastStage.text = stage.ToString();
        BestStage.text = BStage.ToString();
        GetExp.text = Player_GetExp_TotalExp.ToString();
        GetCoin.text = Player_GetCoin_TotalCoin.ToString();


        int coin = ScoreManager.GetCoin();
        int exp = ScoreManager.GetExp();
        
        coin += Player_GetCoin_TotalCoin;
        exp += Player_GetExp_TotalExp;

        ScoreManager.SetCoin(coin);
        ScoreManager.SetExp(exp);
    }

    void totalGetExpCal(int _stage)
    {
        if(_stage == 1)
            return;

        Player_GetExp_TotalExp += ScoreManager.totalIntFormula(_stage-1, PlayerGetExp_BasicPlus, PlayerGetExp_BasicCor, PlayerGetExp_EditDef, PlayerGetExp_EditPlus, PlayerGetExp_EditCor);

        if(Player_GetExp_TotalExp >= Player_GetExp_Max)
            Player_GetExp_TotalExp = Player_GetExp_Max;
    }

    void totalGetCoinCal(int _stage)
    {
        if(_stage == 1)
            return;

        Player_GetCoin_TotalCoin += ScoreManager.totalIntFormula(_stage-1, PlayerGetCoin_BasicPlus, PlayerGetCoin_BasicCor, PlayerGetCoin_EditDef, PlayerGetCoin_EditPlus, PlayerGetCoin_EditCor);

        if(Player_GetCoin_TotalCoin >= Player_GetCoin_Max)
            Player_GetCoin_TotalCoin = Player_GetCoin_Max;
    }

    void bStageCal()
    {
        int bStage = ScoreManager.GetBStage();
        if(bStage < stage)
        {
            bStage = stage;
            ScoreManager.SetBStage(bStage);
        }
    }

    public void goIngame()
    {
        ScoreManager.SetStage(1);
        SceneManager.LoadScene("Ingame");
    }

    public void goLobby()
    {
        ScoreManager.SetStage(1);
        SceneManager.LoadScene("Lobby");
    }
}
