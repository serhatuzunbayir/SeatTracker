using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RateFollow : MonoBehaviour
{
    [SerializeField] private TMP_Text _totalFullTablesText;
    [SerializeField] private TMP_Text _totalFullEmptyTablesText;
    [SerializeField] private TMP_Text _totalNeitherEmptyNorFullTable;
    [SerializeField] private TMP_Text _totalFullChairText;
    [SerializeField] private TMP_Text _totalEmptyChairText;
    [SerializeField] private GameObject _table1;
    [SerializeField] private GameObject _table2;
    [SerializeField] private GameObject[] _buttons;
    [SerializeField] private Image _image;
    void Update()
    {
        bool isTable1Red = _table1.GetComponent<SpriteRenderer>().color == new Color32(224, 102, 101, 255);
        if(isTable1Red) _totalFullTablesText.text = "Total full tables: 1";
        else _totalFullTablesText.text = "Total full tables: 0";

        bool isTable1Green = _table1.GetComponent<SpriteRenderer>().color == new Color32(146, 196, 127, 255);
        bool isTable2Green = _table2.GetComponent<SpriteRenderer>().color == new Color32(146, 196, 127, 255);
        if(isTable1Green && isTable2Green) _totalFullEmptyTablesText.text = "Total full empty tables: 5";
        else if((isTable1Green || isTable2Green)) _totalFullEmptyTablesText.text = "Total full empty tables: 4";
        else _totalFullEmptyTablesText.text = "Total full empty tables: 3";

        bool isTable1White = _table1.GetComponent<SpriteRenderer>().color == new Color32(255, 255, 255, 255);
        bool isTable2White = _table2.GetComponent<SpriteRenderer>().color == new Color32(255, 255, 255, 255);
        if(isTable1White && isTable2White) _totalNeitherEmptyNorFullTable.text = "Total neither empty nor full tables: 2";
        else if((isTable1White || isTable2White)) _totalNeitherEmptyNorFullTable.text = "Total neither empty nor full tables: 1";
        else _totalNeitherEmptyNorFullTable.text = "Total neither empty nor full tables: 0";

        int activeButtonNum = 0;
        foreach (GameObject item in _buttons)
        {
            if(item.activeSelf) activeButtonNum++;
        }
        _totalFullChairText.text = "Total full chair: " + (activeButtonNum);
        _totalEmptyChairText.text = "Total empty chair: " + (12-activeButtonNum);

        _image.GetComponent<Image>().fillAmount = (float) (activeButtonNum/12f);
    }
}
