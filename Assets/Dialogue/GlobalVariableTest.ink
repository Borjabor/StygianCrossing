INCLUDE Globals.ink

->main

===main===
Choose a new color for the big sphere over there: #speaker:Professor
    +[Red]
        ->chosen("Red")
    +[Green]
        ->chosen("Green")
    +[Blue]
        ->chosen("Blue")
        
===chosen(color)===
~ color_choice = color
You chose {color}
->END