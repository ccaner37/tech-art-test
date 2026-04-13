# Caner Bayrambas Case Study

## Project Structure
"maanetorn/Farm Game UI - Simple 2D UI" is a third party package. I would adapt the assets into my projects folder structure, but since there is none currently, I'm creating a new folder structure for this project.
1. Create a root folder to include all of game assets named under our domain (project name; TechArtCaseStudy) to distuingish between other folders imported in the future such as sdk etc. Adding "_" prefix to make it appear at the top.
2. Create essential sub folders such as Scripts, Sprites, Shaders, Scenes, Prefabs, Fonts. Add sub folder named "UI" in Scripts and Prefabs for only UI assets. Delete the "maanetorn" folder.
3. Update script namespaces to "Appodeal.TechArtCaseStudy.UI"

## Game Juice
1. I have a big SFX database for my projects, so I selected few sound effects from there.
2. I installed DOTween package for tweening the UI elements.
3. Created a futureproof, following open closed principle, audio player system to play SFX.