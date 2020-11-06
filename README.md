# CDAP-054
## Cyber Security Awareness through game-based learning(AwareME)
## Branch Name: Sandali | IT17013642 -Wijesinghe S.N
### Technology: 2D, 3D, C#
### Platform: Unity (Version: 2019.3.8f1), Visual Studio 2019
Cybersecurity awareness is an area where public awareness is highly recommended. When considering cyber security awareness social media which plays a leading role was considered here. for the purpose of social media awareness user privacy violation consisting of weak password usage and oversharing information in facebook was considered.A game based solution was implemented as a solution.The implemented solution is as follows:

An introductory video made with 3D will be displayed before the games are started.Three games as suggested by the survey participants will be implemented using 2D technology. Two quizzes and a Jigsaw puzzle is included there.The players can use the help option to obtain hints regarding the game.Once the three games are completed two games(scrambled word puzzle/quiz) where the score is calculated will be present. There the player is given a time limit to complete the tasks. These games were made using 2D and 3D technologies.

## 2D games
* quiz(weak password usage)-start level-1
* quiz(oversharing information)-start level-2
* jigsaw puzzle -2
* quiz(miscellaneous)-samplescene

## 3D games
* narrative video - 1st scene,3rd scene,5th scene
* scrambled word puzzle- 2nd scene

**The scenes desinged in unity with the scene names script names and path is below:**

**start level-1(quiz)**
(CDAP-054/Assets cs1/Scripts/)
```
newquiz_sm - when the correct answer is clicked feedback=correct.
menustart - to change scenes
```

**start level-2(quiz)**
(CDAP-054/Assets cs1/Scripts/)
```
newquiz2_sm - when the correct answer is clicked feedback=correct.
menustart - to change scenes
```

**2(jigsaw puzzle)**
(CDAP-054/Assets cs1/Scripts/)
```
feedback_sm - once u drag all the images to the correct position feedback is correct.
drag_sm - lets you drag the image to the correct box and scale it to the size of the box.
menustart - to change scenes
reset_sm - used for resetting the puzzle
control_sm - next and the previous button functions

```

**2nd scene(3d scrambled word puzzle)**
(CDAP-054/Assets cs2/scripts-sm/)
```
charobject
wordscramble - results,time limit, feedback, question manager is displayed
```

**1st scene(3d scene)**
(CDAP-054/Assets cs2/Assets-sm/Scenes/scripts3d_sm/),
(CDAP-054/Assets cs2/Assets-sm/)
```
dialscript - displays the dialouges
movesceneon keypress - Trigger action
playermovement - animation
```

**5th scene(3d scene)**
(CDAP-054/Assets cs2/Assets-sm/Scenes/scripts3d_sm/),
(CDAP-054/Assets cs2/Assets-sm/)
```
mouselook - to look around the 3d scenes
playermovement - animation 
dialscript5 - displays the dialouges
```

**3rd scene(3d scene)**
(CDAP-054/Assets cs2/Assets-sm/Scenes/scripts3d_sm/),
(CDAP-054/Assets cs2/Assets-sm/)
```
dialscript - displays the dialouges
playermovement - animation
menustart - change the scenes
```

**samplescene(quiz)**
(CDAP-054/Assets cs1/Scripts/)
```
answerdata - reset,switching states, update UI
audiomanager - controlling the sound of the game
uimanager - central controlling part 
gameevents
game manager
gameutility
question - creation of question files
menustart - change the scenes
```


**How to run the game:**
```
- Step 1: Create a Unity project using a 3D template - use Version: 2019.3.8f1 
- Step 2: Put all these files in the "Assets" folder 
- Step 3: Go to the Assets cs2\Assets_sm\scenes\scenes and run "1st scene" 
```


