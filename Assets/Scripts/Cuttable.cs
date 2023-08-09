using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuttable : MonoBehaviour
{
    [SerializeField]
    private CutType type;
    public enum CutType
    {
        String,
        Enemy
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Cut()
    {
        switch (type)
        {
            case CutType.String:
                // object is string and has been cut
                Destroy(gameObject);
                break;
            case CutType.Enemy:
                break;
        }
    }
    private void OnMouseEnter()
    {
        if (Input.GetMouseButton(0) 
            && MetaControls.Instance.activeTool == MetaControls.Tools.Knife)
        {
            if (MetaControls.Instance.UseTool(MetaControls.Tools.Knife))
                Cut();
        }
    }
}
