# Unity-Game-Creator-Synty-Hero-Module

This is a plugin developed specifically for Unity and the assets "Game Creator" and "Modular Fantasy Hero Characters" to create and customize your Synty Hero Characters.

# Requirements

* A license for [POLYGON - Modular Fantasy Hero Characters](https://assetstore.unity.com/packages/3d/characters/humanoids/polygon-modular-fantasy-hero-characters-143468)
* A license for [Game Creator](https://assetstore.unity.com/packages/templates/systems/game-creator-89443)
* Unity 2019.4.0 or higher

# Installation

1. Download the repository
2. Unzip it
3. Place the Plugin folder of this project in your Assets folder of your Unity Project
4. Place your Synty Character in your scene
5. Add the Synty Character Component to it
6. In the Inspector of the Synty Character Component, press "Load Character"

# Features

This section will briefly describe the current features of this plugin.

* A Saveable & Loadable (in Game Creator context) Synty Character Component was created
* 5 Game Creator Actions have been added

## Actions

Synty Character Attachment:
Activates a Synty Attachment (e.g. Hair, Face, Torso Armor, Legs) on the Character model.

Synty Character Randomize:
Randomizes the visible attachments of a characters Head, Eyebrows, Hair and Material Colors.

Synty Character Set Material Color:
Specifically sets the Material Color of the Synty Character Material to a defined Color.
This action will currently use the Shared Material Methods of Unity to change the colors, which means that all models, which share the same material will receive the color changes.

Synty Character Set Text From Attachment:
This action will change the text of a Text Mesh Pro UI Component. It allows you to include the index of the currently active element in the newly created text.
For example: Selecting the Element Eyebrow on a Player and defining the actions content as "You have chosen eyebrow {0}", will result in "You have chosen eyebrow 13" if the 13th eyebrow model is currently active.

