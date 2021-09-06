using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;
 
    BuildManager buildmanager;
    void Start()
    {
        buildmanager = BuildManager.instance;    
    }
    public void SelectStandardTurret()
    {
        buildmanager.SelectTurretToBuild(standardTurret);
   
        Debug.Log("Standard turret selected!");
    }
    public void SelectMissileTurret()
    {
        buildmanager.SelectTurretToBuild(missileLauncher);
   
        Debug.Log("Missile turret selected!");
    }
    public void SelectLaserTurret()
    {
        buildmanager.SelectTurretToBuild(laserBeamer);
   
        Debug.Log("Laser turret selected!");
    }
}
