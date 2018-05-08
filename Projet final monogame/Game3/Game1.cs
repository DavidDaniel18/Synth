using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game3
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    /// 
    //1.2) modulateurs

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        List<SoundEffect> soundEffects;

        bool ispressed = false;
        bool sine = false;
        // class
        Sprite Wavesign;
        Vector2 vector = new Vector2(0, 10);

        int[] Xs = new int[3];
        int[] Ys = new int[3];


        // lfo counter ints
        int counter = 0;
        int limit = 5;
        float countDuration = 1f;
        float currentTime = 0f;
        float valeurfrac = 0;
        int x = 0;
        float Lfo;
        //
        SpriteFont basicfont;


       //
        int Y1 = 200;
        int Y2 = 200;
        int Y3 = 100;


        Vector2 scale;


        MouseState mousestate;

        

        //pourcentage d'effet du filtre
         float pourcentage1 = 1.0f;
        float pourcentage2 = -1.0f;
        float pourcentage3 = 0.0f;


        //button vecteurs
        Vector2 knobPosition = new Vector2();
        Vector2 knobPosition1 = new Vector2();
        Vector2 knobPosition2 = new Vector2();



        int i;
        List<SoundEffectInstance> instances = new List<SoundEffectInstance>();
        Button[] buttons;
        Texture2D barknob;
        int posY;
        List<Keys> myKeys = new List<Keys>()
        {
            Keys.D1,
            Keys.D2,
            Keys.D3,
            Keys.D4,
            Keys.D5,
            Keys.D6,
            Keys.D7
        };
        private int Timer;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);;
            Content.RootDirectory = "Content";
            soundEffects = new List<SoundEffect>();
            buttons = new Button[16];
            posY = mousestate.Y;

            // barknob size and position
            
            

            Xs[0] = 100;
            Xs[1] = 300;
            Xs[2] = 500;

            
            Ys[0] = 300;
            Ys[1] = 300;
            Ys[2] = 100;

          
            scale = new Vector2 ((float)0.5,(float)0.5);

            Vector2 knobPosition = new Vector2(Xs[0], Ys[0]);
            Vector2 knobPosition1 = new Vector2(Xs[1], Ys[1]);
            Vector2 knobPosition2 = new Vector2(Xs[2], Ys[2]);
            //button init
            buttons = new Button[16];

            buttons[0] = new Button("barknob", new Rectangle(Xs[0], Ys[0], 50, 50));
            buttons[1] = new Button("barknob", new Rectangle(Xs[1], Ys[1], 50, 50));
            buttons[2] = new Button("barknob", new Rectangle(Xs[2], Ys[2], 50, 50));
            


            IsMouseVisible = true;
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
            int screenHeight = 500;
            int screenWidth = 700;
            graphics.PreferredBackBufferHeight = screenHeight;
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            
            base.Initialize();
            

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            soundEffects.Add(Content.Load<SoundEffect>("Csine"));
            soundEffects.Add(Content.Load<SoundEffect>("Dsine"));
            soundEffects.Add(Content.Load<SoundEffect>("Esine"));
            soundEffects.Add(Content.Load<SoundEffect>("Fsine"));
            soundEffects.Add(Content.Load<SoundEffect>("Gsine"));
            soundEffects.Add(Content.Load<SoundEffect>("Asine"));
            soundEffects.Add(Content.Load<SoundEffect>("Bsine"));
            soundEffects.Add(Content.Load<SoundEffect>("C5"));
            soundEffects.Add(Content.Load<SoundEffect>("D5"));
            soundEffects.Add(Content.Load<SoundEffect>("E5"));
            soundEffects.Add(Content.Load<SoundEffect>("F5"));
            soundEffects.Add(Content.Load<SoundEffect>("G5"));
            soundEffects.Add(Content.Load<SoundEffect>("A5"));
            soundEffects.Add(Content.Load<SoundEffect>("B5"));




            foreach (SoundEffect sound in soundEffects)
            {
                instances.Add(sound.CreateInstance());
            }

            
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            buttons[0].ButtonTexture = Content.Load<Texture2D>("barknob");
            buttons[1].ButtonTexture = Content.Load<Texture2D>("barknob");
            buttons[2].ButtonTexture = Content.Load<Texture2D>("barknob");
            barknob = buttons[0].ButtonTexture;

            Wavesign = new Sprite(Content.Load<Texture2D>("rectangle"), new Rectangle(10, 10, 10, 10));
            // Font
            basicfont = Content.Load<SpriteFont>("Font");


        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            // initialise une instance par frame
            ispressed = false;
            if (Y3 > 200)
            {
                sine = true;
                
            }
            else
            {
                sine = false;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D1))
            {
                if (sine == true)
                { i = 0; }
                else
                    i = 7;
                
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D2))
            {
                if (sine == true)
                { i = 1; }
                else
                    i = 8;
                
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D3))
            {
                if (sine == true)
                { i = 2; }
                else
                    i = 9;

            }
            if (Keyboard.GetState().IsKeyDown(Keys.D4))
            {
                if (sine == true)
                { i = 3; }
                else
                    i = 10;

            }
            if (Keyboard.GetState().IsKeyDown(Keys.D5))
            {
                if (sine == true)
                { i = 4; }
                else
                    i = 11;

            }
            if (Keyboard.GetState().IsKeyDown(Keys.D6))
            {
                if (sine == true)
                { i = 5; }
                else
                    i = 12;

            }
            if (Keyboard.GetState().IsKeyDown(Keys.D7))
            {
                if (sine == true)
                { i = 6; }
                else
                    i = 13;


            }

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

           

           
            // joue un son
            for (int i = 0; i < myKeys.Count; i++)
            {

                Keys currentKey = myKeys[i];
                if (Keyboard.GetState().IsKeyDown(currentKey))
                {
                    ispressed = true;
                    if (sine == false)
                    {
                        instances[i + 7].IsLooped = true;
                        instances[i + 7].Play();
                        ispressed = true;
                    }
                    else
                    {
                        instances[i].IsLooped = true;
                        instances[i].Play();
                        ispressed = true;
                    }
                   
                }
                if (Keyboard.GetState().IsKeyUp(currentKey))
                {
                   
                    if (sine == false)
                    {
                        instances[i+7].Stop();
                     

                    }
                    else
                    {
                        instances[i].Stop();
                        
                    }
                    

                }
                


            }

            //1.2)


           


            //fonction de Volume
            pourcentage1 = (((float)Y1 - 100) / 200);
            instances[i].Volume = pourcentage1;

            //fonction de LFO
            // le volume = sin y1
            pourcentage2 = (((float)Y2 - 100) / 200);


           // LF0 TIMER

                currentTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds/(pourcentage2*100); 

            if (currentTime >= countDuration)
                {
                    counter++;
                    currentTime -= countDuration; 

                    valeurfrac = valeurfrac + (float)0.1;
                }
                if (counter >= limit)
                {
                    counter = 0;

                    valeurfrac = 0;
                    x = 0;
                }


                Lfo = (float)System.Math.Sin(pourcentage2 * (x + valeurfrac));
                instances[i].Pitch = Lfo;

            if (pourcentage2 < 0.5)
            {
                valeurfrac = 0;
                pourcentage2 = 0;
            }

            


           
            posY += mousestate.Y;


  


            //Le button doit suivre la souris
            if (mousestate.Position.X > Xs[0] && mousestate.Position.Y < Ys[0] + barknob.Height && mousestate.Position.X < Xs[0] + barknob.Width/2 && mousestate.Position.Y > Ys[0] - barknob.Height / 2 && mousestate.Position.Y < 300 && mousestate.Position.Y > 100)
            {

               
                if (mousestate.LeftButton == ButtonState.Pressed)
                {

                   

                    Y1 = mousestate.Position.Y;
                    Ys[0] = mousestate.Position.Y;

                   
                }
            };
            //X2
            if (mousestate.Position.X > Xs[1] && mousestate.Position.Y < Ys[1] + barknob.Height && mousestate.Position.X < Xs[1] + barknob.Width / 2 && mousestate.Position.Y > Ys[1] - barknob.Height / 2 && mousestate.Position.Y < 300 && mousestate.Position.Y > 100)
            {

               
                if (mousestate.LeftButton == ButtonState.Pressed)
                {

                  

                    Y2 = mousestate.Position.Y;
                    Ys[1] = mousestate.Position.Y;
                   

                }
            };
            //X3
            if (mousestate.Position.X > Xs[2]  && mousestate.Position.Y < Ys[2] + barknob.Height && mousestate.Position.X < Xs[2] + barknob.Width / 2 && mousestate.Position.Y > Ys[2] - barknob.Height / 2 && mousestate.Position.Y < 300 && mousestate.Position.Y > 100)
            {
                
                if (mousestate.LeftButton == ButtonState.Pressed)
                {

                   

                    Y3 = mousestate.Position.Y;
                    Ys[2] = mousestate.Position.Y;

                    
                   
                }
            };




            knobPosition = new Vector2(Xs[0], Ys[0]);
            knobPosition1 = new Vector2(Xs[1], Ys[1]);
            knobPosition2 = new Vector2(Xs[2], Ys[2]);

            //souris
            mousestate = Mouse.GetState();
           

            // TODO: Add your update logic here
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            if (Ys[1] > 200)
            {
                GraphicsDevice.Clear(Color.DarkSlateBlue);

            }
            else
            {
                GraphicsDevice.Clear(Color.Blue);
            }


            // TODO: Add your drawing code here

            spriteBatch.Begin();

            spriteBatch.Draw(barknob, knobPosition, scale : scale );
            spriteBatch.Draw(barknob, knobPosition1, scale: scale);
            spriteBatch.Draw(barknob, knobPosition2, scale: scale);
            spriteBatch.DrawString(basicfont, "Volume", position : knobPosition, color :Color.White);
            spriteBatch.DrawString(basicfont, "LFO Pitch", position: knobPosition1 , color: Color.White);
            spriteBatch.DrawString(basicfont, "Wave Type", position: knobPosition2, color: Color.White);

            if (ispressed == true)
            {
                spriteBatch.DrawString(basicfont, "now playing", position: new Vector2(10,200) , color: Color.Red);
            }
            if (ispressed == false)
            {
                spriteBatch.DrawString(basicfont, "waiting for input", position: new Vector2(10, 200), color: Color.Yellow);
            }

            if (Y3 > 200)
            {
                Wavesign.draw(spriteBatch, vector: vector );
                spriteBatch.DrawString(basicfont, "Sine wave", position: new Vector2(25, 5), color: Color.Red);
            }
            else
            {
                Wavesign.draw(spriteBatch);
                spriteBatch.DrawString(basicfont, "Square wave", position: new Vector2(25, 5), color: Color.White);
            }



            spriteBatch.End();
        

            base.Draw(gameTime);
        }
    }
}
