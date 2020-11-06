# CDAP-054
Branch Name-Sandali Files-AwareME Social media awareness Game IT17013642  Wijesinghe S.N - Cyber security Awareness - 2D Quiz game/3D puzzle game.

Cybersecurity awareness is an area where public awareness is highly recommended. When considering cyber security awareness social media which plays a leading role was considered here. for the purpose of social media awareness user privacy violation consisting of weak password usage and oversharing information in facebook was considered.A game based solution was implemented as a solution.The implemented solution is as follows:

An introductory video made with 3D will be displayed before the games are started.Three games as suggested by the survey participants will be implemented using 2D technology. Two quizzes and a Jigsaw puzzle is included there.The players can use the help option to obtain hints regarding the game.Once the three games are completed two games(scrambled word puzzle/quiz) where the score is calculated will be present. There the player is given a time limit to complete the tasks. These games were made using 2D and 3D technologies.
The scenes desinged in unity with the scripts consisting for each scene is below:

**start level-1(quiz)**
```
newquiz_sm - when the correct answer is clicked feedback=correct.
menustart - to change scenes
```

**start level-2(quiz)**
```
newquiz2_sm - when the correct answer is clicked feedback=correct.
menustart - to change scenes
```

**2(jigsaw puzzle)**
```
feedback_sm - once u drag all the images to the correct position feedback is correct.
drag_sm - lets you drag the image to the correct box and scale it to the size of the box.
menustart - to change scenes
reset_sm - used for resetting the puzzle
control_sm - next and the previous button functions

```

**2nd scene(3d scrambled word puzzle)**
```
charobject
wordscramble - results,time limit, feedback, question manager is displayed
```

**1st scene(3d scene)**
```
dialscript - displays the dialouges
movesceneon keypress - Trigger action
playermovement - animation
```

**5th scene(3d scene)**
```
mouselook - to look around the 3d scenes
playermovement - animation 
dialscript5 - displays the dialouges
```

**3rd scene(3d scene)**
```
dialscript - displays the dialouges
playermovement - animation
menustart - change the scenes
```

**samplescene(quiz)**
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





