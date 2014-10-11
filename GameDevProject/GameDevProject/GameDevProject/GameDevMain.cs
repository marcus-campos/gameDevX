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

namespace GameDevProject
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class GameDevMain : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Escritorio escritorio;
        Notificacoes notificacoes;
        SpriteFont sFont;
        public string dataHora = "Ano: 0, Mes: 0, Dia: 0";
        //Texture2D background;

        public GameDevMain()
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
            // Altera o vídeo para 800 pixels de largura
            graphics.PreferredBackBufferWidth = 800;
            // Altera o vídeo para 600 pixels de altura
            graphics.PreferredBackBufferHeight = 600;
            // Desabilita o modo tela cheia
            graphics.IsFullScreen = false;
            // Desabilita a visibilidade do mouse dento do jogo
            IsMouseVisible = true;
            // Aplica as mudanças
            graphics.ApplyChanges();
            // Define o título da janela
            Window.Title = "Game dev Project X";
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
            escritorio = new Escritorio(this);
            notificacoes = new Notificacoes(this);
            //Carrega fonte
            spriteBatch = new SpriteBatch(GraphicsDevice);
            sFont = Content.Load<SpriteFont>(@"Arial");
            // TODO: use this.Content to load your game content here
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
        int semana = 0;
        int mes = 0;
        int ano = 0;
        int frames = 0;

        public void tempoMundial()
        {
            if (frames > 120)
            {
                frames = 0;
                if (semana < 4)
                {
                    semana++;
                }
                else
                {
                    semana = 0;
                    mes++;                    
                }

                if (mes <= 12)
                {

                }
                else
                {
                    mes = 0;
                    ano++;
                }
            }
            else
            {
                frames++;
            }
            dataHora = "Ano: " + ano + ", mes: " + mes + ", semana: " + semana + "";
        }
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            tempoMundial();
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
            escritorio.Draw(spriteBatch);
            spriteBatch.DrawString(sFont, dataHora, new Vector2(600.0f, 550.0f), Color.Black);
            notificacoes.Draw(spriteBatch);
            spriteBatch.DrawString(sFont, parseText("Este game e o mais hue que eu ja fiz, estou escrendo este texto para fazer o texte da huezada"), new Vector2(300.0f, 300.0f), Color.Black);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        //Outras funcoes
        private string parseText(string SomeText)
        {
	        //Create a string to return that is empty
	        String returnString = String.Empty;
	        //Create a list of lines that are already in the text 
                 //so that they remain separated
	        String[] ExistingLines = SomeText.Split("\n".ToCharArray());
	        //Create a list to contain the new lines of text.
	        List<String> Lines = new List<String>();
	        //For every existing line, check its length and split it up if it's too long.
	        foreach (String ALine in ExistingLines)
	        {
		        //Current line that is being split up
		        String line = String.Empty;
		        //Lines that this existing line has been split up into
		        List<String> CLines = new List<String>();
		        //Words in this existing line
		        String[] wordArray = ALine.Split(' ');
		        //For each word, check if it will fit on the current line, 
		        //if not create a new line and add the old one to the CLines object.
		        foreach (String word in wordArray)
		        {
			        //Check to see if word will fit on current line.
                    if (sFont.MeasureString(line + word + " ").Length() > 275)
			        {
				        //If not, add the line to CLines with a new line
				        CLines.Add(line + "\n");
				        //Reset the current line to blank.
				        line = String.Empty;
			        }
			        //Add the word to the current line.
			        line = line + word + ' ';
		        }
		        //Add the current line to Clines as it won't already have been added.
		        CLines.Add(line + "\n");
		        //For every line this existing line has been split up into
		        foreach (string TheLine in CLines)
		        {
			        Lines.Add(TheLine);
		        }
	        }
	        //Remove the first line until the number of lines is less than the maximum.
	        while(Lines.Count > 10)
	        {
		        Lines.RemoveAt(0);
	        }
	        //Add the final set of lines to the return string.
	        for (int i = 0; i < Lines.Count; i++)
	        {
		        returnString += Lines[i];
	        }
	        return returnString;
        }
        
    }
}
