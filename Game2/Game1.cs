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

        private List<Player> players = new List<Player>(5);

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
            this.Window.Title = "Snake Ladder Quiz";
            
            Content.RootDirectory = "Content";
            rectColor = Color.Transparent;
            CreateListOfRectangle();

            for (int i = 0; i < 5; i++)
            {
                var player = new Player(i);                
                players.Add(player);
            }
            
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
                        
            players[0].Texture2D = Content.Load<Texture2D>("emo_gigikawat");
            players[1].Texture2D = Content.Load<Texture2D>("emo_melet");
            players[2].Texture2D = Content.Load<Texture2D>("emo_kacagigi");
            players[3].Texture2D = Content.Load<Texture2D>("emo_nangis");
            players[4].Texture2D = Content.Load<Texture2D>("emo_duit");

            CreateListOfTextureRect();

            initFirstMoveAllPlayer();
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
            
            // Allows the game to exit
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            //    this.Exit();
            
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Enter))
            {
                // do something here
                // sample move
                players[0].Vector2 = new Vector2(rects[10].X, rects[10].Y);
            }

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
            DrawEachBoxInSnakeLadder();
            DrawEachPlayer();
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

                // I know var keAtas can set in one line, but I want it readable
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

        private void CreateListOfTextureRect()
        {
            for (int i =0; i < 100; i++)
            {
                var textureRect = new Texture2D(this.GraphicsDevice, 1, 1);
                textureRect.SetData(new[] { rectColor });
                textureRects.Add(textureRect);
            }
            
        }

        private void DrawEachBoxInSnakeLadder() {            
            for (int i = 0; i < 100; i++)
            {
                spriteBatch.Draw(textureRects[i], rects[i], rectColor);
            }
           
        }

        private void DrawEachPlayer() {
            foreach (var player in players)
            {
                spriteBatch.Draw(player.Texture2D, new Rectangle((int)player.Vector2.X, (int)player.Vector2.Y, 30, 30), Color.White);
            }
        }

        private void initFirstMoveAllPlayer() {
            foreach (var player in players)
            {
                SetPositionPlayer(rects[0], player);
            }
        }

        private void SetPositionPlayer(Rectangle rect, Player player)
        {
            if (player.Id == 0)
            {
                player.Vector2 = new Vector2(rect.X, rect.Y);
            }
            else if (player.Id == 1)
            {
                player.Vector2 = new Vector2(rect.X+40, rect.Y);
            }
            else if (player.Id == 2)
            {
                player.Vector2 = new Vector2(rect.X, rect.Y+22);
            }
            else if (player.Id == 3)
            {
                player.Vector2 = new Vector2(rect.X+40, rect.Y+22);
            }
            else if (player.Id == 4)
            {
                player.Vector2 = new Vector2(rect.X+20, rect.Y+11);
            }
        }

        public class Player
        {

            public Player(int Id)
            {
                Position = 0;
                PositionDestination = 0;
                PlayerMode = Player.Mode.Stop;
                this.Id = Id;
            }

            public int Id { get; set; }

            public enum Mode
            {
                Stop,
                Walking
            }

            public Texture2D Texture2D { get; set; }
            public Vector2 Vector2 { get; set; }
            public int Position { get; set; }
            public Mode PlayerMode { get; set; }
            public int PositionDestination { get; set; }
            public bool IsInPositionDestination()
            {
                return Position == PositionDestination;
            }
        }

    }
}
