using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game3

{
    class Button
    {
        public delegate void StringHandler(string s);
        public event StringHandler OnButtonClick = delegate { };
        public Texture2D ButtonTexture { get; set; } 
        public SpriteFont ButtonFont { get; set; }
        Rectangle drawRectangle;
        string label;
       
        
        int[] Xs = new int[3];
        int[] Ys = new int[3];

        
        public Button(string label, Rectangle drawRectangle)
        {

            Xs[0] = 100;
            Xs[1] = 200;
            Xs[2] = 350;


            Ys[0] = 200;
            Ys[1] = 200;
            Ys[2] = 200;
            this.label = label;
            this.drawRectangle = new Rectangle (Xs[0], Ys[0] , 100 , 100);
            this.drawRectangle = new Rectangle(Xs[1], Ys[1], 100, 100);
            this.drawRectangle = new Rectangle(Xs[2], Ys[2], 100, 100);


        }
        
        
        
    }
}
