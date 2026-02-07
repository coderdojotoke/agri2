using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GrassDelete : MonoBehaviour
{
    public float grassClearRadius = 5f;
    public int detailLayer = 0;
    private Terrain terrain;
    public Canvas canvas;
    public Slider nokori;
    public Text nokoriText;
    public int nokoriTextText;
    public int pasent = 100;
    //public TextMeshPro timerText; // UIのTextコンポーネントをアタッチ
    public TextMeshProUGUI timerText;

    private float elapsedTime = 0f; // 経過時間
    private bool isRunning = false; // ストップウォッチの状態
    public TextMeshProUGUI Timetext;
    public TextMeshProUGUI Leveltext;
    private string deleteTag = "dk";

    void Start()
    {
        //terrain = Terrain.activeTerrain;
        //TerrainData runtimeData = Instantiate(terrain.terrainData);
        //terrain.terrainData = runtimeData;
        elapsedTime = 0f;
        isRunning = true;
    }

    void Update()
    {
         if (isRunning)
        {
            elapsedTime += Time.deltaTime; // 経過時間を加算
            int seconds = Mathf.FloorToInt(elapsedTime); // 秒単位に変換
            timerText.text = seconds.ToString(); // テキストに表示
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(deleteTag))
        {
            nokori.value -= 1;
            Destroy(other.gameObject); 

            if (nokori.value == 0)
         {
            isRunning = false;
            canvas.gameObject.SetActive(true);
            Timetext.text = "今回のタイム:" + elapsedTime.ToString("F0") + "秒";
                //Debug.Log(timerText);
                if (elapsedTime <= 20)
                {
                    Leveltext.text = "Level 5";
                }
                if (elapsedTime >= 21 && elapsedTime <= 50)
                {
                    Leveltext.text = "Level 4";
                }
                if (elapsedTime >= 51 && elapsedTime <= 80)
                {
                    Leveltext.text = "Level 3";
                }
                if (elapsedTime >= 81 && elapsedTime <= 110)
                {
                    Leveltext.text = "Level 2";
                }
                if (elapsedTime >= 111)
                {
                    Leveltext.text = "Level 1";
                }
         }

        }
        
    }
    
    }