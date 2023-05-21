using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField] private GameObject _nodeHolder;
    private List<GameObject> _nodes = new List<GameObject>();
    private Vector3 _targetPos;
    private int _index = 0;
    [SerializeField] private int _customerSpeed;
    private float _time = 0;
    private bool flagForCustomer = false;
    private bool flagForTable = true;
    [SerializeField] private GameObject _button;
    [SerializeField] private GameObject _seat;
    [SerializeField] private GameObject _table;

    private void Start() {
        foreach (Transform child in _nodeHolder.transform) {
            _nodes.Add(child.gameObject);
        }
        _targetPos = _nodes[0].transform.position;
    }

    private void FixedUpdate() {
        if(!flagForCustomer) {
            transform.position = Vector3.MoveTowards(transform.position, _targetPos, _customerSpeed * Time.fixedDeltaTime);
            if(Vector3.Distance(_targetPos, transform.position) <= 0.1f) {
                flagForCustomer = true;
                _time = _nodes[_index].GetComponent<Node>().getHowManySec();
                if(_nodes[_index].transform.childCount > 0) _nodes[_index].transform.GetChild(0).gameObject.SetActive(true);
            } 
        } else {
            _time -= Time.fixedDeltaTime;
            if(_time <= 0) {
                _index++;
                if(_index < _nodes.Count) {
                    _targetPos = _nodes[_index].transform.position;
                    flagForCustomer = false;
                } else {
                    gameObject.SetActive(false);
                    if(!(_button == null)) {
                        _button.SetActive(false);
                        _seat.GetComponent<SpriteRenderer>().color = new Color32(146, 196, 127, 255);
                        foreach (Transform childSeat in _table.transform)
                        {
                            if(!(childSeat.gameObject.GetComponent<SpriteRenderer>().color == new Color32(146, 196, 127, 255))) {
                                flagForTable = false;
                                break;
                            }
                        }
                        if(flagForTable) _table.GetComponent<SpriteRenderer>().color = new Color32(146, 196, 127, 255);
                        else _table.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                    }
                }
            }
        } 
    }   
    
}