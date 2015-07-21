/*
 *  武器を選択するスクリプト
 * 
 *  決め事
 * 
 *  命名規則：   Pascal形式　例) AttackCount; Camel形式
 *      名前空間 Pascal形式　クラス、構造体　Pascal形式　プロパティ　Pascal形式
 *      メンバ変数(フィールド)　Camel形式　メソッド　Pascal形式　パラメータ　Camel形式
 *      
 *  メソット    1メソッド10行以内　最大2インデント　名前をわかりやすく
 *  Property    getのみ行う　setは、プライベート
 * 
 * SendMessageを使わない　Editorから読み込むだけなら[Serialize Failed]を使用する
 * 
 * 状態管理をしっかり行う　ジェネリック思考で考える
 * 
 * Code by shinnnosuke hiratsuka
 * 
 * 2015/07/11 書き始める
 * 2015/07/14 Parentの設定の変更
 * 2015/07/21 リファクタリング
 * 
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// 武器選択する
/// </summary>
public class TouchDragController : MonoBehaviour{ 
    
    /// <summary>
    /// 押下状態
    /// </summary>
    public bool pressed
    {
        get;
        private set;
    }

    /// <summary>
    /// GamePadのキャンパス
    /// </summary>
    private Camera padCamera = null;

    /// <summary>
    /// 装備武器の情報
    /// </summary>
    private List<RectTransform> panel = new List<RectTransform>();
    /// <summary>
    /// 武器のステータス表示
    /// </summary>
    [SerializeField]
    private WeaponStatusChanger weaponStatusChanger = null;
    
    /// <summary>
    /// 選択しているかどうか
    /// </summary>
    bool isSelect = false;
    /// <summary>
    /// 武器のId
    /// </summary>
    private BuildManager.WeaponID weaponID = BuildManager.WeaponID.NULL;
	// Use this for initialization
	private void Start () 
    {
        isSelect = true;
     
        padCamera = GameObject.Find("GamePad Camera").GetComponent<Camera>();

        weaponStatusChanger = GameObject.Find("Status Panel").GetComponent<WeaponStatusChanger>();

        //  装備武器のタグ検索
        var equippedWeapons = GameObject.FindGameObjectsWithTag("Equipped Weapon");
        
        //  情報にAddする
        for(int i = 0;i<equippedWeapons.Length;i++)
        {
            panel.Add(equippedWeapons[i].transform as RectTransform);
        }
	}
	
	// Update is called once per frame
    private void Update()
    {
        if (!isSelect) return;  //  選択していなかったら戻る

        //  ボタンが押されたか
        if (Input.GetMouseButton(0))
        {
            PushButton();
        }
        //  ボタンが離された瞬間
        if (Input.GetMouseButtonUp(0))
        {
            ButtonUp();
        }
    }
    /// <summary>
    /// 武器のIdをもらってくる
    /// </summary>
    /// <param name="weaponID">武器のID</param>
    public void GetWeaponID(BuildManager.WeaponID weaponID)
    {
        this.weaponID = weaponID;
    }

    /// <summary>
    /// 選択している時
    /// </summary>
    private void PushButton()
    {
        var mousePos = Input.mousePosition;     //  マウスの座標
        mousePos.z = 10.0f;                     //  z調整
        var worldPos = padCamera.ScreenToWorldPoint(mousePos);  //  座標変換
        gameObject.transform.position = worldPos;               //  代入

        weaponStatusChanger.Change(weaponID);       //  ステータスの変更
    }
    /// <summary>
    /// 離した時
    /// </summary>
    private void ButtonUp()
    {
        isSelect = false;   //  falseにする
        //  Rayに座標を入れる
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        //  Ray飛ばしてあたっているかどうか
        if (Physics.Raycast(ray, out hit))
        {
            OnCollisionPanel(hit);
            return;
        }
    }
    /// <summary>
    /// Panelとあたっているか
    /// </summary>
    /// <param name="hit">hitの情報</param>
    private void OnCollisionPanel(RaycastHit hit)
    {
        // ループカウント
        int loopCount = 0;

        foreach (var p in panel)
        {
            if (hit.collider.gameObject == p.gameObject)
            {
                DestroyChildrens(p);
                SetWeapon(p);
            }
            else if (hit.collider.gameObject != p.gameObject)
            {
                loopCount += 1;
                LoopCount(loopCount);
            }
        }
    }
    /// <summary>
    /// panelの個数以上に呼ばれたら死ぬ
    /// </summary>
    /// <param name="loopCount"></param>
    /// こうしたら出来た
    private void LoopCount(int loopCount)
    {
        if(loopCount >= panel.Count)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 子供達を消す
    /// </summary>
    /// <param name="panel">子供の情報</param>
    private void DestroyChildrens(RectTransform panel)
    {
        // 子供全員消す
        if (panel.transform.IsChildOf(panel.transform)) 
        {
            foreach (Transform n in panel)
            {
                Destroy(n.gameObject);
            }
        }
    }

    /// <summary>
    /// 武器セット
    /// </summary>
    /// <param name="panel">なんの武器か</param>
    private void SetWeapon(RectTransform panel)
    {
        transform.SetParent(panel.transform);                   //  親決め 
        transform.position = panel.transform.position;          //  座標を入れる
        transform.localScale = new Vector3(1, 1, 1);            //  サイズ変更
        Destroy(this);                                          //  スクリプト消す
        var cansel = gameObject.AddComponent<WeaponCancel>();   //  スクリプトくっつける
        cansel.SetNowPanel(panel);                              //  Panelを渡す
        cansel.GetWeaponID(weaponID);                           //  武器のIDを渡す
        //  武器装備
        WeaponEquipment weaponEquipment = GameObject.Find(panel.name).GetComponent<WeaponEquipment>();
        weaponEquipment.WeaponChange(weaponID);
        EquippedChanger equippedCutIn = GameObject.Find(panel.name).GetComponent<EquippedChanger>();
        equippedCutIn.EquippedDisplay(weaponID);
    }
}
