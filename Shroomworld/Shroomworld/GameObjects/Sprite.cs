using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shroomworld
{
    public class Sprite
    {
        // ----- Enums -----
        public class Vertices
        {
            public int TopLeft = 0;
            public int TopRight = 1;
            public int BottomLeft = 2;
            public int BottomRight = 3;
        }


        // ----- Properties -----
        public Texture2D Texture { get => _texture; }
        public Color Colour { get => _colour; }
        public Vector2 Size { get => _size; }


        // ----- Fields -----
        protected Texture2D _texture;
        protected Color _colour;
        protected Vector2 _size;


        // ----- Constructors -----
        public Sprite(Texture2D texture)
        {
            _texture = texture;
            _size = new Vector2(_texture.Width, _texture.Height);
        }


        // ----- Methods -----
        public Vector2[] GetVertices(Vector2 position)
        {
            return new Vector2[]
            {
                position, // Top Left
                position + _size * Vector2.UnitX, // Top Right
                position + _size * Vector2.UnitY, // Bottom Left
                position + _size, // Bottom Right
            };
        }
    }
}
