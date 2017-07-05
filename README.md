# Unity-Weapon-Drag
A small C# script which adds a delay/sway to a weapon in first person Unity 5 games. This is subtle but very important effect which is used in most FPS games. It ensures that your weapon does not looks like it is directly attached to the camera.

## Instructions

* This should be used if your weapon is a child of the first person camera. 
* Can be used on animated weapons.
  * If your weapon has an animator attached you should add another parent gameobject which this script can be attached to

### Hierarchy 

```
Player
    FPSCamera
      GunParent ->attach here<-
        Gun
```
