
## About Predictive SDK ⚙️

Supercharge Your App's Text Processing Capabilities with PredictiveSDK for iOS, iPadOS, watchOS or Android. 

PredictiveSDK equips developers with an array of powerful features to take their app's performance to the next level. Benefit from advanced functionalities including Autocorrection, Autocompletion, Next Word Prediction, and Swipe Typing, all available in 82 languages. Unleash the potential of effortless text input and optimize the user experience like never before.


## Installation

**iOS, iPadOS, watchOS**

PredictiveSDK can be installed with the Swift Package Manager:

`https://github.com/FleksySDK/PredictiveSDK-iOS`


**Android**

PredictiveSDK can be installed with Maven: 

` maven { url = "https://maven.fleksy.com/maven" } `

and adding the dependency:

``` 
dependencies {
  ...       
  // Predictive Keyboard SDK dependency
  implementation("co.thingthing.fleksylib:fleksylib-release:1.0.5")
}
```

**Unity**

The PreditiveSDK is provided as a binary package inside the folder `Integration/PredictiveSDK-Unity/fleksypredictionsdk.unitypackage`. Just add this package as you would do with any other Unity custom package and you'll be able to use our PredictionSDK in your Unity projects targeting Android (more platforms will follow soon).

You can find a sample project with a guide that will follow you through the first steps to use our SDK using OpenXR that will allow you to test our technology in a OpenXR compatible device, like the Meta Quest 2.

## Supported Platforms

**Apple Platform**

`iOS 12` , `Mac Catalyst 14` and `watchOS7`

**Android Platform**

`Android API 21`

It also supports `kotlin` and `java`

**Unity platform**

`Android API 26`

## Features

* 🔄 **Autocorrection**: Utilize the PredictiveSDK to automatically correct text. Simply send the text, and the PredictiveSDK will provide the most precise and accurate auto corrections.
* ⚡ **Autocomplete**: By entering the current text the PredictiveSDK suggests the most probable word.
* 🔜 **Next Word Prediction**: By providing a text context to the PredictiveSDK, it has the ability to suggest the most likely next word or even an appropiate emoji.
* ⏺️ **Learning**: You can input words and sentences to be learned by the PredictiveSDK. Once learned, it will have the capability to auto-correct, predict and recognize them through swipe gestures. 
* 👆 **Swipe Typing**: Once you incorporate your custom geometry layout into the PredictiveSDK, it becomes capable of identifying swiped words. You can achieve this by sending (x,y) positions of the swiped trajectory to the PredictiveSDK.


##  Integration

Using the Predictive SDK you can add Autocorrection, Next Word Prediction and Swipe typing to your apps and custom keyboards.

| Folder | Description |
| --- | --- |
| [/Integration/PredictiveSDK-iOS](/Integration/PredictiveSDK-iOS) | iOS project for an App which uses the Predictive SDK for Autocorrection and Next word prediction. |
| [/Integration/PredictiveSDK-watchOS](/Integration/PredictiveSDK-watchOS) | watchOS project for an App which uses the Predictive SDK for implementing a keyboard. |
| [/Integration/PredictiveSDK-Android](/Integration/PredictiveSDK-Android) | Android project for an App which uses the Predictive SDK for Autocorrection and Next word prediction. |


## Documentation 📗

- [Quick Start](https://docs.fleksy.com/core-sdk/) - Get started on developing your keyboard using the PredictiveSDK.
- [Documentation](https://docs.fleksy.com/) - FleksySDK documentation
- [Developer portal](https://developers.fleksy.com) - Fleksy developer portal.


## How to get help? 🙋

Any question that you might have, please post it directly into the [Github Discussion Forum](https://github.com/FleksySDK/PredictiveSDK/discussions).

Business related questions, please, go to our [developer portal](https://developers.fleksy.com/), we will assist you as soon as possible.


## Licensing 📄

The Fleksy test SDK is proprietary binary code and licensed under the Fleksy Binary Trial License in the License folder.

The remaining source code available in this repository are licensed under the MIT license, a copy of which is also in the License folder
 
Documentation is distributed under the CC-BY-ND-4.0 license, available at https://creativecommons.org/licenses/by-nd/4.0/,
 
All code and materials are © 2023 ThingThing Ltd.

