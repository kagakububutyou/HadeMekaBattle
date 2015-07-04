using UnityEngine;
using System.Collections;

public class BuildManager : MonoBehaviour {

    /// <summary>
    /// 武器を装備できる最大数。
    /// 
    /// 4で決め打ち。
    /// </summary>
    const int weaponNumberMax = 4;
    
    /// <summary>
    /// 武器一覧
    /// </summary>
    public enum WeaponID
    {
        NULL = -1,//エラーコード
        SGMT             = 0,//マシンガンはここから
        YMD ,
        HRTK,
        TKG,
        雷楽             = 10,//ライフルはここから
        藤鷹,
        南,
        パリサイトジャン = 20,//ミサイルはここから
        コガマージャン,
        オートモージャン,
        End_of_a_Tard,
        M_F_DS           = 30,//ランチャーはここから
        M_T_GK,
        L_F_GK
    };

    /// <summary>
    /// 武器が装備されている場所の名前
    /// </summary>
    public enum WeaponPositionName
    {
        RightPri = 0,
        RightSub,
        LeftPri,
        LeftSub
    };

    /// <summary>
    /// 武器の種類
    /// </summary>
    public enum WeaponType
    {
        NONE = -1,
        MachineGun = 0,
        Rifle,
        Missile,
        Launcher
    }

    /// <summary>
    /// 武器の名前（ID）と種類を記憶する
    /// </summary>
    public struct WeaponInformation
    {
        public WeaponID ID;
        public WeaponType Type; 
    }

    WeaponInformation[] weaponList = new WeaponInformation[weaponNumberMax];

    /// <summary>
    /// 選択されたロボットのテクスチャの種類。
    /// -1がエラーコード
    /// </summary>
    [SerializeField]
    int robotTextureID = -1;
    public int RobotTextureID { get { return robotTextureID; } set { robotTextureID = value; } }

    /// <summary>
    /// 武器を設定する
    /// </summary>
    /// <param name="_position">装備する箇所</param>
    /// <param name="_id">装備する武器</param>
    public void SetWeapon(WeaponPositionName _position,WeaponID _id)
    {
        weaponList[(int)_position].ID = _id;
        weaponList[(int)_position].Type = GetTypeByID(_id);

    }

    /// <summary>
    /// いま装備されている武器の情報を得る。
    /// </summary>
    /// <param name="_weaponPositionName">装備されているであろう箇所</param>
    /// <returns>装備されている武器と種類を内包した構造体</returns>
    public WeaponInformation GetWeaponInformation(WeaponPositionName _weaponPositionName)
    {
        return weaponList[(int)_weaponPositionName];
    }

    /// <summary>
    /// 武器のIDから武器の種類を調べて返す
    /// </summary>
    /// <param name="_id">武器のID</param>
    /// <returns>武器の種類</returns>
    WeaponType GetTypeByID(WeaponID _id)
    {
        switch ((int)_id / 10)
        {
            case (int)WeaponType.MachineGun:
                return WeaponType.MachineGun;
            case (int)WeaponType.Rifle:
                return WeaponType.Rifle;
            case (int)WeaponType.Missile:
                return WeaponType.Missile;
            case (int)WeaponType.Launcher:
                return WeaponType.Launcher;
        }

        return WeaponType.NONE;

    }
}
