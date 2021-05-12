using SFML.Graphics;
namespace Project
{
    public static class Fonts
    {
        public static Font PECITA;
        public static Font CEAZAR;
        public static Font THINTEL;
        public static Font WETWARE;
        public static Font GRUNGE;
        public static Font NERWUS;
        public static Font CARTOONIST;
        public static void LoadContent()
        {
            PECITA = new Font("./fonts/20180.otf");
            CEAZAR = new Font("./fonts/19842.otf");
            THINTEL = new Font("./fonts/19783.ttf");
            WETWARE = new Font("./fonts/20423.otf");
            GRUNGE = new Font("./fonts/295.ttf");
            NERWUS = new Font("./fonts/1016.ttf");
            CARTOONIST = new Font("./fonts/1588.ttf");
        }
    }
}
