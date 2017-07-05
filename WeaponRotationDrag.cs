using UnityEngine;

/** Author: Aghmat Abrahams
 *  Unity Version: 5.6.1
 *  IDE: Visual Studio Community 2017
 *  Date: July 2017
 *  Instructions: This script will add weapon sway
 *                modified from chrisall76 -> http://answers.unity3d.com/questions/410134/how-to-add-weapon-swayc.html         
 **/


public class WeaponRotationDrag : MonoBehaviour
{
    //common settings -> (d, dT, s) 
    //  -> Camera lags (-2.5f, -5f, 5)
    //  -> Weapon lags (2.5f, 5f, 5)

    //Heirarchy
    //  Player
    //      Camera
    //          GunParent  -> attach here if gun animated <-
    //              Gun
    public float drag =2.5f;
    public float dragThreshold = -5f;
    public float smooth = 5;

    private Quaternion localRotation;

    void Start()
    {
        localRotation = transform.localRotation;
    }
    
    void Update()
    {
        float z = (Input.GetAxis("Mouse Y")) * drag;
        float y = -(Input.GetAxis("Mouse X")) * drag;

        if (drag >= 0) //weapon lags behind camera
        {
            y = (y > dragThreshold) ? dragThreshold : y;
            y = (y < -dragThreshold) ? -dragThreshold : y;

            z = (z > dragThreshold) ? dragThreshold : z;
            z = (z < -dragThreshold) ? -dragThreshold : z;
        }
        else //camera lags behind weapon
        {
            y = (y < dragThreshold) ? dragThreshold : y;
            y = (y > -dragThreshold) ? -dragThreshold : y;

            z = (z < dragThreshold) ? dragThreshold : z;
            z = (z > -dragThreshold) ? -dragThreshold : z;
        }

        //weapon default rotation transform has to be (0, 0, 0)
        Quaternion newRotation = Quaternion.Euler(localRotation.x, localRotation.y + y, localRotation.z + z);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, newRotation, (Time.deltaTime * smooth));
    }
}