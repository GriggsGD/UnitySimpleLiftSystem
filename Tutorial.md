# Simple Vertical Lift System
This tutorial will demonstrate how to develop a simple Vertical Lift System in Unity 3D

## 1. Setup your scene

Start off by creating a new scene called `Lift`

Add an empty game object called `LiftSystem`, this will hold all the lift objects

Add another empty game object called `LiftAnchor` as a child of the `LiftSystem` object, add a Rigidbody component to this object with `Is Kinematic` ticked, this object will be used to move our lift surface, using a kinematic rigidbody will allow this object to affect other rigidbodies, for example a physics based player character using the lift

Add 3 more empty game objects called `Level0`, `Level1` and `Level2` as a child of the `LiftSystem` object, position these objects at various heights/Y axis positions, add label icons to these game objects so they can be seen in the scene, these will be used as vertical locations the lift will travel to

Add a cube mesh called `LiftSurface` as a child of `LiftAnchor`, scale the cube `3, 0.1, 2` to form it into a lift surface. Then position the cube so that the `LiftAnchor` is inline with the top face of our cube, so with the current y scale of 0.1 on our cube set its `Y position` to `-0.05`, doing this will make sure the top of the lift surface aligns with the various level positions

![LiftSystem Hierarchy](https://user-images.githubusercontent.com/79928221/149210721-503005bf-bca1-4c92-9644-516958d3e93e.png)


Next lets give our Lift surface some colour, create a new material called `LiftMat` setting its `Albedo` to an orange colour, then drag the material onto our `LiftSurface` cube

![LiftSystem Setup](https://user-images.githubusercontent.com/79928221/149210739-dc9dee33-a789-47b0-af57-934abc8edfe1.png)

## 2. Developing the Lift functionality

Start by creating a new script called `LiftSystem`

Open up the script, first we need to declare some variables...
```
[SerializeField] float liftSpeed = 5;		//Controls the lift speed
[SerializeField] Transform liftAnchor;		//Reference for the lift anchor
[SerializeField] Transform[] levelPositions;		//Array of references for our level positions
[SerializeField] int liftPositionAtStart = 0;		//Controls what level the lift should be at on start
int currLiftLevel;		//Holds the current lift level
int desiredLevel;		//Holds the desired lift level
```

Next we need to create a method to control the lift's functionality...
```
void LiftCtrl()
    {
        for (int i = 0; i < levelPositions.Length; i++)
        {
            if (levelPositions[i].position.y == liftAnchor.position.y) currLiftLevel = i;		//Calculates and sets the current lift position
        }

        float step = liftSpeed * Time.deltaTime;		//Keeps the lift speed relative to time
        liftAnchor.position = Vector3.MoveTowards(liftAnchor.position, new Vector3(liftAnchor.position.x, levelPositions[desiredLevel].position.y, liftAnchor.position.z), step);		//Moves the lift to the desired level at the set speed
    }
```

Now we need to call the method we just created in an `Update()` method...
```
void Update()
    {
        LiftCtrl();
    }
```

With our lift functionality created we now need to add some public methods to control the lift...
```
    public void SimpleMoveToNextLvl()		//Moves the lift to the next avaliable level
    {
        if (desiredLevel == levelPositions.Length - 1)		//Checks if the current desired level is the last avaliable
        {
            desiredLevel = 0;		//If true the desired level is reset to the first level
        }
        else desiredLevel++;		//If false meaning there is another next avaliable level +1 is added to the desired level
    }
		
    public void MoveUpLvl()		//Moves the lift up a level
    {
        if (desiredLevel == levelPositions.Length - 1)		//Checks if the current desired level is the last avaliable
        {
            return;		//If true the lift cannot move up so we return out of the method to stop further execution
        }
        else desiredLevel++;		//If false meaning there is a next level to travel to +1 is added to the desired level
    }
		
    public void MoveDownLvl()		//Moves the lift down a level
    {
        if (desiredLevel == 0)		//Checks if the current desired lift level is the first
        {
            return;		//If true the lift cannot move up so we return out of the method to stop futher execution
        }
        else desiredLevel--;		//If false meaning there is a lower level to travel to -1 is subtracted from the desired level
    }
```

Save the script!

## 3. Setup the script on the `LiftSystem` object

Back in Unity add to the script to the `LiftSystem` object's components

Now we need to reference our lift parts in the script's properties connected to the `LiftSystem` object
- Select the `LiftSystem` object, go to the Inspector panel and click on the lock in the top right of the panel, this will make it easier referencing the object's to the script's properties
- Drag the `LiftAnchor` object to `Lift Anchor` in the Inspector panel
- Select all of the level position objects `Level0`, `Level1`, `Level2`, and drag them to `Level Positions` to add them all at once, make sure they are in the correct order
- Then click the lock button top left of the Inspector to unlock its focus from the `LiftSystem` object

![LiftSystem Inspector](https://user-images.githubusercontent.com/79928221/149210806-053eb2d2-97cc-415f-891c-68d2f8be5f2e.png)

## 4. Testing

To test our lift we will need some in game controls to call the lift control methods, for demonstration we will use UI buttons to control the lift

Start by adding a canvas object to the scene calling this `UICanvas`

Next add 3 buttons to the `UICanvas` called `LiftUpBTN`, `LiftNextLvlBTN` and `LiftDownBTN`, spread these buttons out on the canvas so they can be seen and selected

Setup the `LiftUpBTN` button
- Select `LiftUpBTN` in the Hierarchy, go to the Inspector panel and change the button's `Normal Color` to `green`
- Go down to `On Click()` and select `+`, drag the `LiftSystem` object to the object box, then open the drop down, hover over `LiftSystem` and select `MoveUpLvl ()`
- In the Hierarchy open up `LiftUpBTN` to view it's child objects
- Select the `Text` object, go to the Hierarchy and set the text to `Move Lift Up`

Setup the `LiftNextLvlBTN` button
- Select `LiftNextLvlBTN` in the Hierarchy, go to the Inspector panel and change the button's `Normal Color` to `yellow`
- Go down to `On Click()` and select `+`, drag the `LiftSystem` object to the object box, then open the drop down, hover over `LiftSystem` and select `SimpleMoveToNextLvl ()`
- In the Hierarchy open up `LiftNextLvlBTN` to view it's child objects
- Select the `Text` object, go to the Hierarchy and set the text to `Move Lift to Next Level`

Setup the `LiftDownBTN` button
- Select `LiftDownBTN` in the Hierarchy, go to the Inspector panel and change the button's `Normal Color` to `red`
- Go down to `On Click()` and select `+`, drag the `LiftSystem` object to the object box, then open the drop down, hover over `LiftSystem` and select `MoveDownLvl ()`
- In the Hierarchy open up `LiftDownBTN` to view it's child objects
- Select the `Text` object, go to the Hierarchy and set the text to `Move Lift Down`

![LiftSystem UI Buttons](https://user-images.githubusercontent.com/79928221/149210774-58594457-143b-4b93-9d19-cc17ccf44d82.png)

Now run the scene and select the UI buttons to test out the lift

![LiftSystem Result](https://user-images.githubusercontent.com/79928221/149211469-c1e89e93-e829-4a59-a687-adeef6f1623c.gif)
