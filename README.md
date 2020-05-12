# MediumCoreInventorySaveClock
Terraria mod for mediumcore mode to automatically put items back in their respective places once you die and pick them up.
It also displays a real world clock. You can modify the clock settings in the Mod Configuration.

## Hotkey:

``` 
"Home" - Used to enable/disable death cache. When death cache is true and you die, it saves your inventory. 

By default this value is true, however, when you die this value becomes false. 

Once you recover your items, press the hotkey to set it back to true so when you die, it works again. 

Pressing the hotkey will also display the current status in the bottom left corner of the screen.

```

The above hotkey was added as a safety measure in case of subsequent deaths prior to picking up items.

Note: If your hotkey is not displaying a message when you press it, make sure to check your key bindings.

## Thanks:

The code behind displaying the time was inspired by GoodPro712's FlightTimer Mod.
You can check out that mod here: https://github.com/GoodPro712/FlightTimer

## Caveats:

1. If you have a full inventory when you go to pick up your body, this mod will not do anything as your inventory is full.

2. This mod does not work properly with players who have the same name. 
