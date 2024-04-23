using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategoryPanel : MonoBehaviour
{
    [SerializeField]
    GameObject _leftPanel;
    [SerializeField]GameObject[] _rightPanels;
    private void OnEnable()
    {
        _leftPanel.SetActive(true);
        foreach(GameObject a in _rightPanels) { a.SetActive(false); }
    }
    public void OnclickLeftButton(int no)
    {
        foreach (GameObject a in _rightPanels) { a.SetActive(false); }
        switch (no) {
            case 0:
                _rightPanels[no].SetActive(true);
                break;case 1:
                _rightPanels[no].SetActive(true);
                break;case 2:
                _rightPanels[no].SetActive(true);
                break;
        }
    }
    private void OnDisable()
    {
        _leftPanel.SetActive(true);
        foreach (GameObject a in _rightPanels) { a.SetActive(false); }
    }

    public void DisableAll() {
        gameObject.SetActive(false);
        GameManger.instance._freeze = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
