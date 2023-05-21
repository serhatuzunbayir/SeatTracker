using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTrack : MonoBehaviour
{
    [SerializeField] private GameObject _seat;
    [SerializeField] private GameObject _table;
    bool _flag = true;

    private void OnEnable() {
        _seat.GetComponent<SpriteRenderer>().color = new Color32(224, 102, 101, 255);
        foreach (Transform childSeat in _table.transform)
        {
            if(!(childSeat.gameObject.GetComponent<SpriteRenderer>().color == new Color32(224, 102, 101, 255))) {
                _flag = false;
                break;
            }
        }
        if(_flag) _table.GetComponent<SpriteRenderer>().color = new Color32(224, 102, 101, 255);
        else _table.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
    }
}