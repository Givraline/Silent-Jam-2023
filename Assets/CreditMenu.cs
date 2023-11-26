using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreditMenu : MonoBehaviour
{
    [SerializeField] private RectTransform _creditMenu;
    private RectTransform canvasTransform;
    private float posYTarget;
    void Start()
    {
        canvasTransform = GetComponent<RectTransform>();
        posYTarget = _creditMenu.position.y + _creditMenu.sizeDelta.y;
    }

    // Update is called once per frame
    void Update()
    {
        _creditMenu.position = Vector3.MoveTowards(_creditMenu.position, new Vector3(_creditMenu.position.x, posYTarget, _creditMenu.position.z), Time.deltaTime * 50 * canvasTransform.localScale.y);
    }
}
