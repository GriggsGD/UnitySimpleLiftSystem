# Simple Vertical Lift System
This tutorial will demonstrate how to develop a simple Vertical Lift System in Unity 3D

## 1. Setup your scene

Start off by creating a new scene called `Lift`

Add an empty game object called `LiftSystem`, this will hold all the lift objects

Add another empty game object called `LiftAnchor` as a child of the `LiftSystem` object, add a Rigidbody component to this object with `Is Kinematic` ticked, this object will be used to move our lift surface, using a kinematic rigidbody will allow this object to affect other rigidbodies, for example a physics based player character using the lift

Add 3 more empty game objects called `Level0`, `Level1` and `Level2` as a child of the `LiftSystem` object, position these objects at various heights/Y axis positions, add label icons to these game objects so they can be seen in the scene, these will be used as vertical locations the lift will travel to

Add a cube mesh called `LiftSurface` as a child of `LiftAnchor`, scale the cube `3, 0.1, 2` to form it into a lift surface. Then position the cube so that the `LiftAnchor` is inline with the top face of our cube, so with the current y scale of 0.1 on our cube set its `Y position` to `-0.05`, doing this will make sure the top of the lift surface aligns with the various level positions

Next lets give our Lift surface some colour, create a new material called `LiftMat` setting its `Albedo` to an orange colour, then drag the material onto our `LiftSurface` cube

## 2. Developing the Lift functionality

