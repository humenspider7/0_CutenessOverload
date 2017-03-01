using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace CutenessOverload
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SoundEffect sfxchains, sfxcloaker;
        Song backgroundm;

        // Define all the variables you want to use here

        Texture2D bank;  // This is a Texture2D object that will hold the background picture
        //Texture2D superDogSheet;  // What's supdog?
        Texture2D dallasTexture;
        Texture2D chainsTexture;
        Texture2D wolfTexture;
        Texture2D hoxtonTexture;
        Texture2D cloakerTexture;

        double timer = 0;

        bool chainsPlayed = false;
        bool cloakerPlayed = false;

        //Sprite superdog;  // We will load a superdog image into this sprite and make him do awesome things!
       
        //PART 1

        Sprite dallas;
        Sprite chains;
        Sprite wolf;
        Sprite hoxton;
        Sprite cloaker;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            bank = Content.Load<Texture2D>("bank");  // Load the background picture file into the 
                                                                 // texture.. note that under the properties for 
                                                                 // background.jpg in the Solution explorer you 
                                                                 // should see that it has the asset name of "background"
            //superDogSheet = Content.Load<Texture2D>("superdog");

            dallasTexture = Content.Load<Texture2D>("Dallas");
            chainsTexture = Content.Load<Texture2D>("Chains");
            wolfTexture = Content.Load<Texture2D>("Wolf");
            hoxtonTexture = Content.Load<Texture2D>("Hoxton");
            cloakerTexture = Content.Load<Texture2D>("Cloaker");

            sfxchains = Content.Load<SoundEffect>("Chains SE");
            sfxcloaker = Content.Load<SoundEffect>("Cloaker 1 SE");

            backgroundm = Content.Load<Song>("icefront");

            MediaPlayer.Play(backgroundm);
            

            //superdog = new Sprite(new Vector2(-150, 30), // Start at x=-150, y=30
                                  //superDogSheet,
                                 // new Rectangle(164, 0, 163, 147), // Use this part of the superdog texture
                                  //new Vector2(60, 20));
            
            dallas = new Sprite(new Vector2(0, 630), // Start at x=-150, y=30
                                  dallasTexture,
                                  new Rectangle(1, 1, 149, 219), // Use this part of the superdog texture (start x, start y, width, height)
                                  new Vector2(60, 0));

            wolf = new Sprite(new Vector2(350, 30), // Start at x=-150, y=30
                                  wolfTexture,
                                  new Rectangle(7, 2, 128, 163), // Use this part of the superdog texture (start x, start y, width, height)
                                  new Vector2(90, 90));

            chains = new Sprite(new Vector2(150, 30), // Start at x=-150, y=30
                                 chainsTexture,
                                  new Rectangle(9, 20, 129, 170), // Use this part of the superdog texture (start x, start y, width, height)
                                  new Vector2(90, 0));

            hoxton = new Sprite(new Vector2(50, 30), // Start at x=-150, y=30
                                 hoxtonTexture,
                                  new Rectangle(0, 0, 149, 161), // Use this part of the superdog texture (start x, start y, width, height)
                                  new Vector2(90, 0));

            cloaker = new Sprite(new Vector2(0, 30), // Start at x=-150, y=30
                                 cloakerTexture,
                                  new Rectangle(0, 0, 157, 160), // Use this part of the superdog texture (start x, start y, width, height)
                                  new Vector2(90, 0));





            //PART 2

            // Add any other initialization code here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            timer += gameTime.ElapsedGameTime.TotalSeconds;

            if (timer > 3 && !chainsPlayed)
            {
                sfxchains.Play();
                chainsPlayed = true;
            }

            if (timer > 5 && !cloakerPlayed)
            {
                sfxcloaker.Play();
                cloakerPlayed = true;
            }

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            //superdog.Rotation =  superdog.Rotation + 0.1f;
            
            // TODO: Add your update logic here
            //superdog.Update(gameTime);  // Update the superdog so he moves
            
            dallas.Update(gameTime);
            chains.Update(gameTime);
            wolf.Update(gameTime);
            hoxton.Update(gameTime);
            cloaker.Update(gameTime);
            //PART 3

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            // TODO: Add your drawing code here
            spriteBatch.Draw(bank, new Rectangle(0,0,this.Window.ClientBounds.Width,this.Window.ClientBounds.Height), Color.White); // Draw the background at (0,0) - no crazy tinting
            //superdog.Draw(spriteBatch);  // Draw the superdog!
           
            dallas.Draw(spriteBatch);
            chains.Draw(spriteBatch);
            wolf.Draw(spriteBatch);
            hoxton.Draw(spriteBatch);
            cloaker.Draw(spriteBatch);
            
            //PART 4

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
