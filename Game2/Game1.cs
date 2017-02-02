using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace SnakeLadderQuiz.Desktop
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        int millisecondsPerFrame = 150; //Update every 150 ms
        double timeSinceLastUpdate = 0; //Accumulate the elapsed time

        private Texture2D background;        
        private List<Rectangle> rects = new List<Rectangle>();
        private List<Texture2D> textureRects = new List<Texture2D>();
        private Color rectColor;

        public List<Player> players = new List<Player>(5);

        public bool RaiseStart = false;
        public bool RaiseReset = false;

        public Action FinishWalk;

        private Dictionary<int, int> ruleUps = new Dictionary<int, int> {
            { 6, 16 },
            { 9, 31 },
            { 19, 38 },
            { 21, 79 },
            { 28, 84 },
            { 51, 67 },
            { 72, 93 },
            { 80, 100 },
        };
        private Dictionary<int, int> ruleDowns = new Dictionary<int, int> {
            { 43 ,23 },
            { 49, 33 },
            { 56, 26 },
            { 65, 57 },
            { 88, 53 },
            { 92, 71 },
            { 99, 35 }
        };
        
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

            InitFirstMoveAllPlayer();
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

            var playerNeedToWalks = players.Find(i => i.IsInPositionDestination() == false);
            if (playerNeedToWalks == null)
            {
                //KeyboardState state = Keyboard.GetState();
                //if (state.IsKeyDown(Keys.Enter))
                if (RaiseStart)
                {                
                    RaiseStart = false;
                    if (AnyoneWin())
                    {
                        InitFirstMoveAllPlayer();
                        // stop all moves
                        players.ForEach(i => i.LastWalkIsMe = false);
                    }
                    else
                    {
                        // who's turn to walk now?
                        var player = WhoIsNextPlayerToWalk();
                        if (player != null) {
                            // hei player, you go to destination now!                    
                            player.PositionDestination = player.Position + RollTheDice();
                        }
                    }
                }

                //if (state.IsKeyDown(Keys.S))
                if (RaiseReset)
                {
                    RaiseReset = false;
                    InitFirstMoveAllPlayer();
                }
            }


            // slowdown logic 
            timeSinceLastUpdate += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (timeSinceLastUpdate >= millisecondsPerFrame)
            {
                timeSinceLastUpdate = 0;

                //YOUR GAMES LOGIC GOES HERE
                if (playerNeedToWalks != null)
                {
                    int nextPosition = playerNeedToWalks.Position + 1;
                    // change destination
                    nextPosition = ChangePositionUpDown(nextPosition, playerNeedToWalks);

                    SetPositionPlayer(playerNeedToWalks, nextPosition);
                }
                else
                {
                    FinishWalk?.Invoke();
                }

                System.GC.Collect();
            }

            base.Update(gameTime);
        }

        private int  ChangePositionUpDown(int nextPosition, Player playerNeedToWalks) {            
            if (nextPosition == playerNeedToWalks.PositionDestination)
            {
                int? moveUpDownPosition = PlayerNeedToMoveUpDown(playerNeedToWalks);
                if (moveUpDownPosition.HasValue)
                {
                    playerNeedToWalks.PositionDestination = moveUpDownPosition.Value;
                    nextPosition = moveUpDownPosition.Value;
                }
            }
            return nextPosition;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            try
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
            catch (Exception)
            {
                
            }
            
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

        private void InitFirstMoveAllPlayer() {
            foreach (var player in players)
            {
                SetPositionPlayer(player, 0);
                player.PositionDestination = 0;
                player.LastWalkIsMe = false;
            }
            RandomizeStartPlayer().LastWalkIsMe = true;
        }

        private Player RandomizeStartPlayer() {
            return players[new Random().Next(0, 4)];
        }

        private int? PlayerNeedToMoveUpDown(Player player) {
            int? resultPosition = null;
            if (ruleUps.ContainsKey(player.Position + 2))
            {
                resultPosition = ruleUps[player.Position + 2] - 1;
            }
            else if (ruleDowns.ContainsKey(player.Position + 2))
            {
                resultPosition = ruleDowns[player.Position + 2] - 1;
            }
            return resultPosition;
        }

        private void SetPositionPlayer(Player player, int position)
        {
            var rect = rects[position];
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

            //update position player
            player.Position = position;
        }

        private Player WhoIsNextPlayerToWalk()
        {
            Player playerLastWalkIsMe = null;

            Player player = players.Find(i => i.LastWalkIsMe == true);

            if (player != null) {
                player.LastWalkIsMe = false;

                if (player.Id == 4)
                {
                    playerLastWalkIsMe = players[0];
                }
                else
                {
                    playerLastWalkIsMe = players.Find(i => i.Id == player.Id + 1);
                }

                playerLastWalkIsMe.LastWalkIsMe = true;
            }
            
            return playerLastWalkIsMe;
        }

        private int RollTheDice()
        {
            return new Random().Next(1, 12);
        }

        private bool AnyoneWin() {
            return players.Find(i => i.Position == 99) != null;
        }
    }


    public class Player
    {

        public Player(int Id)
        {
            Position = 0;
            PositionDestination = 0;
            //PlayerMode = Player.Mode.Stop;
            LastWalkIsMe = false;
            this.Id = Id;
        }

        private int _positionDestination;

        public int Id { get; set; }

        //public enum Mode
        //{
        //    Stop,
        //    Walking
        //}

        public Texture2D Texture2D { get; set; }
        public Vector2 Vector2 { get; set; }
        /// <summary>
        /// start from 0
        /// </summary>
        public int Position { get; set; }

        public bool LastWalkIsMe { get; set; }

        //public Mode PlayerMode { get; set; }
        /// <summary>
        /// start from 0
        /// </summary>
        public int PositionDestination
        {
            get { return _positionDestination; }
            set
            {
                if (value > 99)
                {
                    value = 99;
                }
                _positionDestination = value;
            }
        }
        public bool IsInPositionDestination()
        {
            return Position == PositionDestination;
        }
    }
}
