# Caner Bayrambas Case Study

## 1. Setup
Imported provided files into "main" branch and created a new branch named "main-case-study" that I will work on. I will commit my tasks here. 

## 2. Project Structure
"maanetorn/Farm Game UI - Simple 2D UI" is a third party package. I would adapt the assets into my projects folder structure, but since there is none currently, I'm creating a new folder structure for this project.
1. Created a root folder named "TechArtCaseStudy" to include all of game assets named under our domain to distuingish between other folders imported in the future such as sdk etc. Adding "_" prefix to make it appear at the top.
2. Create essential sub folders such as Scripts, Sprites, Shaders, Scenes, Prefabs, Fonts. Add sub folder named "UI" in Scripts and Prefabs for only UI assets. Moved everything and deleted the "maanetorn" folder.
3. Update script namespaces to "Appodeal.TechArtCaseStudy.UI"

## 3. Game Juice
1. I have a big SFX library for my projects, so I selected few sound effects from there.
2. I installed DOTween package for tweening the UI elements.
3. Created a futureproof, following open closed principle, audio player system to play SFX.
4. Created ProgressBarAnimation class and attached it for the Play button. Tweening and playing the SFX. Polishing the timings.

## 4. UI
1. First thing annoying me was Canvas living under Main Camera. Seperated them.
2. I think we want Canvas to follow camera, so I switched Render Mode to Camera in Canvas.
3. Set UI Scale Mode to "Scale with Screen Size" and set "Reference Resolution" to 1125x2436 (Mobile phone reference resolution, iphone x).
4. Set "Match Width Height" value to 0.5 to support both mobile phones and tablets.

## 5. Performance optimization
I want to talk within 2 topics:

### Optimization: 
1. For the performance improvements, currently the panels such as "rate us" or "settings" are staying in the scene. They should be a prefab and removed from the scene. Instiated when needed, with a class controlling window/popup system.
2. If specific UI has so many animations I would add it's own "Canvas" component which makes it optimized. Because Canvas is reconstructing itself in every change.
3. We can use "Sprite Atlas" to optimize sprites and reduce batch count.
4. I believe we don't need both 256x256 and 128x128 versions of the same assets. I can make any size within RectTransform "Width" and "Height". So I'm not currently deleting to break the scene but normally I would have.
5. If I want to optimize it more; I would get rid of all button sprites and make a black & white version. Giving it's color in runtime.
6. Set target frame rate to 60 FPS.

### Futureproof UI:
Current UI structure is very chaotic and not futureproof. Let me explain;
1. "Pivot"s aren't correctly set. Currently all of the pivots left in "Middle" which will break the visuals in different devices. Pivots must be set for stretching or preserving it's position correctly.
2. UI is not dynamic! All of the rewards placed manually. When I will spawn the rewards procedurally from a script it won't work out. So what we will do is; We need to rebuild rewards section with "Content Size Fitter" and "Grid Layout Group" components.
3. Localization hell: I see some texts aren't in "Auto size" and strecthed for the area they are in. They all will be broken when localization feature comes in.

## 6. Pipeline optimization
1. Naming convention is very important. Adding asset type prefix for example "audio_" then where it's used for "audio_ui" then what it looks/sounds like "audio_ui_success"
2. "AssetPostprocessor" API for import pipeline. For example set "texture type" to "sprite" based on asset path or asset name.
3. Overriding import settings based on platform (Android, IOS) for best result possible.
4. Creating plugins for DCC tools such as Blender or Photoshop.

#### Thanks for your time.