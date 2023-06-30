using System.Collections;
using System.Collections.Generic;
using Script.UI.DialogueSystem;
using UnityEngine;

public class 测试脚本 : MonoBehaviour
{
    public DialogueSO dialogueSo;
    // Start is called before the first frame update
    void Start()
    {
        DialogueCanvas.Instance.CallDialogue(dialogueSo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
