using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    [Header("PlayerInfo")]
    protected int exp = 0;
    protected int coin = 0;
    protected int atkUG = 1;
    protected int playerLevel = 1;

    protected int playerHP;

    protected float playerTotalAtk;

    protected float shieldCT;

    protected bool isLobby = false;
    protected bool isSoundOn = true;
    
    
    [Header("Stage")]
    protected int Stage = 1;
    protected int bStage;
    // Start is called before the first frame update

    public ScoreManager()
    {
        // Debug.Log("게임 매니저 초기화");
        // 초기화
    }

    public static int GetExp()
    {
        return GetInstance().exp;
    }

    public static int GetCoin()
    {
        return GetInstance().coin;
    }

     public static int GetAtkUG()
    {
        return GetInstance().atkUG;
    }

    public static int GetPlayerLevel()
    {
       return GetInstance().playerLevel;
    }

    public static int GetBStage()
    {
       return GetInstance().bStage;
    }

    public static int GetStage()
    {
       return GetInstance().Stage;
    }

    public static float GetPlayerTotalAtk()
    {
        return GetInstance().playerTotalAtk;
    }

    public static float GetPlayerHP()
    {
        return GetInstance().playerHP;
    }

    public static float GetShieldCT()
    {
        return GetInstance().shieldCT;
    }

    public static bool GetIsLobby()
    {
        return GetInstance().isLobby;
    }

    public static bool GetIsSoundOn()
    {
        return GetInstance().isSoundOn;
    }

    public static void SetExp(int _exp)
    {
        GetInstance().exp = _exp;
        PlayerPrefs.SetInt("Exp",GetInstance().exp);
        PlayerPrefs.Save();
    }

    public static void SetCoin(int _coin)
    {
        GetInstance().coin = _coin;
        //PlayerPrefs.SetInt("Coin",GetInstance().coin);
        //PlayerPrefs.Save();
    }

    public static void SetAtkUG(int _atkUG)
    {
        GetInstance().atkUG = _atkUG;
        //PlayerPrefs.SetInt("AtkUG",GetInstance().atkUG);
        //PlayerPrefs.Save();
    }

    public static void SetPlayerLevel(int _playerLevel)
    {
        GetInstance().playerLevel = _playerLevel;
        //PlayerPrefs.SetInt("Level",GetInstance().playerLevel);
        //PlayerPrefs.Save();
    }

    public static void SetBStage(int _bStage)
    {
        GetInstance().bStage = _bStage;
        //PlayerPrefs.SetInt("Level",GetInstance().bStage);
        //PlayerPrefs.Save();
    }

    public static void SetPlayerTotalAtk(float _playerTotalAtk)
    {
        GetInstance().playerTotalAtk = _playerTotalAtk;
    }

    public static void SetPlayerHP(int _playerHP)
    {
        GetInstance().playerHP = _playerHP;
    }

    public static void SetShieldCT(float _shieldCT)
    {
        GetInstance().shieldCT = _shieldCT;
    }

    public static void SetStage(int _Stage)
    {
        GetInstance().Stage = _Stage;
        //PlayerPrefs.SetInt("Level",GetInstance().bStage);
        //PlayerPrefs.Save();
    }

    public static void SetIsLobby(bool _isLobby)
    {
        GetInstance().isLobby = _isLobby;
    }

    public static void SetIsSoundOn(bool _isSoundOn)
    {
        GetInstance().isSoundOn = _isSoundOn;
    }

    public static int totalIntFormula(int nowStageLv, int BasicPlus, int BasicCor,
    int EditDef, int EditPlus, int EditCor)
    {        
        int cal;

       cal = (nowStageLv / BasicCor) * BasicPlus
        + (nowStageLv/ EditCor) * EditPlus;

        return cal;
    }

    public static float totalFloatFormula(int nowStageLv, float BasicPlus, int BasicCor,
    float EditDef, float EditPlus, int EditCor)
    {
        float cal = 0;

        cal = (nowStageLv / BasicCor) * BasicPlus
        + (nowStageLv/ EditCor) * EditPlus;

        return cal;
    }

}
