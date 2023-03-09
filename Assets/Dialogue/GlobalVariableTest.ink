INCLUDE Globals.ink
#speaker:Professor
->main

===main===
This showcase interaction between varibales in dialogues and the environment.
Choose a new color for the big sphere over there: 
    +[Red]
        ->chosen("Red")
    +[Green]
        ->chosen("Green")
    +[Blue]
        ->chosen("Blue")
        
===chosen(color)===
~ color_choice = color
~ knows_nothing = false
~ variable_dialogue = true
You chose {color}
    ->END