using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace SnakeLadderQuiz.Desktop
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Texture2D background;
        private List<Rectangle> rects = new List<Rectangle>();
        private List<Texture2D> textureRects = new List<Texture2D>();
        private Color rectColor;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
            this.Window.Title = "Snake Ladder Quiz";
            
            Content.RootDirectory = "Content";
            rectColor = Color.Transparent;
            CreateListOfRectangle();
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            background = Content.Load<Texture2D>("snake_ladder");
            CreateListOfTextureRect(rectColor);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            background.Dispose();
            spriteBatch.Dispose();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here

            System.GC.Collect();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here            
            spriteBatch.Begin();
            spriteBatch.Draw(background, new Rectangle(0, 0, 800, 600), Color.White);
            DrawEachBoxInSnakeLadder(rectColor);
            spriteBatch.End();

            base.Draw(gameTime);
        }
        
        private void CreateListOfRectangle() {
            var firstRect = new Rectangle(48, 478, 70, 50);
            ////kanan
            //DrawRectangle(new Rectangle(119, 478, 70, 50), Color.Black);
            ////atas
            //DrawRectangle(new Rectangle(48, 428, 70, 50), Color.Red);
            
            rects.Add(firstRect);

            bool keKanan = true;
            bool keAtas = false;

            for (int i = 1; i < 100; i++)
            {

                if (i % 10 == 0)
                {
                    keAtas = true;
                }
                else {
                    keAtas = false;
                }


                if (keAtas)
                {
                    rects.Add(new Rectangle(rects[i-1].X, rects[i - 1].Y - 50, 70, 50));
                    keKanan = !keKanan;
                }
                else {
                    if (keKanan) {
                        rects.Add(new Rectangle(rects[i - 1].X + 71, rects[i - 1].Y, 70, 50));
                    }
                    else {
                        rects.Add(new Rectangle(rects[i - 1].X - 71, rects[i - 1].Y, 70, 50));
                    }
                }
                
            }
        }


        private void CreateListOfTextureRect(Color color)
        {
            for (int i =0; i < 100; i++)
            {
                var textureRect = new Texture2D(this.GraphicsDevice, 1, 1);
                textureRect.SetData(new[] { color });
                textureRects.Add(textureRect);
            }
            
        }

        private void DrawEachBoxInSnakeLadder(Color color ) {            
            for (int i = 0; i < 100; i++)
            {
                spriteBatch.Draw(textureRects[i], rects[i], color);
            }
           
        }

    }
}
