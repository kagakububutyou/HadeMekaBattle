/*
 *  なんのスクリプト？
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
 * 
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TouchDragController : MonoBehaviour{
    
    //*
    /// <summary>
    /// 押下状態
    /// </summary>
    public bool pressed
    {
        get;
        private set;
    }

    private Camera padCamera = null;

    private List<RectTransform> panel = new List<RectTransform>();
    
    //
    bool isSelect = false;
	// Use this for initialization
	private void Start () 
    {
        isSelect = true;
     
        padCamera = GameObject.Find("GamePad Camera").GetComponent<Camera>();

        var equippedWeapons = GameObject.FindGameObjectsWithTag("Equipped Weapon");
        
        for(int i = 0;i<equippedWeapons.Length;i++)
        {
            panel.Add(equippedWeapons[i].transform as RectTransform);
        }
	}
	
	// Update is called once per frame
    private void Update()
    {
        if (!isSelect) return;  //  選択していなかったら戻る

        //  選択した瞬間
        if (Input.GetMouseButton(0))
        {
            var mousePos = Input.mousePosition;
            mousePos.z = 10.0f;
            var worldPos = padCamera.ScreenToWorldPoint(mousePos);
            gameObject.transform.position = worldPos;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isSelect = false;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                foreach (var p in panel)
                {
                    //  Panelとあたっていたら
                    if (hit.collider.gameObject == p.gameObject)
                    {
                        // 子供全員消す
                        if (p.transform.childCount >= 1)
                        {
                            foreach (Transform n in p)
                            {
                                Destroy(n.gameObject);
                            }
                        }

                        transform.parent = p.transform;                 //  親決め 
                        transform.position = p.transform.position;      
                        transform.localScale = new Vector3(1, 1, 1);    //  サイズ変更
                        Destroy(this);                                  //  スクリプト消す
                        var cansel = gameObject.AddComponent<WeaponCancel>();        //  スクリプトくっつける
                        cansel.SetNowPanel(p);
                        return;
                    }
                }
            }
            Destroy(gameObject);
        }
    }
}
