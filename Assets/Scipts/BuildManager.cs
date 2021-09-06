using UnityEngine;

public class BuildManager : MonoBehaviour
{ 
    public static BuildManager instance;

    private const float TIME_DOUBLE_TOUCH = .2f;
    private float lastTimeClick;
    public bool isChoosed = false;
    void Awake()
    {
        if(instance != null)
        {
            return;
        }
        instance = this;
    }
    private void Update()
    {
        if (isChoosed == true)
        {
            turretToBuild = null;
        }
        if (Input.GetMouseButtonDown(0))
        {
            float timeBetweenClick = Time.time - lastTimeClick;
            if (timeBetweenClick <= TIME_DOUBLE_TOUCH)
            {
                DeselectNode();
                turretToBuild = null;
                Debug.Log("double");
            }

            lastTimeClick = Time.time;
        }
    }
    public GameObject buildEffect;

    private TurretBlueprint turretToBuild;
    private Node selectedNode;
    public NodeUI nodeUI;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HaveMoney { get { return PlayerStart.Money >= turretToBuild.cost; } }

    public void SelectNode(Node node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;
        nodeUI.SetTarget(node);
        
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        isChoosed = false;
        DeselectNode();

    }
    public TurretBlueprint GetTurretTobuild()
    {
        return turretToBuild;
    }
}
