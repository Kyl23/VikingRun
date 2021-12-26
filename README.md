# VikingRun
## WebGL Version URL:
https://kyl233.github.io/VikingRun/
## Tech Stack
-	C# Visual Studio 2017
-	Unity 2020.3.23f1
## Dev Environment
-	Windows 11
## How To Play
- AD控制玩家左右移動
-S控制下滑（比較像躺著跑）
-Space 跳躍
-QE旋轉方向（左右）

向右躲避

![Image text](https://github.com/Kyl23/VikingRun/blob/master/imgFolder/Picture1.png)

向左躲避

![Image text](https://github.com/Kyl23/VikingRun/blob/master/imgFolder/Picture12.png)

用身體吃金幣           

![Image text](https://github.com/Kyl23/VikingRun/blob/master/imgFolder/Picture2.png)

向上跳躍躲避

![Image text](https://github.com/Kyl23/VikingRun/blob/master/imgFolder/Picture3.png)

下滑躲避                     

![Image text](https://github.com/Kyl23/VikingRun/blob/master/imgFolder/Picture4.png)

   
## Overview
Menu: 
 
 ![Image text](https://github.com/Kyl23/VikingRun/blob/master/imgFolder/Picture5.png)

Illustrate
 
 ![Image text](https://github.com/Kyl23/VikingRun/blob/master/imgFolder/Picture6.png)

GameUI:
 
 ![Image text](https://github.com/Kyl23/VikingRun/blob/master/imgFolder/Picture7.png)

End Game:

 ![Image text](https://github.com/Kyl23/VikingRun/blob/master/imgFolder/Picture8.png)

## Bonus
### Infinite ground spawner 
- T-shape grounds
-  a road a player needs to run aside
### Music 
- background music will loop until player dead
- pick coin music
- crash on trap music 
- ghost(more specifically  is another Viking) catch up music
- end game music
### A good game structure design (code) 
-Coin /Time Counter is another Script to response .
- Clear division of script
- Script storage structure is good in this project
-All is very good can’t show it more (XD)
### Some special game objects which aren’t mentioned above 
-jump can break slide immediately ,slide can break jump immediately(Space -> jump , S -> slide)
-trap probability is 50 % , the 50% didn't trap got 40% did coin on the floor (one loop has 9 floor)
-After start game it will count down to let player prepare

![Image text](https://github.com/Kyl23/VikingRun/blob/master/imgFolder/Picture9.png)
 
-before count down end and after dead it can’t do any input function and the all animation & action will be disabled，music will only disabled after dead-camera has an animation after player dead
-Viking crash on different trap will flip different direction
   
   ![Image text](https://github.com/Kyl23/VikingRun/blob/master/imgFolder/Picture10.png)
   
   ![Image text](https://github.com/Kyl23/VikingRun/blob/master/imgFolder/Picture11.png)
   
-ghost will has an animation after catch Viking
-floor will auto recycle after Viking passed 
-the ghost catch up has animation and it will return back after 10 seconds ago when it back it also has an animation
-logic more similar with temple run
 
 ![Image text](https://github.com/Kyl23/VikingRun/blob/master/imgFolder/Picture1.png)
 
I)	If the ghost is behind Viking and crash into this trap will directly die ,else the ghost will catch up Viking
II)	Viking will run fast and fast every 10 seconds Viking Run speed will increase “1”(unit in Unity)
III)	Forced Viking run forward

Min Speed : 15 & Max Speed: 40

-the ghost will mimic Viking’s action(Besides Slide Key “S”)

![Image text](https://github.com/Kyl23/VikingRun/blob/master/imgFolder/Picture13.png)

-game can be pause or just directly exit game or restart in game
 
How good your game is 
-It very similar Temple Run
- It all is very perfect let see above descript~
