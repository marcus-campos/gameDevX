using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameDevProject
{
    class Notificacoes
    {
        /// <summary>
        /// Imagem do escritorio
        /// </summary>
        public Texture2D Texture { get; set; }

        /// <summary>
        /// Posição do escritorio na tela
        /// </summary>
        public Vector2 Position { get; set; }

        public Notificacoes(Game game)
        {
            Texture = game.Content.Load<Texture2D>(@"Texturas\dialogo");
        }

        /// <summary>
        /// Desenha o escritorio na tela
        /// </summary>
        /// <param name="spriteBatch">Spritebatch para desenho
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Vector2.Zero, Color.White);
        }
    }
}
