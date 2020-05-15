using System;
using System.Drawing;

namespace GXPEngine
{
	class Menu : Pivot
	{
		string type;
		EasyDraw bg;
		UIElement playButton;
		UIElement quitButton;
		UIElement retryButton;
		UIElement tutoButton;
		Sprite tutorial;
		UIElement backButton;
		public Menu(string type, Color bgColor)
		{
			bg = new EasyDraw(game.width, game.height, false);
			bg.ShapeAlign(CenterMode.Min, CenterMode.Min);
			bg.Fill(bgColor);
			bg.Rect(0, 0, bg.width, bg.height);
			AddChild(bg);

			this.type = type;
			SetType(type);
		}

		void Update()
		{
			switch (type)
			{
				case "mainMenu":
					if (tutorial.visible)
						TutoMenu();
					else
						MainMenu();
					break;
				case "winMenu":
					WinMenu();
					break;
				case "loseMenu":
					LoseMenu();
					break;

			}
		}

		void SetType(string type)
		{
			if (type == "mainMenu")
			{
				Sprite background = new Sprite("textures/mainMenu.png", false, false);
				AddChild(background);
				playButton = new UIElement(823, 392, "textures/play_button.png");
				AddChild(playButton);
				quitButton = new UIElement(823, 688, "textures/quit_button.png");
				AddChild(quitButton);
				tutoButton = new UIElement(823, 540, "textures/instructions.png");
				AddChild(tutoButton);
				tutorial = new Sprite("textures/instructions_screen.png", false, false);
				AddChild(tutorial);
				tutorial.visible = false;
				backButton = new UIElement(19, 12, "textures/back_button.png");
				AddChild(backButton);
				backButton.visible = false;
				return;
			}

			if(type == "loseMenu")
			{
				Sprite background = new Sprite("textures/lose_screen.png", false, false);
				AddChild(background);
				retryButton = new UIElement(307, 637, "textures/backto_button.png");
				AddChild(retryButton);
			}

			if (type == "winMenu")
			{
				Sprite background = new Sprite("textures/win_screen.png", false, false);
				AddChild(background);
				retryButton = new UIElement(307, 637, "textures/backto_button.png");
				AddChild(retryButton);
			}
		}

		void MainMenu()
		{
			if (playButton.IsClicked(Input.mouseX, Input.mouseY))
			{
				(parent as MyGame).StartGame();
				LateDestroy();
			}

			if (tutoButton.IsClicked(Input.mouseX, Input.mouseY))
			{
				tutorial.visible = true;
				backButton.visible = true;
			}

			if (quitButton.IsClicked(Input.mouseX, Input.mouseY))
				game.LateDestroy();
		}

		void TutoMenu()
		{
			if (backButton.IsClicked(Input.mouseX, Input.mouseY))
			{
				tutorial.visible = false;
				backButton.visible = false;
			}
		}

		void LoseMenu()
		{
			if (retryButton.IsClicked(Input.mouseX, Input.mouseY))
				(parent as MyGame).startAnew();
		}

		void WinMenu()
		{
			if (retryButton.IsClicked(Input.mouseX, Input.mouseY))
				(parent as MyGame).startAnew();
		}
	}
}
