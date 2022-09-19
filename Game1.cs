using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LOZ
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;

        private string creditsString = "Credits\nProgram Made By: Team BoggusMWF\nSprites from: https://www.spriters-resource.com/nes/legendofzelda/";

        /*Declaration of controllers*/
        private KeyboardController keyboardController = new KeyboardController();
        private MouseController mouseController = new MouseController();

        /*Declaration of needed sprites*/
        private MovingAnimatedSprite movingAnimatedSprite = new MovingAnimatedSprite();
        private StationaryAnimatedSprite animatedSprite = new StationaryAnimatedSprite();
        private MovingStaticSprite movingStaticSprite = new MovingStaticSprite();
        private StationaryStaticSprite staticSprite = new StationaryStaticSprite();
        private TextSprite textSprite = new TextSprite();

        /*Container for sprites to draw in order*/
        private HashSet<ISprite> spritesToDraw = new HashSet<ISprite>();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here


            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            textSprite.setFont(Content.Load<SpriteFont>("./TextFonts/MainText"));

            movingAnimatedSprite.loadSpriteSheet(Content.Load<Texture2D>("./SpriteSheets/Link")); /*TODO: The coordinates for this whole section are no longer good*/
            movingAnimatedSprite.setFrame1Rectangle(135, 154, 16, 27);
            movingAnimatedSprite.setFrame2Rectangle(95, 155, 16, 26);
            movingAnimatedSprite.setFrame3Rectangle(55, 155, 16, 26);
            movingAnimatedSprite.setPositionRectangle(400, 200, 16, 27);

            animatedSprite.loadSpriteSheet(Content.Load<Texture2D>("./SpriteSheets/Link"));
            animatedSprite.setFrame1Rectangle(166, 474, 34, 27);
            animatedSprite.setFrame2Rectangle(355, 394, 16, 28);
            animatedSprite.setFrame3Rectangle(206, 474, 34, 27);
            animatedSprite.setPositionRectangle(400, 200, 16, 28);

            movingStaticSprite.loadSpriteSheet(Content.Load<Texture2D>("./SpriteSheets/Link"));
            movingStaticSprite.setFrameRectangle(291, 474, 23, 28);
            movingStaticSprite.setPositionRectangle(400, 200, 16, 28);

            staticSprite.loadSpriteSheet(Content.Load<Texture2D>("./SpriteSheets/Link"));
            staticSprite.setFrameRectangle(15, 194, 16, 27);
            staticSprite.setPositionRectangle(400, 200, 16, 27);
        }

        protected override void Update(GameTime gameTime)
        {
            keyboardController.update();
            mouseController.update();

            if (keyboardController.lastInputTime >= mouseController.lastInputTime)
            {

                switch (keyboardController.getLastPressed())
                {
                    case 4:
                        movingAnimatedSprite.updateCurrentFrame(gameTime);
                        spritesToDraw.Add(movingAnimatedSprite);
                        break;

                    case 3:
                        movingStaticSprite.updateCurrentFrame(gameTime);
                        spritesToDraw.Add(movingStaticSprite);
                        break;

                    case 2:
                        animatedSprite.updateCurrentFrame(gameTime);
                        spritesToDraw.Add(animatedSprite);
                        break;

                    case 1:
                        staticSprite.updateCurrentFrame(gameTime);
                        spritesToDraw.Add(staticSprite);
                        break;

                    case 0:
                        Exit();
                        break;
                    default:
                        staticSprite.updateCurrentFrame(gameTime);
                        spritesToDraw.Add(staticSprite);
                        break;
                }

            }
            else
            {

                switch (mouseController.getLastPressed())
                {
                    case 4:
                        movingAnimatedSprite.updateCurrentFrame(gameTime);
                        spritesToDraw.Add(movingAnimatedSprite);

                        break;

                    case 3:
                        movingStaticSprite.updateCurrentFrame(gameTime);
                        spritesToDraw.Add(movingStaticSprite);
                        break;

                    case 2:
                        animatedSprite.updateCurrentFrame(gameTime);
                        spritesToDraw.Add(animatedSprite);
                        break;

                    case 1:
                        staticSprite.updateCurrentFrame(gameTime);
                        spritesToDraw.Add(staticSprite);
                        break;

                    case 0:
                        Exit();
                        break;
                    default:
                        staticSprite.updateCurrentFrame(gameTime);
                        spritesToDraw.Add(staticSprite);
                        break;
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            textSprite.setText(creditsString);
            textSprite.setPosition(100, 400);
            spritesToDraw.Add(textSprite);

            foreach (var item in spritesToDraw)
            {
                item.draw(spriteBatch);
            }

            spritesToDraw.Clear();

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}