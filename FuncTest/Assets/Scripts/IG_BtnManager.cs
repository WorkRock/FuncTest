using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IG_BtnManager : MonoBehaviour
{
    [Header ("Player")]
    public Text Player_TotalHP_Text;
    public Text Player_NowHP_Text;
    public Text Player_HPBonus_Text;
    public Text Player_ATK_Text;
    public Text Player_ShieldCT_Text;

    [Space(10f)]
    [Header("Dragon")]
    public Text Dragon_TotalHP_Text;
    public Text Dragon_NowHP_Text;

    [Space(10f)]
    [Header("Com Obj")]
    public Text ComObj_Delay_Text;
    public Text ComObj_ATK_Text;
    public Text ComObj_Speed_Text;

    [Space(10f)]
    [Header("Stage")]
    public Text Stage_Text;
    public int Stage;

}
