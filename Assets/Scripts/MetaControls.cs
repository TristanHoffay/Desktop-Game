using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaControls : MonoBehaviour
{
    public static MetaControls Instance;
    public GameObject knife;
    public GameObject tape;
    public GameObject pencil;
    public GameObject activeToolInstance;
    public Tools activeTool;
    public enum Tools
    {
        Knife,
        Tape,
        Pencil
    }
    [SerializeField]
    private int[] toolCounts = new int[3]; // number of total tools;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        ToolManager.instance.SetAvailable(0, toolCounts[0]);
        ToolManager.instance.SetAvailable(1, toolCounts[1]);
        ToolManager.instance.SetAvailable(2, toolCounts[2]);
    }

    // Update is called once per frame
    void Update()
    {
        if (activeToolInstance != null)
        {
            activeToolInstance.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 10;
        }
        if (Input.GetMouseButtonDown(0)) // left click held
        {
            switch (activeTool)
            {
                case Tools.Knife:
                    if (toolCounts[0] > 0)
                    {
                        activeToolInstance = Instantiate(knife);
                    }
                    break;
                case Tools.Tape:
                    if (toolCounts[1] > 0)
                    {
                        //activeToolInstance = Instantiate(tape);
                    }
                    break;
                case Tools.Pencil:
                    if (toolCounts[2] > 0)
                    {
                        //activeToolInstance = Instantiate(pencil);
                    }
                    break;
            }
        }
        if (Input.GetMouseButtonUp(0)) 
        {
            if (activeToolInstance != null)
                Destroy(activeToolInstance);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            activeTool = Tools.Knife;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            activeTool = Tools.Tape;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            activeTool = Tools.Pencil;
        }
    }
    public static void SetKnife()
    {
        Instance.activeTool = Tools.Knife;
    }
    public static void SetTape()
    {
        Instance.activeTool = Tools.Tape;
    }
    public static void SetPencil()
    {
        Instance.activeTool = Tools.Pencil;
    }
    public void AddTool(Tools tool)
    {
        switch (tool)
        {
            case Tools.Knife:
                toolCounts[0]++;
                ToolManager.instance.SetAvailable(0, toolCounts[0]);
                break;
            case Tools.Tape:
                toolCounts[1]++;
                ToolManager.instance.SetAvailable(1, toolCounts[1]);
                break;
            case Tools.Pencil:
                toolCounts[2]++;
                ToolManager.instance.SetAvailable(2, toolCounts[2]);
                break;
        }
    }
    // called to determine if a tool can be used, and decreases its counter
    public bool UseTool(Tools tool)
    {
        switch (tool)
        {
            case Tools.Knife:
                if (toolCounts[0] > 0)
                {
                    ToolManager.instance.SetAvailable(0, --toolCounts[0]);
                    if (toolCounts[0] == 0)
                    {
                        Destroy(activeToolInstance);
                    }
                    return true;
                }
                else
                    return false;
            case Tools.Tape:
                if (toolCounts[1] > 0)
                {
                    ToolManager.instance.SetAvailable(1, --toolCounts[1]);
                    if (toolCounts[1] == 0)
                    {
                        Destroy(activeToolInstance);
                    }
                    return true;
                }
                else
                    return false;
            case Tools.Pencil:
                if (toolCounts[2] > 0)
                {
                    ToolManager.instance.SetAvailable(2, --toolCounts[2]);
                    if (toolCounts[2] == 0)
                    {
                        Destroy(activeToolInstance);
                    }
                    return true;
                }
                else
                    return false;
        }
        return false;
    }
}
