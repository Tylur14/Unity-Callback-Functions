using JimJam.Interface;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private string targetPool;
    [SerializeField] private Transform holder;
    [SerializeField] private Texture2D[] cursors;
    [SerializeField] private TextMeshProUGUI display;
    [SerializeField] private string[] randomNames;
    [SerializeField] private string[] randomText;

    private int idcount;
    public void Spawn()
    {
        var obj = 
            FindObjectOfType<Pool>().GetObject(targetPool);
        obj.transform.parent = holder;
        obj.SetActive(true);
        var button = obj.GetComponent<JuicyButton>();
        var data = obj.GetComponent<DataPack>();
        
        int rN = Random.Range(0, randomNames.Length);
        data.dataName = randomNames[rN];
        int rT = Random.Range(0, randomText.Length);
        data.dataText = randomText[rT];
        data.dataId = idcount;
        idcount++;
        
        button.onClick.AddListener(Clicked);
        button.onHover.AddListener(delegate { ChangeCursor(0); });
        button.onExit.AddListener(delegate { ChangeCursor(1); });
        button.onClick.AddListener(
            delegate
            {
                DisplayButtonInfo(data.dataName,data.dataText,data.dataId);
            });
    }

    public void Clicked()
    {
        print("Clicked!");
    }
    public void ChangeCursor(int state)
    {
        Cursor.SetCursor(cursors[state],Vector2.zero, CursorMode.Auto);    
    }

    public void DisplayButtonInfo(string n, string t, int id)
    {
        display.text = $"Name: {n}\nText: {t}\nID:{id}";
    }
}
